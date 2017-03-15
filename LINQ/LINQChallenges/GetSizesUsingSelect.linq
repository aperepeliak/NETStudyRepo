<Query Kind="Program" />

void Main()
{
	var paths = new[] { "c:\\windows\\notepad.exe", "c:\\windows\\regedit.exe", "c:\\windows\\explorer.exe" };
	
	paths.Select(p => new FileInfo(p))
		 .ToDictionary(fi => fi.Name, fi => fi.Length)
		 .Dump();
	
	// GetListOfFileSizes(paths).Dump();
}


List<long> GetListOfFileSizes(IEnumerable<string> paths) 
{
	return 
		paths.Select(p => new FileInfo(p).Length)
			 .ToList();
}