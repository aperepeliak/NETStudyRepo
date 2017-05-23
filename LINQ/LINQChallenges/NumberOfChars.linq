<Query Kind="Program" />

void Main()
{
	Dictionary<char, int> result = "abbcdedda".CountLetters();	
	result.Dump();
}

public static class Extensions 
{
	public static Dictionary<char, int> CountLetters(this string input)
	{
		Dictionary<char, int> output = new Dictionary<char, int>();
		
		foreach(var c in input)
		{
			if(!output.Keys.Contains(c))
				output.Add(c, input.Count(ch => ch == c));
		}
		
		return output;
	}
}

