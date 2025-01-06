using System.Collections.Concurrent;
using System.Runtime.InteropServices.JavaScript;

namespace PuzzleRunner.Day11;

public class Day12 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day12/test_input.txt"), null },
        { File.ReadAllLines("Day12/puzzle_input.txt"), null }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day12/test_input.txt"), null },
        { File.ReadAllLines("Day12/puzzle_input.txt"), null }
    };

    public long Part1(string[] input)
    {
        throw new NotImplementedException();
    }

    public long Part2(string[] input)
    {
       throw new NotImplementedException();
    }

}