using System.Text.RegularExpressions;
using Common;
using FluentAssertions;

var rawTestInput = await File.ReadAllLinesAsync("input.test");
var rawInput = await File.ReadAllLinesAsync("input.txt");
//
Utils.RunPuzzle(Part1, rawTestInput, result =>
{
    result.Should().Be(3749);
});
Utils.RunPuzzle(Part1, rawInput, result =>
{
    result.Should().Be(12940396350192);
});

Utils.RunPuzzle(Part2, rawTestInput, result =>
{
    result.Should().Be(11387);
});
Utils.RunPuzzle(Part2, rawInput, result =>
{
    result.Should().Be(106016735664498);
});

return;

long Part1(string[] strings)
{

    long totalCalibrationResult = 0;
    foreach (var line in strings)
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

bool ProcessOperators(long expectedResult, long currentResult, long[] operatorsToProcess, int index)
{
    
    if (index == operatorsToProcess.Length)
    {
        return expectedResult == currentResult;
    }

    var currentOperator = operatorsToProcess[index];

    return ProcessOperators(expectedResult, currentResult + currentOperator, operatorsToProcess, index + 1) || 
           ProcessOperators(expectedResult, currentResult * currentOperator, operatorsToProcess, index + 1);
}

bool ProcessOperatorsElephants(long expectedResult, long currentResult, long[] operatorsToProcess, int index)
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

long Part2(string[] strings)
{
    long totalCalibrationResult = 0;
    foreach (var line in strings)
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
