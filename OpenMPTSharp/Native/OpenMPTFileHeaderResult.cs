namespace OpenMPTSharp.Native;

internal enum OpenMPTFileHeaderResult
{
	Success = 1,
	Failure = 0,
	Error = -255,
	WantMoreData = -1
}