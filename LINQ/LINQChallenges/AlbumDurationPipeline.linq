<Query Kind="Expression" />

//"2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
//	.Split(',')
//	.Select(s => 
//		{
//			int mins = int.Parse(s.Split(':')[0]);
//			int secs = int.Parse(s.Split(':')[1]);
//			
//			return mins * 60 + secs;
//		})
//	.Sum() / 60

"2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
	.Split(',')
	.Select(t => TimeSpan.Parse("0:" + t))
	.Aggregate((t1, t2) => t1 + t2)