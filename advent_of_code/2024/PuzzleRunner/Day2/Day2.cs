namespace PuzzleRunner.Day2;

public class Day2 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day2/test_input.in"), 2 },
        { File.ReadAllLines("Day2/puzzle_input.in"), 369 }
    };
    
    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day2/test_input.in"), 4 },
        { File.ReadAllLines("Day2/puzzle_input.in"), 428 }
    };

    public long Part1(string[] input)
    {
        return input
            .Select(s => s.Split().Select(int.Parse).ToArray())
            .Count(levels => IsSequence(levels) && IsValidIntervals(levels));
    }

    public long Part2(string[] input)
    {
        return input
            .Select(s => s.Split().Select(int.Parse).ToArray())
            .Count(levels => levels
                .Where((_, i) => IsValidIntervalsWithDampener(levels, i) && IsSequenceWithDampener(levels, i))
                .Any());
    }


    private bool IsSequence(int[] levels)
    {
        bool? increasing = null;
        int? lastValue = null;
        foreach (var level in levels)
        {
            if (!increasing.HasValue && lastValue.HasValue)
            {
                if (level <= lastValue.Value)
                {
                    increasing = false;
                }
                else if (level >= lastValue.Value)
                {
                    increasing = true;
                }
            }

            if (increasing.HasValue && lastValue.HasValue)
            {
                if (increasing.Value && level <= lastValue.Value)
                {
                    return false;
                }

                if (!increasing.Value && level >= lastValue.Value)
                {
                    return false;
                }
            }

            lastValue = level;
        }

        return true;
    }

    private bool IsValidIntervals(int[] levels)
    {
        int? lastValue = null;
        foreach (var level in levels)
        {
            if (lastValue.HasValue)
            {
                var diff = Math.Abs(level - lastValue.Value);
                if (diff is > 3 or < 1) return false;
            }

            lastValue = level;
        }

        return true;
    }

    private bool IsSequenceWithDampener(int[] levels, int skipIndex)
    {
        bool? increasing = null;
        int? lastValue = null;
        for (var i = 0; i < levels.Length; i++)
        {
            if (i == skipIndex)
            {
                continue;
            }

            var level = levels[i];
            if (increasing.HasValue && lastValue.HasValue)
            {
                if (increasing.Value && level <= lastValue.Value)
                {
                    return false;
                }

                if (!increasing.Value && level >= lastValue.Value)
                {
                    return false;
                }
            }

            if (!increasing.HasValue && lastValue.HasValue)
            {
                if (level <= lastValue.Value)
                {
                    increasing = false;
                }
                else if (level >= lastValue.Value)
                {
                    increasing = true;
                }
            }

            lastValue = level;
        }

        return true;
    }

    private bool IsValidIntervalsWithDampener(int[] levels, int skipIndex)
    {
        int? lastValue = null;
        for (var i = 0; i < levels.Length; i++)
        {
            if (i == skipIndex)
            {
                continue;
            }

            var level = levels[i];
            if (lastValue.HasValue)
            {
                var diff = Math.Abs(level - lastValue.Value);
                if (diff is > 3 or < 1) return false;
            }

            lastValue = level;
        }

        return true;
    }
}