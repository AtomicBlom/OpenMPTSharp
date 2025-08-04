namespace OpenMPTSharp.Native;

[Flags]
internal enum OpenMPTErrorFuncResult
{
	None = 0,
	Log = 1 << 0,
	Store = 1 << 1,
	Default = Log | Store
}