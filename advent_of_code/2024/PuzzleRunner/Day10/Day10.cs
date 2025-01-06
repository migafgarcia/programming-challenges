namespace PuzzleRunner.Day10;

public class Day10 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day10/test_input.txt"), 36 },
        { File.ReadAllLines("Day10/puzzle_input.txt"), 587 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day10/test_input.txt"), 81 },
        { File.ReadAllLines("Day10/puzzle_input.txt"), 1340 }
    };

    public long Part1(string[] input)
    {
        
        var parsedInput = input.Select(s => s.Select(c => c - '0').ToArray()).ToArray();
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

    public long Part2(string[] input)
    {
        var parsedInput = input.Select(s => s.Select(c => c - '0').ToArray()).ToArray();
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
}