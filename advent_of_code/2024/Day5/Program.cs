using Common;

var testInput = await File.ReadAllLinesAsync("input.test");
var input = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, testInput, 143);
Utils.RunPuzzle(Part1, input, 5713);
Utils.RunPuzzle(Part2, testInput, 123);
Utils.RunPuzzle(Part2, input);

return;

int Part1(string[] strings)
{

    var dictionary = new Dictionary<int, HashSet<int>>();
    
    var orderingRules = strings
        .TakeWhile(x => !string.IsNullOrEmpty(x))
        .Select(x=> x.Split('|').Select(int.Parse).ToArray())
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

    var updates = strings
        .SkipWhile(x => !string.IsNullOrEmpty(x))
        .Skip(1)
        .Select(x => x.Split(',').Select(int.Parse).ToList())
        .ToList();

    return 
        updates
            .Where(pages => IsUpdateCorrect(dictionary, pages))
            .Sum(pages => pages[pages.Count / 2]);
}

bool IsUpdateCorrect(Dictionary<int, HashSet<int>> rules, List<int> update)
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

int Part2(string[] strings)
{
    var dictionary = new Dictionary<int, HashSet<int>>();
    
    var orderingRules = strings
        .TakeWhile(x => !string.IsNullOrEmpty(x))
        .Select(x=> x.Split('|').Select(int.Parse).ToArray())
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

    var updates = strings
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

