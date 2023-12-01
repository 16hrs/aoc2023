﻿using AdventOfCode2022.Running;
using AdventOfCode2022.Utilities;
using BenchmarkDotNet.Running;

namespace AdventOfCode2022;

internal class Program
{
    // TODO: Find a better way to get this into the benchmark
    static internal Type DayInput { get; set; }

    private static void Main(string[] args)
    {
        switch (args.Length)
        {
            case 0:
                // Run all
                BenchmarkRunner.Run<BulkBench>();
                break;

            // TODO: This is broken? Fix this or something!
            case 1:
                if (!ReflectionUtilities.TryGetChallengeType(args[0], out var challengeType))
                {
                    Console.WriteLine($"'{args[0]}' not found in challenges folder. Exiting...");
                    break;
                }

                if (args.Contains("--bench"))
                {
                    // Run the one provided in the arg
                    DayInput = challengeType;
                    BenchmarkRunner.Run<Bench>();
                }
                else
                {
                    var challenge = (BaseChallenge)Activator.CreateInstance(challengeType)!;

                    Console.WriteLine(challenge.SolvePartOne());
                    Console.WriteLine(challenge.SolvePartTwo());
                }

                break;

            default:
                Console.WriteLine($"'{args.Length}' is too many arguments");
                break;
        }
    }
}
