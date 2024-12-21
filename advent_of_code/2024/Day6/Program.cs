using Common;
using FluentAssertions;

var directions = new Position[]
{
    new(row: -1, col: 0), // up
    new(row: 0, col: 1), // right
    new(row: 1, col: 0), // down
    new(row: 0, col: -1) // left
};

var rawTestInput = await File.ReadAllLinesAsync("input.test");
var rawInput = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, rawTestInput, result =>
{
    result.Should().Be(41);
});
Utils.RunPuzzle(Part1, rawInput, result =>
{
    result.Should().Be(5208);
});
Utils.RunPuzzle(Part2, rawTestInput, result =>
{
    result.Should().Be(6);
});
Utils.RunPuzzle(Part2, rawInput, result =>
{
    result.Should().Be(1972);
});

Utils.RunPuzzle(Part2, await File.ReadAllLinesAsync("test1.txt"), result =>
{
    result.Should().Be(1);
});

Utils.RunPuzzle(Part2, await File.ReadAllLinesAsync("test2.txt"), result =>
{
    result.Should().Be(1);
});

return;

int Part1(string[] strings)
{
    var input = strings.Select(item => item.ToArray()).ToArray();
    
    var initialPosition = FindInitialPosition(input);
    
    var directionIndex = 0;
    
    var count = 1;

    for (
        var current = initialPosition; 
        !IsNextPositionOutOfBounds(current, directionIndex, strings.Length, strings[0].Length); 
        current += GetDirection(directionIndex)
    )
    {
        // obstacle, we must turn 90
        while (IsNextPositionObstacle(input, current, directionIndex))
        {
            directionIndex = (directionIndex + 1) % 4; 
        }
        
        if (input[current.Row][current.Col] != 'X')
        {
            input[current.Row][current.Col] = 'X';
            count++;
        }
    }
    return count;
}

int Part2(string[] strings)
{
    var input = strings.Select(item => item.ToArray()).ToArray();

    var initialPosition = FindInitialPosition(input);
    
    if (initialPosition is null)
    {
        throw new Exception("Could not find initial position.");
    }

    var count = 0;

    
    // TODO: This code is very bad, inefficient and not recommended for human eyes
    // Another alternative would be to place obstacles in front of the guards path, reducing the obstacles we need to test
    for (var i = 0; i < strings.Length; i++)
    {
        for (var j = 0; j < strings[i].Length; j++)
        {
            if (input[i][j] == '#')
            {
                continue;
            }

            var back = input[i][j];
            input[i][j] = '#';
            if (HasLoop(input, initialPosition, 0))
            {
                count++;
            }

            input[i][j] = back;
        }
    }

    return count;
}


Position GetDirection(int directionIndex)
{
    return directions[directionIndex];
}

bool IsNextPositionOutOfBounds(Position position, int directionIndex, int maxRow, int maxCol)
{
    var direction = GetDirection(directionIndex);
    var row = position.Row + direction.Row;
    var col = position.Col + direction.Col;
    return row < 0 || row >= maxRow || col < 0 || col >= maxCol;
}


// Checks if a loop exists given a starting position and direction 
bool HasLoop(char[][] input, Position position, int currentDirection)
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

bool IsNextPositionObstacle(char[][] input, Position position, int directionIndex)
{
    var direction = GetDirection(directionIndex);
    return input[position.Row + direction.Row][position.Col + direction.Col] == '#';
}

Position FindInitialPosition(char[][] chars)
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


internal class Position(int row, int col)
{
    
    public int Row { get; private set; } = row;
    public int Col { get; private set; } = col;

    public Position(Position position) : this(position.Row, position.Col)
    {
        
    }
    
    public static Position operator +(Position a, Position b)
    {
        a.Row += b.Row;
        a.Col += b.Col;
        return a;
    }
    
    public static bool operator ==(Position left, Position right)
    {
        return left.Row == right.Row && left.Col == right.Col;
    }

    public static bool operator !=(Position left, Position right)
    {
        return left.Row != right.Row || left.Col != right.Col;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return this == (Position)obj;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Col);
    }
}
