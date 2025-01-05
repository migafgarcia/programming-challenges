using System.Text.RegularExpressions;

namespace PuzzleRunner.Day4;

public class Day4 : Puzzle<long>
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day4/test_input.in"), 18 },
        { File.ReadAllLines("Day4/puzzle_input.in"), 2591 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day4/test_input.in"), 9 },
        { File.ReadAllLines("Day4/puzzle_input.in"), 1880 }
    };

    public long Part1(string[] input)
    {
        const string word = "XMAS";
        var count = 0;
        var height = input.Length;
        var width = input[0].Length;

        for (var i = 0; i < width; i++)
        {
            var vertical =
                Enumerable
                    .Range(0, height)
                    .Select(x => input[x][i])
                    .ToList();

            count += CheckWord(vertical, word);

            if (i <= 0) continue;

            var forwardColumnDiagonal =
                Enumerable
                    .Range(0, width - i)
                    .Select(x => input[x][x + i])
                    .ToList();


            var upperBackwardDiagonal =
                Enumerable
                    .Range(0, width - i)
                    .Select(x => input[height - x - 1][x + i])
                    .ToList();

            count += CheckWord(upperBackwardDiagonal, word) + CheckWord(forwardColumnDiagonal, word);
        }


        for (var i = 0; i < height; i++)
        {
            var horizontal = input[i].ToCharArray();

            var forwardRowDiagonal =
                Enumerable
                    .Range(0, height - i)
                    .Select(x => input[x + i][x])
                    .ToList();

            var lowerBackwardDiagonal =
                Enumerable
                    .Range(0, i + 1)
                    .Select(x => input[i - x][x])
                    .ToList();


            count += CheckWord(horizontal, word) + CheckWord(forwardRowDiagonal, word) +
                     CheckWord(lowerBackwardDiagonal, word);
        }


        return count;
    }

    public long Part2(string[] input)
    {
        var count = 0;
        var height = input.Length;
        var width = input[0].Length;

        for (var row = 1; row < height - 1; row++)
        {
            for (var col = 1; col < width - 1; col++)
            {
                if (input[row][col] != 'A') continue;

                if (((input[row - 1][col - 1] == 'M' && input[row + 1][col + 1] == 'S') ||
                     (input[row - 1][col - 1] == 'S' && input[row + 1][col + 1] == 'M')) &&
                    ((input[row - 1][col + 1] == 'M' && input[row + 1][col - 1] == 'S') ||
                     (input[row - 1][col + 1] == 'S' && input[row + 1][col - 1] == 'M')))
                {
                    count++;
                }
            }
        }

        return count;
    }
    
    private static int CheckWord(IList<char> chars, string word) =>
        Regex.Matches(new string(chars.ToArray()), word).Count +
        Regex.Matches(new string(chars.ToArray()), new string(word.Reverse().ToArray())).Count;

}