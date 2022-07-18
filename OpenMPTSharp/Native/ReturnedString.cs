using System.Runtime.InteropServices;

namespace OpenMPTSharp.Native;

internal readonly struct ReturnedString : IDisposable
{
    private readonly unsafe char* _charPtr;
    public readonly string String;

    private unsafe ReturnedString(char* openMptString)
    {
        _charPtr = openMptString;
        if (_charPtr == default)
        {
            String = string.Empty;
        }
        else
        {
            String = Marshal.PtrToStringUTF8((IntPtr) _charPtr) ?? string.Empty;
        }
    }

    public static implicit operator string(ReturnedString p) => p.String;
    public static unsafe implicit operator ReturnedString(char* p) => new(p);

    public unsafe void Dispose()
    {
        OpenMPTFunctions.openmpt_free_string(_charPtr);
    }
}