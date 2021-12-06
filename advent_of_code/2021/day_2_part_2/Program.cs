string[] lines = File.ReadAllLines(args[0]);

int currentHorizontalPosition = 0;
int currentDepth = 0;
int currentAim = 0;


foreach (string line in lines)
{
    string[] parts = line.Split(" ");

    var value = Convert.ToInt32(parts[1]);

    switch (parts[0])
    {
        case "forward":
            currentHorizontalPosition += value;
            currentDepth += currentAim * value;
            break;
        case "up":
            currentAim -= value;
            break;
        case "down":
            currentAim += value;
            break;
        default:
            throw new Exception("unrecognized command " + parts[0]);
    }
}
Console.WriteLine(currentDepth * currentHorizontalPosition);
