namespace PuzzleRunner.Day1;

public class Day1 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day1/test_input.txt"), 11 },
        { File.ReadAllLines("Day1/puzzle_input.txt"), 1320851 }
    };
    
    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day1/test_input.txt"), 31 },
        { File.ReadAllLines("Day1/puzzle_input.txt"), 26859182 }
    };

    public long Part1(string[] input)
    {
        var leftList = new int[input.Length];
        var rightList = new int[input.Length];

        for (var i = 0; i < input.Length; i++)
        {
            var entry = input[i].Split("   ");
            leftList[i] = int.Parse(entry[0]);
            rightList[i] = int.Parse(entry[1]);
        }

        Array.Sort(leftList);
        Array.Sort(rightList);

        var sum = 0;

        for (var i = 0; i < input.Length; i++)
        {
            sum += Math.Abs(rightList[i] - leftList[i]);
        }

        return sum;
    }

    public long Part2(string[] input)
    {
        var leftList = new Dictionary<int, int>();
        var rightList = new Dictionary<int, int>();

        foreach (var t in input)
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
}