using System;
using System.Diagnostics;
using System.Reflection;
using FluentAssertions;

namespace Common;

public static class Utils
{
    public static void RunPuzzle(Func<string[], int> puzzleFunc, string[] puzzleInput, int? expectedResult = null)
    {
        
       RunPuzzle(puzzleFunc, puzzleInput, result =>
       {
           if (expectedResult.HasValue)
           {
                result.Should().Be(expectedResult);
           }
       });
    }
    
    public static void RunPuzzle<T>(Func<string[], T> puzzleFunc, string[] puzzleInput, Action<T> testAction)
    {
        
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var result = puzzleFunc(puzzleInput);

        stopwatch.Stop();

        var elapsed = stopwatch.Elapsed;

        testAction.Invoke(result);
        
        Console.WriteLine($"[{puzzleFunc.Method.DeclaringType?.Name}|{puzzleFunc.Method.Name}] Result: {result}, Elapsed time: {elapsed.TotalMilliseconds} ms");

    }

}