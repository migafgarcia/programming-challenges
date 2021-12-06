string[] lines = File.ReadAllLines(args[0]);

int currentHorizontalPosition = 0;
int currentDepth = 0;


foreach(string line in lines)
{
    string[] parts = line.Split(" ");

    switch (parts[0]) {
        case "forward":
            currentHorizontalPosition += Convert.ToInt32(parts[1]);
            break;
        case "up":
            currentDepth -= Convert.ToInt32(parts[1]);
            break;
        case "down":
            currentDepth += Convert.ToInt32(parts[1]);
            break;
        default:
            throw new Exception("unrecognized command " + parts[0]);
    }
}
Console.WriteLine(currentDepth * currentHorizontalPosition);
