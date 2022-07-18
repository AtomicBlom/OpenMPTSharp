using OpenMPTSharp.Native;

namespace OpenMPTSharp;

public class OpenMPT
{
    public static Action<string>? Log;

    public static unsafe Version CoreVersion
    {
        get
        {
            var version = OpenMPTFunctions.openmpt_get_core_version();
            var revision = (version >> 0) & 0xFFFF;
            var build = (version >> 8) & 0xFFFF;
            var minor = (version >> 16) & 0xFFFF;
            var major = (version >> 24) & 0xFFFF;
            return new Version((int)major, (int)minor, (int)build, (int)revision);
        }
    }

    public static unsafe Version LibraryVersion
    {
        get
        {
            var version = OpenMPTFunctions.openmpt_get_library_version();
            var build = version & 0xFFFF;
            var minor = (version >> 16) & 0xFFFF;
            var major = (version >> 24) & 0xFFFF;
            return new Version((int)major, (int)minor, (int)build);
        }
    }

    public static unsafe bool IsRelease
    {
        get
        {
            using StringToPass versionIsRelease = "library_version_is_release";
            using ReturnedString result = OpenMPTFunctions.openmpt_get_string(versionIsRelease);
            return "1".Equals(result);
        }
    }

    public static unsafe string Features
    {
        get
        {
            using StringToPass features = "library_features";
            using ReturnedString result = OpenMPTFunctions.openmpt_get_string(features);
            return result;
        }
    }

    public static unsafe string[] SupportedExtensions
    {
        get
        {
            using ReturnedString result = OpenMPTFunctions.openmpt_get_supported_extensions();
            return ((string) result).Split(";");
        }
    }

    public unsafe Module CreateModuleFromMemory(ReadOnlySpan<byte> bytes)
    {
        fixed (void* dataPointer = &bytes.GetPinnableReference())
        {
            int result = 0;
            char* errorMessage;
            var handle = OpenMPTFunctions.openmpt_module_create_from_memory2(dataPointer, (nuint)bytes.Length, LogInternal, null, ErrorInternal, null,
                &result, &errorMessage, null);
            if (handle == default)
            {
                using ReturnedString error = errorMessage;
                throw new Exception(error);
            }
            //FIXME: Error handling
            return new Module(handle);
        }
    }

    private OpenMPTErrorFuncResult ErrorInternal(OpenMPTError error, IntPtr user)
    {
        return OpenMPTErrorFuncResult.Log | OpenMPTErrorFuncResult.Store;
    }

    private unsafe void LogInternal(char* message, IntPtr user)
    {
        using ReturnedString netMessage = message;
        Log?.Invoke(netMessage);
    }
}