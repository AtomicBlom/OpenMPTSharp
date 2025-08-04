using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenMPTSharp.Native;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "BuiltInTypeReferenceStyle")]
internal class OpenMPTFunctions
{
    
    internal delegate OpenMPTErrorFuncResult openmpt_error_func(OpenMPTError error, IntPtr user);
    internal unsafe delegate void openmpt_log_func(char* message, IntPtr user);
    internal struct openmpt_module { }
    internal struct openmpt_module_initial_ctl { }
    // WONTADD: openmpt_stream_buffer - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_callbacks - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_read_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_seek_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_tell_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_could_open_probability - Deprecated, @see openmpt_could_open_probability2
    //openmpt_could_open_probability2
    // WONTADD: openmpt_could_open_propability - Deprecated, @see openmpt_could_open_probability2
    // WONTADD: openmpt_error_func_default - Not needed
    //openmpt_error_func_errno
    //openmpt_error_func_errno_userdata
    // WONTADD: openmpt_error_func_ignore
    // WONTADD: openmpt_error_func_log
    // WONTADD: openmpt_error_func_store

    internal static readonly unsafe delegate* unmanaged[Cdecl]<int, int> openmpt_error_is_transient;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<int, char*> openmpt_error_string;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<char*, void> openmpt_free_string;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<uint> openmpt_get_core_version;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<uint> openmpt_get_library_version;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<char*, char*> openmpt_get_string;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<char*> openmpt_get_supported_extensions;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<char*, int> openmpt_is_extension_supported;

    // WONTADD: openmpt_log_func_default
    // WONTADD: openmpt_log_func_silent

    // WONTADD: openmpt_module_create - Deprecated
    // WONTADD: openmpt_module_create2 - No support for C++ streams
    // WONTADD: openmpt_module_create_from_memory - Deprecated, @see openmpt_module_create_from_memory2
    internal static readonly unsafe delegate* unmanaged[Cdecl]<void*, nuint, openmpt_log_func, void*, openmpt_error_func, void*, int*, char**, void*, openmpt_module*> openmpt_module_create_from_memory2;
    // WONTADD: openmpt_module_ctl_get - Deprecated;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, int> openmpt_module_ctl_get_boolean;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, double> openmpt_module_ctl_get_floatingpoint;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, Int64> openmpt_module_ctl_get_integer;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, char*> openmpt_module_ctl_get_text;
    // WONTADD: openmpt_module_ctl_set - Deprecated;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, int, int> openmpt_module_ctl_set_boolean;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, double, int> openmpt_module_ctl_set_floatingpoint;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, Int64, int> openmpt_module_ctl_set_integer;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, char*, int> openmpt_module_ctl_set_text;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, void> openmpt_module_destroy;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, void> openmpt_module_error_clear;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, OpenMPTError> openmpt_module_error_get_last;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*> openmpt_module_error_get_last_message;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, OpenMPTError, void> openmpt_module_error_set_last;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, nuint, int, char*> openmpt_module_format_pattern_row_channel;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, int, char*> openmpt_module_format_pattern_row_channel_command;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*> openmpt_module_get_channel_name;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*> openmpt_module_get_ctls;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float> openmpt_module_get_current_channel_vu_left;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float> openmpt_module_get_current_channel_vu_mono;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float> openmpt_module_get_current_channel_vu_rear_left;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float> openmpt_module_get_current_channel_vu_rear_right;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float> openmpt_module_get_current_channel_vu_right;
    
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_current_order;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_current_pattern;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_current_playing_channels;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_current_row;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_current_speed;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_current_tempo;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, double> openmpt_module_get_duration_seconds;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*> openmpt_module_get_instrument_name;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*, char*> openmpt_module_get_metadata;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, char*> openmpt_module_get_metadata_keys;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_num_channels;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_num_instruments;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_num_orders;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_num_patterns;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_num_samples;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_num_subsongs;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*> openmpt_module_get_order_name;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32> openmpt_module_get_order_pattern;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*> openmpt_module_get_pattern_name;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32> openmpt_module_get_pattern_num_rows;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, int, char> openmpt_module_get_pattern_row_channel_command; //FIXME: int -> PatternCellIndex
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, double> openmpt_module_get_position_seconds;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, int, Int32, int> openmpt_module_get_render_param; //FIXME: Param -> RenderParamIndex
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_repeat_count;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*> openmpt_module_get_sample_name;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32> openmpt_module_get_selected_subsong;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*> openmpt_module_get_subsong_name;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, nuint, int, char*> openmpt_module_highlight_pattern_row_channel; //FIXME: int -> PatternCellIndex
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, int, char*> openmpt_module_highlight_pattern_row_channel_command; //FIXME: int -> PatternCellIndex
    
    /// ///////// Read Operations
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, nuint> openmpt_module_read_float_mono;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, float*, float*, float*, nuint> openmpt_module_read_float_quad;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, float*, nuint> openmpt_module_read_float_stereo;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, nuint> openmpt_module_read_interleaved_float_quad;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, nuint> openmpt_module_read_interleaved_float_stereo;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, nuint> openmpt_module_read_interleaved_quad;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, nuint> openmpt_module_read_interleaved_stereo;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, nuint> openmpt_module_read_mono;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, Int16*, Int16*, Int16*, nuint> openmpt_module_read_quad;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, Int16*, nuint> openmpt_module_read_stereo;

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, int> openmpt_module_select_subsong;

    // WONTADD: openmpt_module_set_error_func - Probably unnecessary, just use the constructor method
    // WONTADD: openmpt_module_set_log_func - Probably unnecessary, just use the constructor method

    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, double> openmpt_module_set_position_order_row;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, double, double> openmpt_module_set_position_seconds;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, int, Int32, int> openmpt_module_set_render_param; //FIXME: int -> Render Param indices
    internal static readonly unsafe delegate* unmanaged[Cdecl]<openmpt_module*, Int32, int> openmpt_module_set_repeat_count;

    //FIXME: first parameter should be ProbeHeaderFiles, which should be a uint64
    //FIXME: returns ProbeFileHeaderResult
    internal static readonly unsafe delegate* unmanaged[Cdecl]<OpenMPTFileHeaderFlags, void*, nuint, UInt64, openmpt_log_func, void*, openmpt_error_func, void*, int*, char**, OpenMPTFileHeaderResult> openmpt_probe_file_header;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<nuint> openmpt_probe_file_header_get_recommended_size;
    internal static readonly unsafe delegate* unmanaged[Cdecl]<OpenMPTFileHeaderFlags, void*, nuint, UInt64, openmpt_log_func, void*, openmpt_error_func, void*, int*, char**, OpenMPTFileHeaderResult> openmpt_probe_file_header_without_filesize;

    // WONTADD: openmpt_stream_buffer_init - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_buffer_read_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_buffer_seek_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_buffer_tell_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_fd_read_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_file_read_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_file_seek_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_file_tell_func - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_get_buffer_callbacks - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_get_fd_callbacks - Will be using Spans instead of C++ streams
    // WONTADD: openmpt_stream_get_file_callbacks - Will be using Spans instead of C++ streams

    static unsafe OpenMPTFunctions()
    {
        var handle = NativeLibrary.Load("libopenmpt", typeof(OpenMPTFunctions).Assembly, DllImportSearchPath.AssemblyDirectory);

        openmpt_error_is_transient = (delegate* unmanaged[Cdecl]<int, int>)NativeLibrary.GetExport(handle, "openmpt_error_is_transient");
        openmpt_error_string = (delegate* unmanaged[Cdecl]<int, char*>)NativeLibrary.GetExport(handle, "openmpt_error_string");
        openmpt_free_string = (delegate* unmanaged[Cdecl]<char*, void>)NativeLibrary.GetExport(handle, "openmpt_free_string");

        openmpt_get_core_version = (delegate* unmanaged[Cdecl]<uint>)NativeLibrary.GetExport(handle, "openmpt_get_core_version");
        openmpt_get_library_version = (delegate* unmanaged[Cdecl]<uint>)NativeLibrary.GetExport(handle, "openmpt_get_library_version");
        openmpt_get_string = (delegate* unmanaged[Cdecl]<char*, char*>)NativeLibrary.GetExport(handle, "openmpt_get_string");
        openmpt_get_supported_extensions = (delegate* unmanaged[Cdecl]<char*>)NativeLibrary.GetExport(handle, "openmpt_get_supported_extensions");
        openmpt_is_extension_supported = (delegate* unmanaged[Cdecl]<char*, int>)NativeLibrary.GetExport(handle, "openmpt_is_extension_supported");

        openmpt_module_create_from_memory2 = (delegate* unmanaged[Cdecl]<void*, nuint, openmpt_log_func, void*, openmpt_error_func, void*, int*, char**, void*, openmpt_module*>)NativeLibrary.GetExport(handle, "openmpt_module_create_from_memory2");

        openmpt_module_ctl_get_boolean = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, int>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_get_boolean");
        openmpt_module_ctl_get_floatingpoint = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, double>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_get_floatingpoint");
        openmpt_module_ctl_get_integer = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, Int64>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_get_integer");
        openmpt_module_ctl_get_text = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, char*>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_get_text");

        openmpt_module_ctl_set_boolean = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, int, int>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_set_boolean");
        openmpt_module_ctl_set_floatingpoint = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, double, int>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_set_floatingpoint");
        openmpt_module_ctl_set_integer = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, Int64, int>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_set_integer");
        openmpt_module_ctl_set_text = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, char*, int>)NativeLibrary.GetExport(handle, "openmpt_module_ctl_set_text");

        openmpt_module_destroy = (delegate* unmanaged[Cdecl]<openmpt_module*, void>)NativeLibrary.GetExport(handle, "openmpt_module_destroy");
        openmpt_module_error_clear = (delegate* unmanaged[Cdecl]<openmpt_module*, void>)NativeLibrary.GetExport(handle, "openmpt_module_error_clear");
        openmpt_module_error_get_last = (delegate* unmanaged[Cdecl]<openmpt_module*, OpenMPTError>)NativeLibrary.GetExport(handle, "openmpt_module_error_get_last");
        openmpt_module_error_get_last_message = (delegate* unmanaged[Cdecl]<openmpt_module*, char*>)NativeLibrary.GetExport(handle, "openmpt_module_error_get_last_message");
        openmpt_module_error_set_last = (delegate* unmanaged[Cdecl]<openmpt_module*, OpenMPTError, void>)NativeLibrary.GetExport(handle, "openmpt_module_error_set_last");

        openmpt_module_format_pattern_row_channel = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, nuint, int, char*>)NativeLibrary.GetExport(handle, "openmpt_module_format_pattern_row_channel");
        openmpt_module_format_pattern_row_channel_command = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, int, char*>)NativeLibrary.GetExport(handle, "openmpt_module_format_pattern_row_channel_command");
        openmpt_module_get_channel_name = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_channel_name");
        openmpt_module_get_ctls = (delegate* unmanaged[Cdecl]<openmpt_module*, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_ctls");

        openmpt_module_get_current_channel_vu_left = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_channel_vu_left");
        openmpt_module_get_current_channel_vu_mono = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_channel_vu_mono");
        openmpt_module_get_current_channel_vu_rear_left = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_channel_vu_rear_left");
        openmpt_module_get_current_channel_vu_rear_right = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_channel_vu_rear_right");
        openmpt_module_get_current_channel_vu_right = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, float>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_channel_vu_right");

        openmpt_module_get_current_order = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_order");
        openmpt_module_get_current_pattern = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_pattern");
        openmpt_module_get_current_playing_channels = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_playing_channels");
        openmpt_module_get_current_row = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_row");
        openmpt_module_get_current_speed = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_speed");
        openmpt_module_get_current_tempo = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_current_tempo");
        openmpt_module_get_duration_seconds = (delegate* unmanaged[Cdecl]<openmpt_module*, double>)NativeLibrary.GetExport(handle, "openmpt_module_get_duration_seconds");

        openmpt_module_get_instrument_name = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_instrument_name");
        openmpt_module_get_metadata = (delegate* unmanaged[Cdecl]<openmpt_module*, char*, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_metadata");
        openmpt_module_get_metadata_keys = (delegate* unmanaged[Cdecl]<openmpt_module*, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_metadata_keys");

        openmpt_module_get_num_channels = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_num_channels");
        openmpt_module_get_num_instruments = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_num_instruments");
        openmpt_module_get_num_orders = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_num_orders");
        openmpt_module_get_num_patterns = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_num_patterns");
        openmpt_module_get_num_samples = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_num_samples");
        openmpt_module_get_num_subsongs = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_num_subsongs");
        openmpt_module_get_order_name = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_order_name");
        openmpt_module_get_order_pattern = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_order_pattern");
        openmpt_module_get_pattern_name = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_pattern_name");
        openmpt_module_get_pattern_num_rows = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_pattern_num_rows");
        openmpt_module_get_pattern_row_channel_command = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, int, char>)NativeLibrary.GetExport(handle, "openmpt_module_get_pattern_row_channel_command");

        openmpt_module_get_position_seconds = (delegate* unmanaged[Cdecl]<openmpt_module*, double>)NativeLibrary.GetExport(handle, "openmpt_module_get_position_seconds");
        openmpt_module_get_render_param = (delegate* unmanaged[Cdecl]<openmpt_module*, int, Int32, int>)NativeLibrary.GetExport(handle, "openmpt_module_get_render_param");
        openmpt_module_get_repeat_count = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_repeat_count");
        openmpt_module_get_sample_name = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_sample_name");
        openmpt_module_get_selected_subsong = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32>)NativeLibrary.GetExport(handle, "openmpt_module_get_selected_subsong");
        openmpt_module_get_subsong_name = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, char*>)NativeLibrary.GetExport(handle, "openmpt_module_get_subsong_name");

        openmpt_module_highlight_pattern_row_channel = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, nuint, int, char*>)NativeLibrary.GetExport(handle, "openmpt_module_highlight_pattern_row_channel");
        openmpt_module_highlight_pattern_row_channel_command = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, Int32, int, char*>)NativeLibrary.GetExport(handle, "openmpt_module_highlight_pattern_row_channel_command");

        openmpt_module_read_float_mono = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_float_mono");
        openmpt_module_read_float_quad = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, float*, float*, float*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_float_quad");
        openmpt_module_read_float_stereo = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, float*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_float_stereo");
        openmpt_module_read_interleaved_float_quad = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_interleaved_float_quad");
        openmpt_module_read_interleaved_float_stereo = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, float*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_interleaved_float_stereo");
        openmpt_module_read_interleaved_quad = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_interleaved_quad");
        openmpt_module_read_interleaved_stereo = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_interleaved_stereo");
        openmpt_module_read_mono = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_mono");
        openmpt_module_read_quad = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, Int16*, Int16*, Int16*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_quad");
        openmpt_module_read_stereo = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, nuint, Int16*, Int16*, nuint>)NativeLibrary.GetExport(handle, "openmpt_module_read_stereo");

        openmpt_module_select_subsong = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, int>)NativeLibrary.GetExport(handle, "openmpt_module_select_subsong");

        openmpt_module_set_position_order_row = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, Int32, double>)NativeLibrary.GetExport(handle, "openmpt_module_set_position_order_row");
        openmpt_module_set_position_seconds = (delegate* unmanaged[Cdecl]<openmpt_module*, double, double>)NativeLibrary.GetExport(handle, "openmpt_module_set_position_seconds");
        openmpt_module_set_render_param = (delegate* unmanaged[Cdecl]<openmpt_module*, int, Int32, int>)NativeLibrary.GetExport(handle, "openmpt_module_set_render_param");
        openmpt_module_set_repeat_count = (delegate* unmanaged[Cdecl]<openmpt_module*, Int32, int>)NativeLibrary.GetExport(handle, "openmpt_module_set_repeat_count");

        openmpt_probe_file_header = (delegate* unmanaged[Cdecl]<OpenMPTFileHeaderFlags, void*, nuint, UInt64, openmpt_log_func, void*, openmpt_error_func, void*, int*, char**, OpenMPTFileHeaderResult>)NativeLibrary.GetExport(handle, "openmpt_probe_file_header");
        openmpt_probe_file_header_get_recommended_size = (delegate* unmanaged[Cdecl]<nuint>)NativeLibrary.GetExport(handle, "openmpt_probe_file_header_get_recommended_size");
        openmpt_probe_file_header_without_filesize = (delegate* unmanaged[Cdecl]<OpenMPTFileHeaderFlags, void*, nuint, UInt64, openmpt_log_func, void*, openmpt_error_func, void*, int*, char**, OpenMPTFileHeaderResult>)NativeLibrary.GetExport(handle, "openmpt_probe_file_header_without_filesize");
    }
}
