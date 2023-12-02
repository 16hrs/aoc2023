using AdventOfCode2022.Running;
using System.Collections.Frozen;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Challenges;

/// BenchmarkDotNet v0.13.10, Windows 11 (10.0.22621.2715/22H2/2022Update/SunValley2)
/// 12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
/// .NET SDK 8.0.100
/// [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
/// DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
/// | Method   | Challenge            | Mean     | Error   | StdDev  | Allocated |
/// |--------- |--------------------- |---------:|--------:|--------:|----------:|
/// | 'Part 1' | Adven(...).Day1 [32] | 120.7 us | 1.34 us | 1.25 us | 140.69 KB |
/// | 'Part 2' | Adven(...).Day1 [32] | 181.7 us | 0.86 us | 0.80 us |    569 KB |
public partial class Day1 : BaseChallenge
{
    private const string Pattern = @"(one|two|three|four|five|six|seven|eight|nine|\d)";

    private static readonly FrozenDictionary<string, string> Nums = new Dictionary<string, string>
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" }
    }.ToFrozenDictionary();

    private readonly string[] _input = LoadInput(File.ReadAllLines, nameof(Day1));

    public override string SolvePartOne() =>
        _input
            .Sum(
                selector: x =>
                    int.Parse(
                        $"{x.First(char.IsNumber).ToString()}{x.Last(char.IsNumber).ToString()}"
                    )
            )
            .ToString();

    public override string SolvePartTwo() =>
        _input
            .Select(selector: x =>
            {
                var firstMatchValue = LeftToRight().Match(x).Value;
                var lastMatchValue = RightToLeft().Match(x).Value;

                var first = Nums.GetValueOrDefault(firstMatchValue, firstMatchValue);
                var last = Nums.GetValueOrDefault(lastMatchValue, lastMatchValue);

                return int.Parse($"{first}{last}");
            })
            .Sum()
            .ToString();

    [GeneratedRegex(Pattern)]
    private static partial Regex LeftToRight();

    [GeneratedRegex(Pattern, RegexOptions.RightToLeft)]
    private static partial Regex RightToLeft();
}
