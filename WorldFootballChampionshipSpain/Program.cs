using WorldFootballChampionshipSpain.DAL;
using WorldFootballChampionshipSpain.DAL.Enteties;

namespace WorldFootballChampionshipSpain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teamRepos = new TeamRepository();
            while (true)
            {
                Console.WriteLine("1 - Add team\n2 - See teams\n3 - If you want to delete team\n4 - If you want to change information about team\n5 - Find info with team name\n6 - Find teams in city\n7 - Find team by name and city\n8 - To see the stats who is better in what");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    if (teamRepos.GetByName(name.ToUpper()) != null)
                    {
                        Console.WriteLine("Team is already in");
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }

                    Console.Write("Enter city: ");
                    string city = Console.ReadLine();

                    Console.Write("Enter wins: ");
                    int wins = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter loses: ");
                    int loses = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter draws: ");
                    int draws = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter scored goals: ");
                    int scoredGoals = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter lost goals: ");
                    int lostGoals = Convert.ToInt32(Console.ReadLine());

                    var team = new Team
                    {
                        TeamName = name,
                        City = city,
                        Wins = wins,
                        Loses = lostGoals,
                        Draws = draws,
                        ScoredGoals = scoredGoals,
                        LostGoals = lostGoals
                    };
                    
                    teamRepos.Add(team);
                    Console.WriteLine("Team added successfully!");
                    Thread.Sleep(1000);
                }
                else if (a == 2)
                {
                    var teams = teamRepos.GetAll();
                    foreach (var t in teams)
                    {
                        Console.WriteLine($"{t.TeamName}:\n\tCity: {t.City}\n\tWins: {t.Wins}\n\tLoses: {t.Loses}\n\tDraws: {t.Draws}\n\tScored goals: {t.ScoredGoals}\n\tLost goals: {t.LostGoals}\n\tTotal games played: {t.Wins+ t.Loses+ t.Draws}");
                    }
                    Console.ReadLine();
                }
                else if (a == 3)
                {
                    Console.Write("Enter team name to delete: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter city: ");
                    string city = Console.ReadLine();

                    var team = teamRepos.GetByNameCity(name, city);
                    if (team != null)
                    {

                        teamRepos.Delete(team);
                        Console.WriteLine("Team deleted successfully!");
                    }
                    else
                        Console.WriteLine("Team was not found.");
                    Thread.Sleep(1000);
                }
                else if(a == 4)
                {
                    Console.Write("Enter team name which you want to update: ");
                    string t = Console.ReadLine().ToString();
                    var team = teamRepos.GetByName(t);

                    if (team != null)
                    {
                        Console.Write($"Enter new name ({team.TeamName}): ");
                        string? input = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(input))
                            team.TeamName = input;

                        Console.Write($"City ({team.City}): ");
                        input = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(input))
                            team.City = input;

                        Console.Write($"Wins ({team.Wins}): ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out int wins))
                            team.Wins = wins;

                        Console.Write($"Loses ({team.Loses}): ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out int loses))
                            team.Loses = loses;

                        Console.Write($"Draws ({team.Draws}): ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out int draws))
                            team.Draws = draws;

                        Console.Write($"Scored goals ({team.ScoredGoals}): ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out int scored))
                            team.ScoredGoals = scored;

                        Console.Write($"Lost goals ({team.LostGoals}): ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out int lost))
                            team.LostGoals = lost;

                        teamRepos.Update(team);
                        Console.WriteLine("Info have been changed successfully");
                    }
                    else
                        Console.WriteLine("Team was not found");
                    Thread.Sleep(1000);
                }
                else if (a == 5)
                {
                    Console.Write("Enter team name - ");
                    string t = Console.ReadLine().ToString();
                    var ch = teamRepos.GetByName(t);
                    if (ch != null)
                    {
                        Console.WriteLine($"{ch.TeamName}:\n\tCity: {ch.City}\n\tWins: {ch.Wins}\n\tLoses: {ch.Loses}\n\tDraws: {ch.Draws}\n\tScored goals: {ch.ScoredGoals}\n\tLost goals: {ch.LostGoals}\n\tTotal games played: {ch.Wins + ch.Loses + ch.Draws}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"There is no team with this name {t}");
                        Thread.Sleep(1000);
                    }
                }
                else if (a == 6)
                {
                    Console.Write("Enter from which city you want to find team(s): ");
                    string c = Console.ReadLine();
                    var teams = teamRepos.GetAllByCity(c);
                    if (teams != null)
                    {
                        foreach(var t in teams)
                        {
                            Console.WriteLine($"{t.TeamName}:\n\tCity: {t.City}\n\tWins: {t.Wins}\n\tLoses: {t.Loses}\n\tDraws: {t.Draws}\n\tScored goals: {t.ScoredGoals}\n\tLost goals: {t.LostGoals}\n\tTotal games played: {t.Wins + t.Loses + t.Draws}");
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"There is no teams in {c}");
                        Thread.Sleep(1000);
                    }    
                    
                }
                else if(a == 7)
                {
                    Console.Write("Enter team name - ");
                    string n = Console.ReadLine();

                    Console.Write("Enter city - ");
                    string c = Console.ReadLine();

                    var team = teamRepos.GetByNameCity(n, c);
                    if (team != null)
                    {
                        Console.WriteLine($"{team.TeamName}:\n\tCity: {team.City}\n\tWins: {team.Wins}\n\tLoses: {team.Loses}\n\tDraws: {team.Draws}\n\tScored goals: {team.ScoredGoals}\n\tLost goals: {team.LostGoals}\n\tTotal games played: {team.Wins + team.Loses + team.Draws}");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"There is no team with that name and city({n}, {c}");
                        Thread.Sleep(1000);
                    }
                }
                else if(a == 8)
                {
                    var teams = teamRepos.GetAll();
                    if (teams != null)
                    {
                        var mostWins = teams.OrderByDescending(t => t.Wins).First();
                        var mostLoses = teams.OrderByDescending(t => t.Loses).First();
                        var mostDraws = teams.OrderByDescending(t => t.Draws).First();
                        var mostScoredGoals = teams.OrderByDescending(t => t.ScoredGoals).First();
                        var mostLostGoals = teams.OrderByDescending(t => t.LostGoals).First();

                        Console.WriteLine($"Most wins: {mostWins.TeamName} ({mostWins.Wins})");
                        Console.WriteLine($"Most loses: {mostLoses.TeamName} ({mostLoses.Loses})");
                        Console.WriteLine($"Most draws: {mostDraws.TeamName} ({mostDraws.Draws})");
                        Console.WriteLine($"Most scored goals: {mostScoredGoals.TeamName} ({mostScoredGoals.ScoredGoals})");
                        Console.WriteLine($"Most lost goals: {mostLostGoals.TeamName} ({mostLostGoals.LostGoals})");

                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("There is no teams");
                        Thread.Sleep(1000);
                    }
                }

                    Console.Clear();
            }
        }
    }
}
        /*Console.Write("Enter name or age or email of the student which you want to delete - ");
        string ch = Console.ReadLine();
        foreach (var s in context.Students.ToList())
        {
            if (s.Name == ch || s.age.ToString() == ch || s.Email == ch)
            {
                context.Remove(s);
                context.SaveChanges();
                break;
            }
            else if (s.Id == context.Students.Max(s => s.Id))
            {
                Console.WriteLine("Student wasn't found");
            }
        }*//*
        Console.Write("Enter student ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var student = studentRepos.GetById(id);
        if (student != null)
        {
            studentRepos.Delete(student);
            Console.WriteLine("Student deleted successfully!");
        }
        else
            Console.WriteLine("Student not found.");
        Thread.Sleep(1000);
    }
    else if (a == 4)
    {
        Console.Write("Enter student ID to update: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var student = studentRepos.GetById(id);

        if (student != null)
        {
            Console.Write("Enter new name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter new age: ");
            student.age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new email: ");
            student.Email = Console.ReadLine();

            studentRepos.Update(student);
            Console.WriteLine("Student updated successfully!");
        }
        else
            Console.WriteLine("Student not found.");
        Thread.Sleep(1000);
    }
    else
        break;
    Console.Clear();
        }
    }
}




/*var studentRepos = new StudentRepository();
*//*var student = new Student
{
    Name = "Arkadii",
    age = 16,
    Email = "xcd@gmail.com"
};*/
/*context.Students.Add(student);
context.SaveChanges();*//*
//var students = context.Students.ToList();
while (true)
{
    Console.WriteLine("1 - Enter data\n2 - See data\n3 - If you want to delete student\n4 - If you want to change information about student");
    int a = Convert.ToInt32(Console.ReadLine());
    if (a == 1)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter birth date;");
        DateTime date = new DateTime(1, 2, 3);
        while (true)
        {
            Console.Write("Day: ");
            int d = Convert.ToInt32(Console.ReadLine());
            if (d > 0 && d <= 31)
                date = new DateTime(date.Year, date.Month, d);
            else
                continue;

            Console.Write("Month: ");
            d = Convert.ToInt32(Console.ReadLine());
            if (d > 0 && d <= 12)
                date = new DateTime(date.Year, d, date.Day);
            else
                continue;

            Console.Write("Year: ");
            d = Convert.ToInt32(Console.ReadLine());
            if (d > 0 && a < DateTime.Now.Year)
                date = new DateTime(d, date.Month, date.Day);
            else
                continue;
            break;
        }
        var student = new Student
        {
            Name = name,
            age = age,
            Email = email,
            Date = date
        };
        studentRepos.Add(student);
        Console.WriteLine("Student added successfully!");
        Thread.Sleep(1000);
    }
    else if (a == 2)
    {
        var students = studentRepos.GetAll();
        foreach (var s in students)
        {

            Console.WriteLine($"{s.Id}: {s.Name} {s.age} {s.Email}  Birthday: {s.Date.Day}.{s.Date.Month}.{s.Date.Year}");
        }
        Console.ReadLine();
    }
    else if (a == 3)
    {
        *//*Console.Write("Enter name or age or email of the student which you want to delete - ");
        string ch = Console.ReadLine();
        var studentsDb = context.Students.ToList();
        var remove = studentsDb
            .Where(s => s.Name == ch || s.age.ToString() == ch || s.Email == ch)
            .ToList();
        context.RemoveRange(remove);
        context.SaveChanges();*/
/*Console.Write("Enter name or age or email of the student which you want to delete - ");
string ch = Console.ReadLine();
foreach (var s in context.Students.ToList())
{
    if (s.Name == ch || s.age.ToString() == ch || s.Email == ch)
    {
        context.Remove(s);
        context.SaveChanges();
        break;
    }
    else if (s.Id == context.Students.Max(s => s.Id))
    {
        Console.WriteLine("Student wasn't found");
    }
}*//*
Console.Write("Enter student ID to delete: ");
int id = Convert.ToInt32(Console.ReadLine());
var student = studentRepos.GetById(id);
if (student != null)
{
    studentRepos.Delete(student);
    Console.WriteLine("Student deleted successfully!");
}
else
    Console.WriteLine("Student not found.");
Thread.Sleep(1000);
}
else if (a == 4)
{
Console.Write("Enter student ID to update: ");
int id = Convert.ToInt32(Console.ReadLine());
var student = studentRepos.GetById(id);

if (student != null)
{
    Console.Write("Enter new name: ");
    student.Name = Console.ReadLine();

    Console.Write("Enter new age: ");
    student.age = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter new email: ");
    student.Email = Console.ReadLine();

    studentRepos.Update(student);
    Console.WriteLine("Student updated successfully!");
}
else
    Console.WriteLine("Student not found.");
Thread.Sleep(1000);
}
else
break;
Console.Clear();
}*/