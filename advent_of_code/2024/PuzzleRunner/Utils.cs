using System;
using System.Diagnostics;
using System.Reflection;
using FluentAssertions;
using PuzzleRunner;

namespace Common;

public static class Utils
{
    
    public static void RunPuzzle(Puzzle puzzle)
    {
        
        foreach (var (input, output) in puzzle.Part1TestCases)
        {
            ExecuteAndValidate(puzzle.Part1, input, output);
        }
            
        foreach (var (input, output) in puzzle.Part2TestCases)
        {
            ExecuteAndValidate(puzzle.Part2, input, output);
        }
    }
    
    public static void ExecuteAndValidate(Func<string[], long> func, string[] input, long? expectedResult = null)
    {
        
       ExecuteAndValidate(func, input, result =>
       {
           if (expectedResult.HasValue)
           {
                result.Should().Be(expectedResult);
           }
       });
    }
    
    
    public static void ExecuteAndValidate<T>(Func<string[], T> func, string[] input, Action<T> testAction)
    {
        
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var result = func(input);

        stopwatch.Stop();

        var elapsed = stopwatch.Elapsed;

        testAction.Invoke(result);
        
        Console.WriteLine($"[{func.Method.DeclaringType?.Name}|{func.Method.Name}] Result: {result}, Elapsed time: {elapsed.TotalMilliseconds} ms");

    }

}