
using Common;

var testInput = await File.ReadAllLinesAsync("input.test");
var input = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, testInput, 11);
Utils.RunPuzzle(Part2, testInput,31);
Utils.RunPuzzle(Part1, input, 1320851);
Utils.RunPuzzle(Part2, input, 26859182);

return;

int Part1(string[] strings)
{
    
    var leftList = new int[strings.Length];
    var rightList = new int[strings.Length];

    for (var i = 0; i < strings.Length; i++)
    {
        var entry = strings[i].Split("   ");
        leftList[i] = int.Parse(entry[0]);
        rightList[i] = int.Parse(entry[1]);
    }

    Array.Sort(leftList);
    Array.Sort(rightList);

    var sum = 0;

    for (var i = 0; i < strings.Length; i++)
    {
        sum += Math.Abs(rightList[i] - leftList[i]);
    }

    return sum;
}

int Part2(string[] strings)
{
    var leftList = new Dictionary<int, int>();
    var rightList = new Dictionary<int, int>();

    foreach (var t in strings)
    {
        var entry = t.Split("   ");
        var leftItem = int.Parse(entry[0]);
        var rightItem = int.Parse(entry[1]);

        if(!leftList.TryAdd(leftItem, 1))
        {
            leftList[leftItem]++;
        }

        if(!rightList.TryAdd(rightItem, 1))
        {
            rightList[rightItem]++;
        }
    }

    var score = 0;
    foreach (var (leftItem, leftCount) in leftList)
    {
        if (!rightList.TryGetValue(leftItem, out var rightCount))
        {
            continue;
        }

        score += leftItem * rightCount * leftCount;
    }

    return score;

}

