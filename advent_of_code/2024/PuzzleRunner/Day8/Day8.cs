namespace PuzzleRunner.Day8;

public class Day8 : Puzzle
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day8/test_input.txt"), 14 },
        { File.ReadAllLines("Day8/puzzle_input.txt"), 323 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day8/test_input.txt"), 34 },
        { File.ReadAllLines("Day8/puzzle_input.txt"), 1077 }
    };

    public long Part1(string[] input)
    {
        var arrayInput = input.Select(item => item.ToArray()).ToArray();

        var antennas = new Dictionary<char, List<(int, int)>>();

        for (var i = 0; i < arrayInput.Length; i++)
        {
            for (var j = 0; j < arrayInput[0].Length; j++)
            {
                if (arrayInput[i][j] == '.')
                {
                    continue;
                }

                if (!antennas.TryGetValue(arrayInput[i][j], out var value))
                {
                    antennas.Add(arrayInput[i][j], [(i, j)]);
                }
                else
                {
                    value.Add((i, j));
                }
            }
        }

        var antinodes = new HashSet<(int, int)>();

        foreach (var (_, antennasPosition) in antennas)
        {
            var combinations =
                antennasPosition
                    .SelectMany((x, i) => antennasPosition.Skip(i + 1), (a, b) => (a, b));

            foreach (var (a, b) in combinations)
            {
                var distX = Math.Abs(a.Item1 - b.Item1);
                var distY = Math.Abs(a.Item2 - b.Item2);

                var antinode1X = Math.Min(a.Item1, b.Item1) - distX;
                var antinode2X = Math.Max(a.Item1, b.Item1) + distX;

                var antinode1Y = a.Item2 >= b.Item2 ? a.Item2 + distY : a.Item2 - distY;
                var antinode2Y = b.Item2 >= a.Item2 ? b.Item2 + distY : b.Item2 - distY;

                if (IsPositionInBounds((antinode1X, antinode1Y), arrayInput.Length, arrayInput[0].Length))
                {
                    antinodes.Add((antinode1X, antinode1Y));
                }

                if (IsPositionInBounds((antinode2X, antinode2Y), arrayInput.Length, arrayInput[0].Length))
                {
                    antinodes.Add((antinode2X, antinode2Y));
                }
            }
        }


        return antinodes.Count;
    }

    public long Part2(string[] input)
    {
        var arrayInput = input.Select(item => item.ToArray()).ToArray();

        var antennas = new Dictionary<char, List<(int, int)>>();

        for (var i = 0; i < arrayInput.Length; i++)
        {
            for (var j = 0; j < arrayInput[0].Length; j++)
            {
                if (arrayInput[i][j] == '.')
                {
                    continue;
                }

                if (!antennas.TryGetValue(arrayInput[i][j], out var value))
                {
                    antennas.Add(arrayInput[i][j], [(i, j)]);
                }
                else
                {
                    value.Add((i, j));
                }
            }
        }

        var antinodes = new HashSet<(int, int)>();

        foreach (var (_, antennasPosition) in antennas)
        {
            var combinations =
                antennasPosition
                    .SelectMany((x, i) => antennasPosition.Skip(i + 1), (a, b) => (a, b));

            foreach (var (a, b) in combinations)
            {
                var distX = Math.Abs(a.Item1 - b.Item1);
                var distY = Math.Abs(a.Item2 - b.Item2);

                var antinode1 = a.Item1 <= b.Item1 ? a : b;
                var antinode1VarX = -distX;
                var antinode1VarY = a.Item2 >= b.Item2 ? distY : -distY;

                var antinode2 = a.Item1 > b.Item1 ? a : b;
                var antinode2VarX = distX;
                var antinode2VarY = b.Item2 >= a.Item2 ? distY : -distY;

                while (IsPositionInBounds(antinode1, arrayInput.Length, arrayInput[0].Length))
                {
                    antinodes.Add(antinode1);
                    antinode1 = (antinode1.Item1 + antinode1VarX, antinode1.Item2 + antinode1VarY);
                }

                while (IsPositionInBounds(antinode2, arrayInput.Length, arrayInput[0].Length))
                {
                    antinodes.Add(antinode2);
                    antinode2 = (antinode2.Item1 + antinode2VarX, antinode2.Item2 + antinode2VarY);
                }
            }
        }

        return antinodes.Count;
    }

    bool IsPositionInBounds((int, int) position, int maxRow, int maxCol)
    {
        return position.Item1 >= 0 && position.Item1 < maxRow && position.Item2 >= 0 && position.Item2 < maxCol;
    }
}