using System.Collections.Concurrent;
using System.Runtime.InteropServices.JavaScript;

namespace PuzzleRunner.Day11;

public class Day11 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day11/test_input.in"), 55312 },
        { File.ReadAllLines("Day11/puzzle_input.in"), 183248 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        // { File.ReadAllLines("Day11/test_input.in"), null },
        { File.ReadAllLines("Day11/puzzle_input.in"), null }
    };

    public long Part1(string[] input)
    {
        return ProcessIterations(input, 25);
    }

    public long Part2(string[] input)
    {
        return ProcessIterations(input, 75);
    }

    private static long ProcessIterations(string[] input, int nIterations)
    {
        object _lockObj = new object();

        var list = new List<long[]> { input[0].Split(' ').Select(long.Parse).ToArray() };
        
        for (var i = 0; i < nIterations; i++)
        {
            
            Console.WriteLine($"Iteration { i + 1}");

            var stonesToAddAll = new List<long>();

            Parallel.ForEach(list,
                new ParallelOptions()
                {
                    MaxDegreeOfParallelism = 8
                },
                stones =>
            {
                var stonesToAdd = new List<long>();

                for (var j = 0; j < stones.Length; j++)
                {
                    var len = (int)Math.Floor(Math.Log10(stones[j])) + 1;
                    if (stones[j] == 0)
                    {
                        stones[j] = 1;
                    }
                    else if (len % 2 == 0)
                    {
                        var divisor = 10;
                        while (stones[j] / divisor > divisor) divisor *= 10;
                        var leftValue = stones[j] / divisor;
                        var rightValue = stones[j] % divisor;
                        stones[j] = leftValue;
                        stonesToAdd.Add(rightValue);
                    }
                    else
                    {
                        stones[j] *= 2024;
                    }

                }
                
                lock (_lockObj)
                {
                    stonesToAddAll.AddRange(stonesToAdd);
                }
                
                
            });
            
            list.Add(stonesToAddAll.ToArray());
            
        }
        
        return list.Sum(l => l.Length);
    }
}