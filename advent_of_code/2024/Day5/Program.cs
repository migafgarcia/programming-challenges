using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Common;

var testInput = await File.ReadAllLinesAsync("input.test");
var input = await File.ReadAllLinesAsync("input.txt");

Utils.RunPuzzle(Part1, testInput, 143);
Utils.RunPuzzle(Part1, input);
// Utils.RunPuzzle(Part2, testInput, 9);
// Utils.RunPuzzle(Part2, input, 1880);

return;

int Part1(string[] strings)
{

    var graph = new Dictionary<int, HashSet<int>>();

    foreach (var s in strings.TakeWhile(x => !string.IsNullOrEmpty(x)))
    {
        var split = s.Split('|').Select(int.Parse).ToArray();
        if (split.Length == 2)
        {
            var key = split[0];
            var value = split[1];

            if (!graph.ContainsKey(key))
            {
                graph.Add(key, []);
            }
            
            if (!graph.ContainsKey(value))
            {
                graph.Add(value, []);
            }

            graph[key].Add(value);
        }
    }
    
    var reachableNodes = GetAllReachableNodes(graph);
    var result = 0;
    foreach (var s in strings.SkipWhile(x => !string.IsNullOrEmpty(x)).Skip(1))
    {
        var pages = s.Split(',').Select(int.Parse).ToArray();
        var valueToAdd = pages[pages.Length / 2];
        for (var i = 1; i < pages.Length; i++)
        {
            var current = pages[i];
            var prev = pages[i - 1];

            if (reachableNodes.TryGetValue(prev, out var nodes) && !nodes.Contains(current))
            {
                valueToAdd = 0;
            }
            
        }

        result += valueToAdd;

    }

    return result;
}


static Dictionary<int, HashSet<int>> GetAllReachableNodes(Dictionary<int, HashSet<int>> graph)
{
    var result = new Dictionary<int, HashSet<int>>();

    foreach (var node in graph.Keys)
    {
        var visited = new HashSet<int>();
        DFS(graph, node, visited);
        result[node] = visited;
    }

    return result;
}

static void DFS(Dictionary<int, HashSet<int>> graph, int current, HashSet<int> visited)
{
    if (visited.Contains(current)) return;

    visited.Add(current);

    if (graph.TryGetValue(current, out var neighbors))
    {
        foreach (var neighbor in neighbors)
        {
            DFS(graph, neighbor, visited);
        }
    }
}

int Part2(string[] strings)
{
    throw new NotImplementedException();
}