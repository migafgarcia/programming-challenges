using System.Text.RegularExpressions;
using Common;

var testInput = await File.ReadAllLinesAsync("input.test");
var input = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, testInput, 18);
Utils.RunPuzzle(Part1, input, 2591);
Utils.RunPuzzle(Part2, testInput, 9);
Utils.RunPuzzle(Part2, input, 1880);

return;


int CheckWord(IList<char> chars, string word) =>
    Regex.Matches(new string(chars.ToArray()), word).Count +
    Regex.Matches(new string(chars.ToArray()), new string(word.Reverse().ToArray())).Count;

int Part1(string[] strings)
{
    const string word = "XMAS";
    var count = 0;
    var height = strings.Length;
    var width = strings[0].Length;

    for (var i = 0; i < width; i++)
    {
        var vertical =
            Enumerable
                .Range(0, height)
                .Select(x => strings[x][i])
                .ToList();

        count += CheckWord(vertical, word);

        if (i <= 0) continue;

        var forwardColumnDiagonal =
            Enumerable
                .Range(0, width - i)
                .Select(x => strings[x][x + i])
                .ToList();


        var upperBackwardDiagonal =
            Enumerable
                .Range(0, width - i)
                .Select(x => strings[height - x - 1][x + i])
                .ToList();

        count += CheckWord(upperBackwardDiagonal, word) + CheckWord(forwardColumnDiagonal, word);
    }


    for (var i = 0; i < height; i++)
    {
        var horizontal = strings[i].ToCharArray();

        var forwardRowDiagonal =
            Enumerable
                .Range(0, height - i)
                .Select(x => strings[x + i][x])
                .ToList();

        var lowerBackwardDiagonal =
            Enumerable
                .Range(0, i + 1)
                .Select(x => strings[i - x][x])
                .ToList();


        count += CheckWord(horizontal, word) + CheckWord(forwardRowDiagonal, word) +
                 CheckWord(lowerBackwardDiagonal, word);
    }


    return count;
}

int Part2(string[] strings)
{
    var count = 0;
    var height = strings.Length;
    var width = strings[0].Length;

    for (var row = 1; row < height - 1; row++)
    {
        for (var col = 1; col < width - 1; col++)
        {
            if (strings[row][col] != 'A') continue;

            if (((strings[row - 1][col - 1] == 'M' && strings[row + 1][col + 1] == 'S') ||
                 (strings[row - 1][col - 1] == 'S' && strings[row + 1][col + 1] == 'M')) &&
                ((strings[row - 1][col + 1] == 'M' && strings[row + 1][col - 1] == 'S') ||
                 (strings[row - 1][col + 1] == 'S' && strings[row + 1][col - 1] == 'M')))
            {
                count++;
            }
        }
    }

    return count;
}