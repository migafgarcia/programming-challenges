
var input = await File.ReadAllLinesAsync(@"day1part1.txt");

Part1(input);
Part2(input);
return;

void Part1(string[] strings)
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

    Console.WriteLine(sum);
}

void Part2(string[] strings)
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

        score += (leftItem * rightCount) * leftCount;
    }
    
    Console.WriteLine(score);

}

