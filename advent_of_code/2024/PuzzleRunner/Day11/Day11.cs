using System.Collections.Concurrent;
using System.Runtime.InteropServices.JavaScript;

namespace PuzzleRunner.Day11;

public class Day11 : Puzzle<long>
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day11/test_input.in"), 55312 },
        { File.ReadAllLines("Day11/puzzle_input.in"), 183248 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day11/test_input.in"), 65601038650482 },
        { File.ReadAllLines("Day11/puzzle_input.in"), 218811774248729 }
    };

    public long Part1(string[] input)
    {
        var memo = new Dictionary<(int, long), long>();

        var stones = input[0]
            .Split(' ')
            .Select(long.Parse)
            .ToList();


        return stones.Aggregate<long, long>(0, (current, stone) => current + ProcessIteration(0, stone, 25, memo));
    }

    public long Part2(string[] input)
    {
        var memo = new Dictionary<(int, long), long>();

        var stones = input[0]
            .Split(' ')
            .Select(long.Parse)
            .ToList();

        return stones.Aggregate<long, long>(0, (current, stone) => current + ProcessIteration(0, stone, 75, memo));
    }

    private long ProcessIteration(int currentIteration, long value, int nIterations,
        Dictionary<(int, long), long> memo)
    {
        if (memo.ContainsKey((currentIteration, value)))
        {
            return memo[(currentIteration, value)];
        }

        // exit early
        if (currentIteration + 1 == nIterations)
        {
            if (value == 0)
            {
                return 1;
            }

            return NumDigits(value) % 2 == 0 ? 2 : (long)1;
        }

        if (value == 0)
        {
            var result = ProcessIteration(currentIteration + 1, 1, nIterations, memo);
            memo.Add((currentIteration, value), result);
            return result;
        }

        var numDigits = NumDigits(value);
        if (numDigits % 2 == 0)
        {
            if (currentIteration + 1 == nIterations)
            {
                return 2;
            }

            var divisor = Pow(10, numDigits / 2);

            var leftValue = value / divisor;
            var rightValue = value % divisor;

            var result = ProcessIteration(currentIteration + 1, leftValue, nIterations, memo) +
                         ProcessIteration(currentIteration + 1, rightValue, nIterations, memo);

            memo.Add((currentIteration, value), result);
            return result;
        }
        else
        {
            var result = ProcessIteration(currentIteration + 1, value * 2024, nIterations, memo);
            memo.Add((currentIteration, value), result);
            return result;
        }
    }

    private int NumDigits(long value)
    {
        var numDigits = 1;
        var temp = value;
        while ((temp /= 10) > 0) numDigits++;
        return numDigits;
    }

    private static long Pow(long baseValue, int exponent)
    {
        if (exponent == 0)
            return 1;

        if (baseValue == 0)
            return 0;

        long result = 1;

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                result *= baseValue;
            }

            baseValue *= baseValue;
            exponent >>= 1;
        }

        return result;
    }
}