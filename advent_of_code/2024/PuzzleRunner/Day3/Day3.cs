using System.Text.RegularExpressions;

namespace PuzzleRunner.Day3;

public class Day3 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day3/test_input.txt"), 161 },
        { File.ReadAllLines("Day3/puzzle_input.txt"), 160672468 }
    };
    
    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day3/test_input.txt"), 48 },
        { File.ReadAllLines("Day3/puzzle_input.txt"), 84893551 }
    };
    public long Part1(string[] input)
    {
        return input
            .SelectMany(line => Regex.Matches(line, @"mul\((\d+),(\d+)\)"))
            .Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value))
            .Sum();
    }

    public long Part2(string[] input)
    {
        return input
            .SelectMany(line => Regex.Matches(line, @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)"))
            .Aggregate((result: 0, mulEnabled: true), (acc, match) =>
            {
                if (match.Value.StartsWith("don't()"))
                    return (acc.result, false);

                if (match.Value.StartsWith("do()"))
                    return (acc.result, true);

                var a = int.Parse(match.Groups[1].Value);
                var b = int.Parse(match.Groups[2].Value);

                return acc.mulEnabled ? (acc.result + a * b, acc.mulEnabled) : acc;
            }).result;
    }
}