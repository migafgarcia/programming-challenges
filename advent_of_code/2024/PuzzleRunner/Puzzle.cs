namespace PuzzleRunner;

public interface Puzzle<T> where T : struct
{
    
    public Dictionary<string[], T?> Part1TestCases { get; }
    
    public Dictionary<string[], T?> Part2TestCases { get; }
    
    public T Part1(string[] input);
    public T Part2(string[] input);
    
}