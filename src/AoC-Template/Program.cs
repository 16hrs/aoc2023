using System.CommandLine;
using AdventOfCode2022.Running;
using AdventOfCode2022.Utilities;
using BenchmarkDotNet.Running;

namespace AdventOfCode2022;

internal class Program
{
    public static IEnumerable<Type> DayInputTypes = null!;
    public static IEnumerable<BaseChallengeFSharp> DayInputFSharp = null!;

    private static void Main(string[] args)
    {
        var langOption = new Option<string>("--lang", () => "c#", "The language to run in.");
        var daysOption = new Option<IEnumerable<int>>("--days", "The days to run.") {AllowMultipleArgumentsPerToken = true};
        var daysArgument = new Argument<IEnumerable<int>>("days", "The days to run.");
        
        var rootCommand = new RootCommand
        {
            langOption,
            daysOption,
        };
        rootCommand.SetHandler(RunWithBench, langOption, daysOption);
        
        var runCommand = new Command("run", "Run without benchmark.");
        runCommand.AddOption(langOption);
        runCommand.AddOption(daysOption);
        runCommand.SetHandler(RunWithoutBench, langOption, daysOption);
        
        var benchCommand = new Command("bench", "Run with benchmark.");
        benchCommand.AddOption(langOption);
        benchCommand.AddArgument(daysArgument);
        benchCommand.SetHandler(RunWithBench, langOption, daysArgument);
        
        rootCommand.AddCommand(runCommand);
        rootCommand.AddCommand(benchCommand);
        
        rootCommand.Invoke(args);
    }

    private static void RunWithBench(string lang, IEnumerable<int> days)
    {
        var daysList = days.ToList();
        switch (lang, daysList.Count)
        {
            case ("c#", 0):
                BenchmarkRunner.Run<BulkBenchCSharp>();
                break;
            case ("f#", 0):
                BenchmarkRunner.Run<BulkBenchFSharp>();
                break;
            case ("c#",_):
                DayInputTypes = GetTypes(daysList);
                BenchmarkRunner.Run<DayBenchCSharp>();
                break;
            case ("f#",_):
                DayInputFSharp = GetFSharpChallenges(daysList);
                BenchmarkRunner.Run<DayBenchFSharp>();
                break;
        }

        return;

        IEnumerable<Type> GetTypes(IEnumerable<int> days)
        {
            foreach (var day in days)
            {
                var type = ReflectionUtilities.GetChallengeType(day);
                if(type is null)
                    Console.WriteLine($"No challenge found for day {day}.");
                else
                    yield return type;
            }
        }

        IEnumerable<BaseChallengeFSharp> GetFSharpChallenges(IEnumerable<int> days)
        {
            List<(BaseChallengeFSharp challenge, int)> challenges = BulkBenchFSharp.Challenges().Select(c => (c, int.Parse(c.DayIdentifier))).ToList();
            foreach (var day in days)
            {
                var challenge = challenges.FirstOrDefault(c => c.Item2 == day).challenge;
                if(challenge is null) 
                    Console.WriteLine($"No challenge found for day {day}.");
                else
                    yield return challenge;
            }
        }
    }

    private static void RunWithoutBench(string lang, IEnumerable<int> days)
    {
        switch(lang)
        {
            case "c#":
                foreach (var day in days)
                {
                    var type = ReflectionUtilities.GetChallengeType(day);
                    if(type is null)
                        Console.WriteLine($"No challenge found for day {day}.");
                    else
                    {
                        var challenge = (BaseChallenge)Activator.CreateInstance(type)!;
                        Console.WriteLine($"Day {day} part 1: {challenge.SolvePartOne()}");
                        Console.WriteLine($"Day {day} part 2: {challenge.SolvePartTwo()}");
                    }
                }
                break;
            case "f#":
                throw new NotImplementedException("NYI");
                break;
        }
    }
}