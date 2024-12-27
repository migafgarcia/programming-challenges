using Common;
using FluentAssertions;

var rawTestInput = await File.ReadAllLinesAsync("input.test");
var rawInput = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, rawTestInput, result =>
{
    result.Should().Be(14);
});
Utils.RunPuzzle(Part1, rawInput, result =>
{
    result.Should().Be(323);
});

Utils.RunPuzzle(Part2, rawTestInput, result =>
{
    result.Should().Be(34);
});
Utils.RunPuzzle(Part2, rawInput, result =>
{
    result.Should().Be(1077);
});

return;

int Part1(string[] strings)
{
    var input = strings.Select(item => item.ToArray()).ToArray();

    var antennas = new Dictionary<char, List<(int,int)>>();

    for (var i = 0; i < input.Length; i++)
    {
        for (var j = 0; j < input[0].Length; j++)
        {
            if (input[i][j] == '.')
            {
                continue;
            }

            if (!antennas.TryGetValue(input[i][j], out var value))
            {
                antennas.Add(input[i][j], [(i, j)]);
            }
            else
            {
                value.Add((i, j));
            }
            
        }
    }

    var antinodes = new HashSet<(int,int)>();
    
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

            if (IsPositionInBounds((antinode1X, antinode1Y), strings.Length, strings[0].Length))
            {
                antinodes.Add((antinode1X, antinode1Y));
            }
            if (IsPositionInBounds((antinode2X, antinode2Y), strings.Length, strings[0].Length))
            {
                antinodes.Add((antinode2X, antinode2Y));
            }
        }

    }

    
    return antinodes.Count;
}

bool IsPositionInBounds((int, int) position, int maxRow, int maxCol)
{
    return position.Item1 >= 0 && position.Item1 < maxRow && position.Item2 >= 0 && position.Item2 < maxCol;
}

int Part2(string[] strings)
{
    var input = strings.Select(item => item.ToArray()).ToArray();

    var antennas = new Dictionary<char, List<(int,int)>>();

    for (var i = 0; i < input.Length; i++)
    {
        for (var j = 0; j < input[0].Length; j++)
        {
            if (input[i][j] == '.')
            {
                continue;
            }

            if (!antennas.TryGetValue(input[i][j], out var value))
            {
                antennas.Add(input[i][j], [(i, j)]);
            }
            else
            {
                value.Add((i, j));
            }
            
        }
    }
    
    var antinodes = new HashSet<(int,int)>();
    
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
            var antinode1VarY =  a.Item2 >= b.Item2 ? distY : - distY;
            
            var antinode2 = a.Item1 > b.Item1 ? a : b;
            var antinode2VarX = distX;
            var antinode2VarY = b.Item2 >= a.Item2 ? distY : - distY;

            while (IsPositionInBounds(antinode1, strings.Length, strings[0].Length))
            {
                antinodes.Add(antinode1);
                antinode1 = (antinode1.Item1 + antinode1VarX, antinode1.Item2 + antinode1VarY);
            }

            while (IsPositionInBounds(antinode2, strings.Length, strings[0].Length))
            {
                antinodes.Add(antinode2);
                antinode2 = (antinode2.Item1 + antinode2VarX, antinode2.Item2 + antinode2VarY);
            }

        }

    }
    
    return antinodes.Count;
}
