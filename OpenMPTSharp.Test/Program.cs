using OpenMPTSharp;
using Silk.NET.OpenAL;
using Silk.NET.OpenAL.Extensions.EXT;

Console.WriteLine("OpenMPT Test Harness");
Console.WriteLine(OpenMPT.LibraryVersion);
Console.WriteLine(OpenMPT.CoreVersion);
Console.WriteLine($"IsRelease: {OpenMPT.IsRelease}");
Console.WriteLine($"Features: {OpenMPT.Features}");
Console.WriteLine($"Supported Extensions:\n{string.Join('\n', OpenMPT.SupportedExtensions)}");

OpenMPT.Log = Console.WriteLine;

//var modFile = File.ReadAllBytes("sinny-sky_sunday.xm");
var modFile = File.ReadAllBytes("b-joit.it");
var openMPT = new OpenMPT();
var mod = openMPT.CreateModuleFromMemory(modFile);

var sampleRate = 48000;
var bufferSize = 4800;
var numBuffers = 4;

var openal = new OpenALWrapper();
var musicStream = openal.CreateStreamingSoundSource(sampleRate, bufferSize, numBuffers);
musicStream.Play(buffer =>
{
    mod.ReadInterleavedStereo(sampleRate, buffer, bufferSize);
});
Console.WriteLine();
int _lastLine = 0;
while (true)
{
    musicStream.Update();
    var format = $"\rOrder: {mod.CurrentOrder:00} Pattern: {mod.CurrentPattern:00}:{mod.CurrentRow:00}, {mod.ActiveChannels:00} Channels";
    Console.Write(format);
    if (format.Length < _lastLine) Console.Write(new string(' ', _lastLine - format.Length));
    _lastLine = format.Length;
}

public class OpenALWrapper
{
    private readonly AL _al;

    public unsafe OpenALWrapper()
    {
        var alc = ALContext.GetApi(true);
        _al = AL.GetApi(true);
        var device = alc.OpenDevice(string.Empty);

        if (device == null)
        {
            throw new Exception("Could not create device");
        }

        var context = alc.CreateContext(device, null);
        alc.MakeContextCurrent(context);
        _al.ThrowOnError();
    }

    public SoundSource CreateSoundSource()
    {
        return new SoundSource(_al);
    }

    public StreamingSoundSource<short> CreateStreamingSoundSource(int sampleRate, int bufferSize, int numBuffers)
    {
        return new StreamingSoundSource<short>(_al, sampleRate, bufferSize, numBuffers, 0);
    }
}

internal static class ALExtensions
{
    public static void ThrowOnError(this AL al)
    {
        var audioError = al.GetError();
        if (audioError != AudioError.NoError) throw new Exception(audioError.ToString());
    }
}

public class StreamingSoundSource<TBufferType> where TBufferType : unmanaged
{
    private readonly AL _al;
    private readonly int _sampleRate;
    private readonly int _channels;
    private readonly TBufferType _clearValue;
    private readonly TBufferType[] _buffer;
    private Action<TBufferType[]>? _requestBuffer;
    private readonly uint _source;
    private readonly uint[] _buffers;

    private BufferData _bufferDataMethod = null!;

    public StreamingSoundSource(AL al, int sampleRate, int bufferSize, int numBuffers, TBufferType clearValue, int channels = 2)
    {
        _al = al;
        _sampleRate = sampleRate;
        _channels = channels;
        _clearValue = clearValue;
        _source = _al.GenSource();

        _buffers = _al.GenBuffers(numBuffers);
        _al.ThrowOnError();
        _buffer = new TBufferType[bufferSize * 2];
        SetBufferDataMethod();
    }

    private unsafe void SetBufferDataMethod()
    {
        if (typeof(TBufferType) == typeof(float))
        {
            if (!_al.TryGetExtension(out FloatFormat floatFormat))
            {
                throw new Exception("Float audio buffers not supported");
            }

            var format = _channels switch
            {
                1 => FloatBufferFormat.Mono,
                2 => FloatBufferFormat.Stereo,
                _ => throw new Exception("StreamingSoundSource does not support more than 2 channels")
            };
            _bufferDataMethod = (buffer, pData) =>
                floatFormat.BufferData(buffer, format, pData, _buffer.Length, _sampleRate);
        }
        else
        {
            var bitDepth = sizeof(TBufferType) * 8;
            var format = (bitDepth, _channels) switch
            {
                (8, 1) => BufferFormat.Mono8,
                (8, 2) => BufferFormat.Stereo8,
                (16, 1) => BufferFormat.Mono16,
                (16, 2) => BufferFormat.Stereo16,
                _ => throw new Exception($"StreamingSoundSource does not support {_channels} channel with a bit-depth of {bitDepth}")
            };
            
            _bufferDataMethod = (buffer, pData) =>
                _al.BufferData(buffer, format, pData, _buffer.Length * sizeof(TBufferType), _sampleRate);
        }
    }

    public void Play(Action<TBufferType[]> bufferProvider)
    {
        _requestBuffer = bufferProvider;
        State = StreamState.Playing;

        for (int i = 0; i < _buffers.Length; i++)
        {
            PopulateBuffer(_buffers[i]);
        }
        _al.SourceQueueBuffers(_source, _buffers);
        _al.ThrowOnError();
        _al.SourcePlay(_source);
        _al.ThrowOnError();

    }

    public StreamState State { get; private set; }

    public unsafe void Update()
    {
        if (State != StreamState.Playing) return;

        _al.GetSourceProperty(_source, GetSourceInteger.BuffersProcessed, out var buffersProcessed);
        _al.ThrowOnError();

        if (buffersProcessed <= 0) return;

        while (buffersProcessed > 0)
        {
            buffersProcessed--;
            uint buffer;

            _al.SourceUnqueueBuffers(_source, 1, &buffer);
            _al.ThrowOnError();

            PopulateBuffer(buffer);

            _al.SourceQueueBuffers(_source, 1, &buffer);
            _al.ThrowOnError();
        }
    }

    unsafe delegate void BufferData(uint buffer, TBufferType* pData);

    private unsafe void PopulateBuffer(uint buffer)
    {
        Array.Fill(_buffer, _clearValue);
        _requestBuffer?.Invoke(_buffer);
        fixed (TBufferType* pData = _buffer)
        {
            _bufferDataMethod(buffer, pData);
        }
        _al.ThrowOnError();
    }
}

public enum StreamState
{
    Stopped,
    Playing,
    Paused
}

public class Sound : IDisposable
{
    private readonly AL _al;
    public uint Buffer { get; }
    public bool IsLooping { get; init; }

    public Sound(AL al)
    {
        _al = al;
        Buffer = al.GenBuffer();
        al.ThrowOnError();
    }

    public void Dispose()
    {
        _al.DeleteBuffer(Buffer);
    }
}

public class SoundSource : IDisposable
{
    private readonly AL _al;
    private readonly uint _source;

    public SoundSource(AL al)
    {
        _al = al;
        _source = al.GenSource();
        _al.ThrowOnError();
    }

    public void PlaySound(Sound sound)
    {
        _al.SetSourceProperty(_source, SourceBoolean.Looping, sound.IsLooping);
        _al.ThrowOnError();
        _al.SetSourceProperty(_source, SourceInteger.Buffer, sound.Buffer);
        _al.ThrowOnError();
        _al.SourcePlay(_source);
        _al.ThrowOnError();
    }

    public void Dispose()
    {
        _al.DeleteSource(_source);
    }
}


