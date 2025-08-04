namespace OpenMPTSharp.Native;

internal enum OpenMPTError
{
	Ok = 0,
	Base = 256,
	ArgumentNullPointer = Base + 103,
	Domain = Base + 41,
	Exception = Base + 11,
	General = Base + 101,
	InvalidArgument = Base + 44,
	InvalidModulePointer = Base + 102,
	Length = Base + 42,
	Logic = Base + 40,
	OutOfMemory = Base + 21,
	OutOfRange = Base + 43,
	Overflow = Base + 32,
	Range = Base + 31,
	Runtime = Base + 30,
	Underflow = Base + 33,
	Unknown = Base + 1
}