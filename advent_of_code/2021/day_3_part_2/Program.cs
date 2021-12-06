List<string> oxygenGeneratorRating = File.ReadAllLines(args[0]).ToList();
List<string> co2ScrubberRating = new(oxygenGeneratorRating);

int oxygenGeneratorIndex = 0;
while (oxygenGeneratorRating.Count > 1)
{
    var itr = oxygenGeneratorRating.GetEnumerator();
    List<string> low = new();
    List<string> high = new();
    while (itr.MoveNext())
    {
        var line = itr.Current;
        if (line[oxygenGeneratorIndex] == '0')
            low.Add(line);
        else
            high.Add(line);
    }

    oxygenGeneratorRating = high.Count >= low.Count? high : low;
    oxygenGeneratorIndex++;
}

int co2ScrubberIndex = 0;
while (co2ScrubberRating.Count > 1)
{
    var itr = co2ScrubberRating.GetEnumerator();
    List<string> low = new();
    List<string> high = new();
    while (itr.MoveNext())
    {
        var line = itr.Current;
        if (line[co2ScrubberIndex] == '0')
            low.Add(line);
        else
            high.Add(line);
    }

    co2ScrubberRating = low.Count <= high.Count ? low : high;
    co2ScrubberIndex++;
}

int result = Convert.ToInt32(oxygenGeneratorRating.First(), 2) * Convert.ToInt32(co2ScrubberRating.First(), 2);

Console.WriteLine(result);
