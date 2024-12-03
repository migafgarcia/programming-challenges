using System.Diagnostics;
using System.Reflection;
using FluentAssertions;

namespace Common;

public static class Utils
{

    public static void RunPuzzle(Func<string[], int> puzzleFunc, string[] puzzleInput, int? expectedResult = null)
    {
        
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var result = puzzleFunc(puzzleInput);

        stopwatch.Stop();

        var elapsed = stopwatch.Elapsed;

        if (expectedResult.HasValue)
        {
            result.Should().Be(expectedResult);    
        }
        
        Console.WriteLine($"[{Assembly.GetCallingAssembly().GetName().Name}] Result: {result}, Elapsed time: {elapsed.TotalMilliseconds} ms");

    }
    
}