<Query Kind="Expression" />

"10, 5, 0, 8, 10, 1, 4, 0, 10, 1"
	.Split(',')
	.Select(s => int.Parse(s))
	.OrderBy(s => s)
	.Skip(3)
	.Sum()