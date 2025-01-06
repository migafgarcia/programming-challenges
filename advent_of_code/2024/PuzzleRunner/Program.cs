using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Common;
using FluentAssertions;

namespace PuzzleRunner;

class Program
{
    [RequiresUnreferencedCode("Calls System.Reflection.Assembly.GetTypes()")]
    static Task Main(string[] args)
    {
        var dailyPuzzle = new Day11.Day11();
        
        Utils.RunPuzzle(dailyPuzzle);
        
        var puzzles = Assembly.GetEntryAssembly()!.GetTypes()
            .Where(t => t.GetTypeInfo().IsClass && typeof(Puzzle).IsAssignableFrom(t))
            .OrderBy(t => t.FullName)
            .Select(t => Activator.CreateInstance(t) as Puzzle);
        
        foreach (var puzzle in puzzles)
        {
            try
            {
                Utils.RunPuzzle(puzzle!);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        return Task.CompletedTask;
    }
    
    
}