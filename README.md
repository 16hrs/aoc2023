# aoc dotnet
Provides a template for running and benchmarking your Advent of Code solutions in C# and F#. It includes a command-line tool that allows you to easily run your solutions for specific days or for all days. The tool can also be used to benchmark your solutions to measure their performance.

# Usage

### Options

| Option | Description | Default Value |
|---|---|---|
| `--lang <lang>` | The language to run in. | c# |
| `--days <days>` | The days to run. | all |
| `--version` | Show version information. | |
| `-?, -h, --help` | Show help and usage information. | |

### Commands

| Command | Description |
|---|---|
| `run` | Run without benchmark. |
| `bench` | Run with benchmark. |

### Example Setup

Create a class for each day of the Advent of Code challenge. The class should inherit from the BaseChallenge class and implement the SolvePartOne and SolvePartTwo methods.

```cs
public class Day4 : BaseChallenge
{
    private readonly string Input;

    public Day4()
    {
        Input = LoadInput(File.ReadAllText, nameof(Day4));
    }

    public override string SolvePartOne()
    {
        throw new NotImplementedException();
    }

    public override string SolvePartTwo()
    {
        throw new NotImplementedException();
    }
}
```
# Troubleshooting
* Make sure to place the input files in the right folder. The input files should be named `dayXX.txt`, where `XX` is the day number.
* Make sure to set input files to "copy if newer" so that they get copied to the output folder accordingly.

