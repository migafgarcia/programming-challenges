using System.Diagnostics;
using System.Reflection;
using Common;
using FluentAssertions;

namespace PuzzleRunner;

class Program
{
    static Task Main(string[] args)
    {
        var day11 = new Day11.Day11();
        
        
        // foreach (var (input, output) in day11.Part1TestCases)
        // {
        //     Utils.RunPuzzle(day11.Part1, input, result =>
        //     {
        //         if (output.HasValue)
        //         {
        //             result.Should().Be(output.Value);
        //         }
        //     });
        // }
        
        foreach (var (input, output) in day11.Part2TestCases)
        {
            Utils.RunPuzzle(day11.Part2, input, result =>
            {
                if (output.HasValue)
                {
                    result.Should().Be(output.Value);
                }
            });
        }

        //
        // var puzzles = Assembly.GetEntryAssembly()!.GetTypes()
        //     .Where(t => t.GetTypeInfo().IsClass && typeof(Puzzle).IsAssignableFrom(t))
        //     .OrderBy(t => t.FullName)
        //     .Select(t => Activator.CreateInstance(t) as Puzzle);
        //
        // foreach (var puzzle in puzzles)
        // {
        //     foreach (var (input, output) in puzzle.Part1TestCases)
        //     {
        //         Utils.RunPuzzle(puzzle.Part1, input, result =>
        //         {
        //             if (output.HasValue)
        //             {
        //                 result.Should().Be(output.Value);
        //             }
        //         });
        //     }
        //     
        //     foreach (var (input, output) in puzzle.Part2TestCases)
        //     {
        //         Utils.RunPuzzle(puzzle.Part2, input, result =>
        //         {
        //             if (output.HasValue)
        //             {
        //                 result.Should().Be(output.Value);
        //             }
        //         });
        //     }
        //
        // }

        return Task.CompletedTask;
    }
}