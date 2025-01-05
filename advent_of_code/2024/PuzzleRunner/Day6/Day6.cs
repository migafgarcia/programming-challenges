namespace PuzzleRunner.Day6;

public class Day6 : Puzzle<long>
{
    public Dictionary<string[], long?> Part1TestCases => new()
    {
        { File.ReadAllLines("Day6/test_input.in"), 41 },
        { File.ReadAllLines("Day6/puzzle_input.in"), 5208 }
    };

    public Dictionary<string[], long?> Part2TestCases => new()
    {
        { File.ReadAllLines("Day6/test_input.in"), 6 },
        { File.ReadAllLines("Day6/puzzle_input.in"), 1972 }
    };

    public long Part1(string[] input)
    {
        var arrayInput = input.Select(item => item.ToArray()).ToArray();

        var initialPosition = FindInitialPosition(arrayInput);

        var directionIndex = 0;

        var count = 1;

        for (
            var current = initialPosition;
            !IsNextPositionOutOfBounds(current, directionIndex, arrayInput.Length, arrayInput[0].Length);
            current += GetDirection(directionIndex)
        )
        {
            // obstacle, we must turn 90
            while (IsNextPositionObstacle(arrayInput, current, directionIndex))
            {
                directionIndex = (directionIndex + 1) % 4;
            }

            if (arrayInput[current.Row][current.Col] != 'X')
            {
                arrayInput[current.Row][current.Col] = 'X';
                count++;
            }
        }

        return count;
    }

    public long Part2(string[] input)
    {
        var arrayInput = input.Select(item => item.ToArray()).ToArray();

        var initialPosition = FindInitialPosition(arrayInput);

        if (initialPosition is null)
        {
            throw new Exception("Could not find initial position.");
        }

        var count = 0;


        // TODO: This code is very bad, inefficient and not recommended for human eyes
        // Another alternative would be to place obstacles in front of the guards path, reducing the obstacles we need to test
        for (var i = 0; i < arrayInput.Length; i++)
        {
            for (var j = 0; j < arrayInput[i].Length; j++)
            {
                if (arrayInput[i][j] == '#')
                {
                    continue;
                }

                var back = arrayInput[i][j];
                arrayInput[i][j] = '#';
                if (HasLoop(arrayInput, initialPosition, 0))
                {
                    count++;
                }

                arrayInput[i][j] = back;
            }
        }

        return count;
    }

    private readonly Position[] _directions =
    [
        new(row: -1, col: 0), // up
        new(row: 0, col: 1), // right
        new(row: 1, col: 0), // down
        new(row: 0, col: -1) // left
    ];

    private Position GetDirection(int directionIndex)
    {
        return _directions[directionIndex];
    }

    private bool IsNextPositionOutOfBounds(Position position, int directionIndex, int maxRow, int maxCol)
    {
        var direction = GetDirection(directionIndex);
        var row = position.Row + direction.Row;
        var col = position.Col + direction.Col;
        return row < 0 || row >= maxRow || col < 0 || col >= maxCol;
    }


// Checks if a loop exists given a starting position and direction 
private bool HasLoop(char[][] input, Position position, int currentDirection)
    {
        // Contains each position visited and the directions from where they arrived at that position
        var visited = new Dictionary<Position, HashSet<int>>();
        var current = new Position(position);


        while (true)
        {
            if (IsNextPositionOutOfBounds(current, currentDirection, input.Length, input[0].Length))
            {
                return false;
            }

            if (visited.TryGetValue(current, out var directionsSet))
            {
                if (!directionsSet.Add(currentDirection))
                {
                    return true;
                }
            }
            else
            {
                visited[current] = [currentDirection];
            }

            while (IsNextPositionObstacle(input, current, currentDirection))
            {
                currentDirection = (currentDirection + 1) % 4;
            }

            current += GetDirection(currentDirection);
        }
    }

    private bool IsNextPositionObstacle(char[][] input, Position position, int directionIndex)
    {
        var direction = GetDirection(directionIndex);
        return input[position.Row + direction.Row][position.Col + direction.Col] == '#';
    }

    private Position FindInitialPosition(char[][] chars)
    {
        Position? position = null;
        for (var i = 0; i < chars.Length; i++)
        {
            var row = chars[i];
            for (var j = 0; j < row.Length; j++)
            {
                var col = row[j];
                if (col == '^')
                {
                    position = new Position(i, j);
                }
            }
        }

        if (position is null)
        {
            throw new Exception("Could not find initial position.");
        }

        return position;
    }
}