using Common;

var testInput = await File.ReadAllLinesAsync("input.test");
var input = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, testInput, 2);
Utils.RunPuzzle(Part2, testInput, 4);
Utils.RunPuzzle(Part1, input, 369);
Utils.RunPuzzle(Part2, input, 428);

return;

int Part1(string[] strings)
{
    return strings
        .Select(s => s.Split().Select(int.Parse).ToArray())
        .Count(levels => IsSequence(levels) && IsValidIntervals(levels));
}

bool IsSequence(int[] levels)
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

bool IsValidIntervals(int[] levels)
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

int Part2(string[] strings)
{
    return strings
        .Select(s => s.Split().Select(int.Parse).ToArray())
        .Count(levels => levels
            .Where((_, i) => IsValidIntervalsWithDampener(levels, i) && IsSequenceWithDampener(levels, i))
            .Any());
}


bool IsSequenceWithDampener(int[] levels, int skipIndex)
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

bool IsValidIntervalsWithDampener(int[] levels, int skipIndex)
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
