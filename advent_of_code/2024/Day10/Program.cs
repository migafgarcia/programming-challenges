using Common;
using FluentAssertions;

var rawTestInput = await File.ReadAllLinesAsync("input.test");
using var aoc = new AdventOfCodeClient("COOKIE");
var rawInput = (await aoc.GetInput(2024, 10)).Trim().Split('\n');

Utils.RunPuzzle(Part1, rawTestInput, result =>
{
    result.Should().Be(36);
});
Utils.RunPuzzle(Part1, rawInput, result =>
{
    result.Should().Be(587);
});

Utils.RunPuzzle(Part2, rawTestInput, result =>
{
    result.Should().Be(81);
});
Utils.RunPuzzle(Part2, rawInput, result =>
{
    result.Should().Be(1340);
});

return;

int Part1(string[] strings)
{
    
    var parsedInput = strings.Select(s => s.Select(c => c - '0').ToArray()).ToArray();
    var result = 0;
    
    for (var i = 0; i < parsedInput.Length; i++)
    {
        for (var j = 0; j < parsedInput[0].Length; j++)
        {
            if (parsedInput[i][j] != 0) continue;
            
            var set = new HashSet<(int, int)>();

            var stack = new Stack<(int, int)>();
            stack.Push((i, j));

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();
                    
                if (parsedInput[x][y] == 9)
                {
                    set.Add((x, y));
                    continue;
                }

                if (y + 1 < parsedInput[x].Length && parsedInput[x][y + 1] == parsedInput[x][y] + 1)
                {
                    stack.Push((x, y + 1));
                }
                if (y - 1 >= 0 && parsedInput[x][y - 1] == parsedInput[x][y] + 1)
                {
                    stack.Push((x, y - 1));
                }
                if (x + 1 < parsedInput.Length && parsedInput[x + 1][y] == parsedInput[x][y] + 1)
                {
                    stack.Push((x + 1, y));
                }
                if (x - 1 >= 0 && parsedInput[x - 1][y] == parsedInput[x][y] + 1)
                {
                    stack.Push((x - 1, y));
                }
            }
                
            result += set.Count;
        }
    }
    
    return result;
}

int Part2(string[] strings)
{
    var parsedInput = strings.Select(s => s.Select(c => c - '0').ToArray()).ToArray();
    var result = 0;
    
    for (var i = 0; i < parsedInput.Length; i++)
    {
        for (var j = 0; j < parsedInput[0].Length; j++)
        {
            if (parsedInput[i][j] != 0) continue;

            var stack = new Stack<(int, int)>();
            stack.Push((i, j));
            var count = 0;
            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();
                    
                if (parsedInput[x][y] == 9)
                {
                    count++;
                    continue;
                }

                if (y + 1 < parsedInput[x].Length && parsedInput[x][y + 1] == parsedInput[x][y] + 1)
                {
                    stack.Push((x, y + 1));
                }
                if (y - 1 >= 0 && parsedInput[x][y - 1] == parsedInput[x][y] + 1)
                {
                    stack.Push((x, y - 1));
                }
                if (x + 1 < parsedInput.Length && parsedInput[x + 1][y] == parsedInput[x][y] + 1)
                {
                    stack.Push((x + 1, y));
                }
                if (x - 1 >= 0 && parsedInput[x - 1][y] == parsedInput[x][y] + 1)
                {
                    stack.Push((x - 1, y));
                }
            }
                
            result += count;
        }
    }
    
    return result;
}