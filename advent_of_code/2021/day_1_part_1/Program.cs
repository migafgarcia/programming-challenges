
var input = await File.ReadAllLinesAsync(args[0]);

var count = 0;
int? previousValue = null;

foreach(var line in input)
{
    var lineInt = int.Parse(line);
    if (previousValue.HasValue && lineInt > previousValue)
    {
        count++;
    }
    previousValue = lineInt;
}

Console.WriteLine(count);
