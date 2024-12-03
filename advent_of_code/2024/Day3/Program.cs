using System.Text.RegularExpressions;
using Common;

var testInput = await File.ReadAllLinesAsync("input_part1.test");
var testInput2 = await File.ReadAllLinesAsync("input_part2.test");
var input = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, testInput2, 161);
Utils.RunPuzzle(Part1, input);
Utils.RunPuzzle(Part2, testInput2, 48);
Utils.RunPuzzle(Part2, input);
return;

int Part1(string[] input) =>
    input
        .SelectMany(line => Regex.Matches(line, @"mul\((\d+),(\d+)\)"))
        .Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value))
        .Sum();

int Part2(string[] input) =>
    input
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
