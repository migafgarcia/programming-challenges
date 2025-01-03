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