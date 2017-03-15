<Query Kind="Program" />

void Main()
{
	"Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
		.Split(';')
		.Select(s => new { Player = s.Split(',')[0].Trim(), DateOfBirth = DateTime.Parse(s.Split(',')[1]) })
		.OrderByDescending(p => p.DateOfBirth)
		.Select(p => new { Player = p.Player, Age = GetAge(p.DateOfBirth)} )
		.Dump();
}

static int GetAge(DateTime dateOfBirth) 
{
	DateTime today = DateTime.Today;
	int age = today.Year - dateOfBirth.Year;
	if(dateOfBirth > today.AddYears(-age)) age--;
	return age;
}