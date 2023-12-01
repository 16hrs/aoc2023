using AdventOfCode2022.Running;
using System.Collections.Immutable;
using System.Globalization;

namespace AdventOfCode2022.Challenges;

public class Day1 : BaseChallenge
{
    private readonly string[] _input = LoadInput(File.ReadAllLines, nameof(Day1));

    public override string SolvePartOne() =>
        _input
            .Sum(
                x =>
                    int.Parse(
                        $"{x.First(char.IsNumber).ToString()}{x.Last(char.IsNumber).ToString()}"
                    )
            )
            .ToString();

    public override string SolvePartTwo()
    {
        var numbers = new HashSet<string>
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten"
        };
    }
}
