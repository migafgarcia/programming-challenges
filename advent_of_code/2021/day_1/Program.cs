
var input = await File.ReadAllLinesAsync(args[0]);

#region Part One

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

#endregion

#region Part Two

int slidingWindowSize = 3;

int[] slidingWindow = new int[slidingWindowSize];

int previousSum = 0;
int slidingCounter = 0;

for(int i = 0; i < input.Length; i++)
{

    int lineInt = int.Parse(input[i]);

    slidingWindow[i % slidingWindowSize] = lineInt;
    var currentSum = slidingWindow.Sum();

    if (i >= slidingWindowSize && currentSum > previousSum)
    {
        slidingCounter++;
    }

    previousSum = currentSum;
}
Console.WriteLine(slidingCounter);
#endregion