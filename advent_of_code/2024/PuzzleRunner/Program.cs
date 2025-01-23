using System.Diagnostics.CodeAnalysis;
using Common;

namespace PuzzleRunner;

class Program
{
    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.GetTypes()")]
    static Task Main(string[] args)
    {
        var dailyPuzzle = new Day12.Day12();

        foreach (var (input, output) in dailyPuzzle.Part2TestCases)
        {
            Utils.ExecuteAndValidate(dailyPuzzle.Part2, input, output);
        }
        //
        // var puzzles = Assembly.GetEntryAssembly()!.GetTypes()
        //     .Where(t => t.GetTypeInfo().IsClass && typeof(Puzzle).IsAssignableFrom(t))
        //     .OrderBy(t => t.FullName)
        //     .Select(t => Activator.CreateInstance(t) as Puzzle);
        //
        // foreach (var puzzle in puzzles)
        // {
        //     try
        //     {
        //         Utils.RunPuzzle(puzzle!);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex);
        //     }
        // }

        return Task.CompletedTask;
    }
    
    
}