namespace PuzzleRunner;

public interface Puzzle
{
    
    public Dictionary<string[], long?> Part1TestCases { get; }
    
    public Dictionary<string[], long?> Part2TestCases { get; }
    
    public long Part1(string[] input);
    public long Part2(string[] input);
    
}