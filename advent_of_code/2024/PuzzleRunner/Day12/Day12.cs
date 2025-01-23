namespace PuzzleRunner.Day12;

public class Day12 : Puzzle
{
    private readonly string[] _testInput = File.ReadAllLines("Day12/test_input.txt");
    private readonly string[] _puzzleInput = File.ReadAllLines("Day12/puzzle_input.txt");

    public Dictionary<string[], long?> Part1TestCases => new()
    {
        {
            """
                AAAA
                BBCD
                BBCC
                EEEC
                """.Split(Environment.NewLine),
            140
        },
        {
            """
                OOOOO
                OXOXO
                OOOOO
                OXOXO
                OOOOO
                """.Split(Environment.NewLine),
            772
        },
        { _testInput, 1930 },
        { _puzzleInput, 1375476 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        {
            """
                AAAAAA
                AAABBA
                AAABBA
                ABBAAA
                ABBAAA
                AAAAAA
                """.Split(Environment.NewLine),
            368
        },
        {
            """
                EEEEE
                EXXXX
                EEEEE
                EXXXX
                EEEEE
                """.Split(Environment.NewLine),
            236
        },
        {
            """
                AAAA
                BBCD
                BBCC
                EEEC
                """.Split(Environment.NewLine),
            80
        },
        {
            """
                OOOOO
                OXOXO
                OOOOO
                OXOXO
                OOOOO
                """.Split(Environment.NewLine),
            436
        },
        { _testInput, 1206 },
        { _puzzleInput, 821372 }
    };

    public long Part2(string[] input)
    {
        var visited = new HashSet<(int, int)>();
        var result = 0;
        
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[0].Length; col++)
            {
                if (visited.Contains((row, col)))
                {
                    continue;
                }
                
                var plants = new Plant[input.Length, input[0].Length];
        
                for (var i = 0; i < plants.GetLength(0); i++)
                {
                    for (var j = 0; j < plants.GetLength(1); j++)
                    {
                        plants[i, j] = new Plant(false, false, false, false);
                    }
                }

                var plantType = input[row][col];

                var plotsToVisit = new Stack<(int, int)>();
                plotsToVisit.Push((row, col));

                var area = 0;
                var perimeter = 0;

                while (plotsToVisit.Count > 0)
                {
                    var (r, c) = plotsToVisit.Pop();

                    if (!visited.Add((r, c)))
                    {
                        continue;
                    }

                    area++;

                    var left = (x: r, y: c - 1);
                    var right = (x: r, y: c + 1);
                    var up = (x: r - 1, y: c);
                    var down = (x: r + 1, y: c);

                    if (!IsInBounds(input, left) || input[left.x][left.y] != plantType)
                    {
                        plants[r, c].LeftWall = true;
                    }
                    else if (!visited.Contains(left))
                    {
                        plotsToVisit.Push(left);
                    }

                    if (!IsInBounds(input, right) || input[right.x][right.y] != plantType)
                    {
                        plants[r, c].RightWall = true;
                    }
                    else if (!visited.Contains(right))
                    {
                        plotsToVisit.Push(right);
                    }


                    if (!IsInBounds(input, up) || input[up.x][up.y] != plantType)
                    {
                        plants[r, c].UpWall = true;
                    }
                    else if (!visited.Contains(up))
                    {
                        plotsToVisit.Push(up);
                    }

                    if (!IsInBounds(input, down) || input[down.x][down.y] != plantType)
                    {
                        plants[r, c].DownWall = true;
                    }
                    else if (!visited.Contains(down))
                    {
                        plotsToVisit.Push(down);
                    }
                }

                
                // horizontal
                for (var r = 0; r < plants.GetLength(0); r++)
                {

                    var upWallRow = Enumerable.Range(0, plants.GetLength(1))
                        .Select(x => plants[r, x].UpWall)
                        .ToArray();
                    
                    var downWallRow = Enumerable.Range(0, plants.GetLength(1))
                        .Select(x => plants[r, x].DownWall)
                        .ToArray();
                    
                    var upWalls = upWallRow
                        .Select((num, index) => (index == 0 && num) || (num && !upWallRow[index - 1]))
                        .Count(isNewSequence => isNewSequence);
                    
                    var downWalls = downWallRow
                        .Select((num, index) => (index == 0 && num) || (num && !downWallRow[index - 1]))
                        .Count(isNewSequence => isNewSequence);
                    
                    perimeter += upWalls + downWalls;
                }

                // vertical
                for (var c = 0; c < plants.GetLength(1); c++)
                {

                    var leftWallCol = Enumerable.Range(0, plants.GetLength(0))
                        .Select(x => plants[x, c].LeftWall)
                        .ToArray();
                    
                    var rightWallCol = Enumerable.Range(0, plants.GetLength(0))
                        .Select(x => plants[x, c].RightWall)
                        .ToArray();
                    
                    var leftWalls = leftWallCol
                        .Select((num, index) => (index == 0 && num) || (num && !leftWallCol[index - 1]))
                        .Count(isNewSequence => isNewSequence);
                    
                    var rightWalls = rightWallCol
                        .Select((num, index) => (index == 0 && num) || (num && !rightWallCol[index - 1]))
                        .Count(isNewSequence => isNewSequence);
                    
                    perimeter += leftWalls + rightWalls;
                }


                result += area * perimeter;
            }
        }

        return result;
    }

    private class Plant(bool upWall, bool downWall, bool leftWall, bool rightWall)
    {
        public bool UpWall { get; set; } = upWall;
        public bool DownWall { get; set; } = downWall;
        public bool LeftWall { get; set; } = leftWall;
        public bool RightWall { get; set; } = rightWall;
    }

    private static bool IsInBounds(string[] input, (int row, int col) position)
    {
        return position.row >= 0 && position.row < input.Length && position.col >= 0 && position.col < input[0].Length;
    }

    public long Part1(string[] input)
    {
        var visited = new HashSet<(int, int)>();
        var result = 0;
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[0].Length; col++)
            {
                if (visited.Contains((row, col)))
                {
                    continue;
                }

                var plantType = input[row][col];

                var plotsToVisit = new Stack<(int, int)>();
                plotsToVisit.Push((row, col));

                var area = 0;
                var perimeter = 0;

                while (plotsToVisit.Count > 0)
                {
                    var (r, c) = plotsToVisit.Pop();

                    if (!visited.Add((r, c)))
                    {
                        continue;
                    }

                    area++;

                    var adjacentPlots = new List<(int, int)>()
                    {
                        (r, c - 1),
                        (r - 1, c),
                        (r, c + 1),
                        (r + 1, c)
                    };

                    foreach (var (adjRow, adjCol) in adjacentPlots)
                    {
                        if (!IsInBounds(input, (adjRow, adjCol)) || input[adjRow][adjCol] != plantType)
                        {
                            perimeter++;
                        }
                        else if (!visited.Contains((adjRow, adjCol)))
                        {
                            plotsToVisit.Push((adjRow, adjCol));
                        }
                    }
                }

                result += area * perimeter;
            }
        }

        return result;
    }
}