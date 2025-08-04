namespace OpenMPTSharp.Native;

[Flags]
internal enum OpenMPTFileHeaderFlags : ulong
{
	None = 0,
	Containers = 2,
	Modules = 1,
	Default = Modules | Containers,
}