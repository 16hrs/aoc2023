using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AdventOfCode2022.Running;

[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Alphabetical)]
public class Bench
{

    private BaseChallenge _challenge = null!;
    private static Type Challenge => Program.DayInput;

    [GlobalSetup] public void Setup()
    {
        _challenge = (BaseChallenge)Activator.CreateInstance(Challenge)!;
    }

    [Benchmark(Description = "Part 1")] public string PartOne()
        => _challenge.SolvePartOne();

    [Benchmark(Description = "Part 2")] public string PartTwo()
        => _challenge.SolvePartTwo();
}