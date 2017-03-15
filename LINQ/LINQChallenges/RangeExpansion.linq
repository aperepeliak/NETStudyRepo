<Query Kind="Expression" />

// "6,1-3,2-4"
"2,5,7-10,11,17-18"
	.Split(',')
	.Select(x => x.Split('-'))
	.Select(p => new { First = int.Parse(p[0]), Last = int.Parse(p.Last()) })
	.SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
	.OrderBy(r => r)
	.Distinct()