using System.Runtime.InteropServices;

namespace OpenMPTSharp.Native;

internal readonly struct StringToPass : IDisposable
{
    private readonly IntPtr _charPtr;

    private StringToPass(string netString)
    {
        _charPtr = Marshal.StringToCoTaskMemUTF8(netString);
    }

    public static unsafe implicit operator char*(StringToPass p) => (char*)p._charPtr;
    public static implicit operator StringToPass(string p) => new(p);

    public void Dispose()
    {
        Marshal.FreeCoTaskMem(_charPtr);
    }
}