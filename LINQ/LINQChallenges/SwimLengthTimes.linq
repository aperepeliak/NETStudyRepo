<Query Kind="Program" />

void Main()
{
	"00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35"
		.Split(',')
		.Select(s => TimeSpan.Parse("00:" + s))
		.GetLengths()
		.Dump();
}

public static class MyExtensions 
{
	public static IEnumerable<TimeSpan> GetLengths(this IEnumerable<TimeSpan> source)
	{
		List<TimeSpan> lengths = new List<TimeSpan>();
		
		TimeSpan prev = TimeSpan.Zero;
		foreach(TimeSpan i in source)
		{
			lengths.Add(i - prev);
			prev = i;
		}
		
		return lengths;
	}
}