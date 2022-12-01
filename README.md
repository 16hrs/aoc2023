# AoC-2022
---
Use this repository as a template to run your C# AoC solutions.
---
# Example setup

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

Make sure to place the input files in the right folder. And make sure to set them to "copy if newer" so that they get copied to the output folder accordingly.