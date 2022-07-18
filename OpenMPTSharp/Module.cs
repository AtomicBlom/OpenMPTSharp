using OpenMPTSharp.Native;

namespace OpenMPTSharp;

public class Module : IDisposable
{
    private readonly unsafe OpenMPTFunctions.openmpt_module* _handle;

    internal unsafe Module(OpenMPTFunctions.openmpt_module* handle)
    {
        _handle = handle;
        using ReturnedString controls = OpenMPTFunctions.openmpt_module_get_ctls(handle);
        using ReturnedString metadata = OpenMPTFunctions.openmpt_module_get_metadata_keys(handle);
    }
    
    public unsafe void Dispose()
    {
        OpenMPTFunctions.openmpt_module_destroy(_handle);
    }

    public unsafe int CurrentOrder => OpenMPTFunctions.openmpt_module_get_current_order(_handle);
    public unsafe int CurrentPattern => OpenMPTFunctions.openmpt_module_get_current_pattern(_handle);
    public unsafe int CurrentRow => OpenMPTFunctions.openmpt_module_get_current_row(_handle);
    public unsafe int ActiveChannels => OpenMPTFunctions.openmpt_module_get_current_playing_channels(_handle);


    public unsafe int Read(int sampleRate, int length, Span<float> mono)
    {
        fixed (float* pMono = mono)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_float_mono(_handle, sampleRate, (nuint)length, pMono);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int Read(int sampleRate, int length, Span<float> left, Span<float> right, Span<float> rearLeft, Span<float> rearRight)
    {
        fixed (float* pLeft = left)
        fixed (float* pRight = right)
        fixed (float* pRearLeft = rearLeft)
        fixed (float* pRearRight = rearRight)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_float_quad(_handle, sampleRate, (nuint)length, pLeft, pRight, pRearLeft, pRearRight);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int Read(int sampleRate, int length, Span<float> left, Span<float> right)
    {
        fixed (float* pLeft = left)
        fixed (float* pRight = right)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_float_stereo(_handle, sampleRate, (nuint)length, pLeft, pRight);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int ReadInterleavedQuad(int sampleRate, Span<float> buffer, int length)
    {
        fixed (float* pBuffer = buffer)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_interleaved_float_quad(_handle, sampleRate, (nuint)length, pBuffer);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int ReadInterleavedStereo(int sampleRate, Span<float> buffer, int length)
    {
        fixed (float* pBuffer = buffer)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_interleaved_float_stereo(_handle, sampleRate, (nuint)length, pBuffer);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int ReadInterleavedQuad(int sampleRate, Span<short> buffer, int length)
    {
        fixed (Int16* pBuffer = buffer)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_interleaved_quad(_handle, sampleRate, (nuint)length, pBuffer);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int ReadInterleavedStereo(int sampleRate, Span<short> buffer, int length)
    {
        fixed (Int16* pBuffer = buffer)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_interleaved_stereo(_handle, sampleRate, (nuint)length, pBuffer);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int Read(int sampleRate, int length, Span<short> mono)
    {
        fixed (short* pMono = mono)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_mono(_handle, sampleRate, (nuint)length, pMono);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int Read(int sampleRate, int length, Span<short> left, Span<short> right, Span<short> rearLeft, Span<short> rearRight)
    {
        fixed (short* pLeft = left)
        fixed (short* pRight = right)
        fixed (short* pRearLeft = rearLeft)
        fixed (short* pRearRight = rearRight)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_quad(_handle, sampleRate, (nuint)length, pLeft, pRight, pRearLeft, pRearRight);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }

    public unsafe int Read(int sampleRate, int length, Span<short> left, Span<short> right)
    {
        fixed (short* pLeft = left)
        fixed (short* pRight = right)
        {
            var frames = OpenMPTFunctions.openmpt_module_read_stereo(_handle, sampleRate, (nuint)length, pLeft, pRight);
            using ReturnedString result = OpenMPTFunctions.openmpt_module_error_get_last_message(_handle);
            if (!string.IsNullOrEmpty(result))
            {
                throw new OpenMPTException(result);
            }

            return (int)frames;
        }
    }
}