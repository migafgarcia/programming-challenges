namespace PuzzleRunner.Day5;

public class Day5 : Puzzle<long>
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day5/test_input.in"), 143 },
        { File.ReadAllLines("Day5/puzzle_input.in"), 5713 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day5/test_input.in"), 123 },
        { File.ReadAllLines("Day5/puzzle_input.in"), 5180 }
    };

    public long Part1(string[] input)
    {
        var dictionary = new Dictionary<int, HashSet<int>>();

        var orderingRules = input
            .TakeWhile(x => !string.IsNullOrEmpty(x))
            .Select(x => x.Split('|').Select(int.Parse).ToArray())
            .ToList();

        foreach (var split in orderingRules)
        {
            var key = split[0];
            var value = split[1];

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, []);
            }

            dictionary[key].Add(value);
        }

        var updates = input
            .SkipWhile(x => !string.IsNullOrEmpty(x))
            .Skip(1)
            .Select(x => x.Split(',').Select(int.Parse).ToList())
            .ToList();

        return
            updates
                .Where(pages => IsUpdateCorrect(dictionary, pages))
                .Sum(pages => pages[pages.Count / 2]);
    }

    public long Part2(string[] input)
    {
        var dictionary = new Dictionary<int, HashSet<int>>();

        var orderingRules = input
            .TakeWhile(x => !string.IsNullOrEmpty(x))
            .Select(x => x.Split('|').Select(int.Parse).ToArray())
            .ToList();

        foreach (var split in orderingRules)
        {
            var key = split[0];
            var value = split[1];

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, []);
            }

            dictionary[key].Add(value);
        }

        var result = 0;

        var updates = input
            .SkipWhile(x => !string.IsNullOrEmpty(x))
            .Skip(1)
            .Select(x => x.Split(',').Select(int.Parse).ToArray())
            .ToList();

        foreach (var pages in updates)
        {
            var currentUpdate = new List<int>();
            for (var j = 0; j < pages.Length; j++)
            {
                var page = pages[j];
                for (var i = 0; i < j + 1; i++)
                {
                    var testList = new List<int>(currentUpdate);
                    testList.Insert(i, page);

                    if (IsUpdateCorrect(dictionary, testList))
                    {
                        currentUpdate.Insert(i, page);
                        break;
                    }
                }
            }

            if (!currentUpdate.SequenceEqual(pages))
            {
                result += currentUpdate[currentUpdate.Count / 2];
            }
        }

        return result;
    }

    private static bool IsUpdateCorrect(Dictionary<int, HashSet<int>> rules, List<int> update)
    {
        for (var i = 0; i < update.Count; i++)
        {
            var a = update[i];
            for (var j = i + 1; j < update.Count; j++)
            {
                var b = update[j];

                if (rules.TryGetValue(b, out var set) && set.Contains(a))
                {
                    return false;
                }
            }
        }

        return true;
    }
}