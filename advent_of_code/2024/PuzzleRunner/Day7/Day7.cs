using System.Text.RegularExpressions;

namespace PuzzleRunner.Day7;

public class Day7 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day7/test_input.in"), 3749 },
        { File.ReadAllLines("Day7/puzzle_input.in"), 12940396350192 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day7/test_input.in"), 11387 },
        { File.ReadAllLines("Day7/puzzle_input.in"), 106016735664498 }
    };
    public long Part1(string[] input)
    {
        
        long totalCalibrationResult = 0;
        foreach (var line in input)
        {
            var splitted = line.Split(":");
            var calibrationResult = long.Parse(splitted[0]);
        
            var operators = 
                Regex.Matches(splitted[1], @"\d+")
                    .Select(match => long.Parse(match.Value))
                    .ToArray();
        
            if (ProcessOperators(calibrationResult, operators[0], operators, 1))
            {
                totalCalibrationResult += calibrationResult;
            }
        }

        return totalCalibrationResult;
    }

    public long Part2(string[] input)
    {
        long totalCalibrationResult = 0;
        foreach (var line in input)
        {
            var splitted = line.Split(":");
            var calibrationResult = long.Parse(splitted[0]);
        
            var operators = 
                Regex.Matches(splitted[1], @"\d+")
                    .Select(match => long.Parse(match.Value))
                    .ToArray();
        
            if (ProcessOperatorsElephants(calibrationResult, operators[0], operators, 1))
            {
                totalCalibrationResult += calibrationResult;
            }
        }

        return totalCalibrationResult;
    }

    private static bool ProcessOperators(long expectedResult, long currentResult, long[] operatorsToProcess, int index)
    {
    
        if (index == operatorsToProcess.Length)
        {
            return expectedResult == currentResult;
        }

        var currentOperator = operatorsToProcess[index];

        return ProcessOperators(expectedResult, currentResult + currentOperator, operatorsToProcess, index + 1) || 
               ProcessOperators(expectedResult, currentResult * currentOperator, operatorsToProcess, index + 1);
    }

    private static bool ProcessOperatorsElephants(long expectedResult, long currentResult, long[] operatorsToProcess, int index)
    {
    
        if (index == operatorsToProcess.Length)
        {
            return expectedResult == currentResult;
        }

        var currentOperator = operatorsToProcess[index];
    
        return ProcessOperatorsElephants(expectedResult, long.Parse($"{currentResult}{currentOperator}"), operatorsToProcess, index + 1) || 
               ProcessOperatorsElephants(expectedResult, currentResult + currentOperator, operatorsToProcess, index + 1) || 
               ProcessOperatorsElephants(expectedResult, currentResult * currentOperator, operatorsToProcess, index + 1);
    }

}