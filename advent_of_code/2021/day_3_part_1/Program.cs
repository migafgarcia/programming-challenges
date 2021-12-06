string[] lines = File.ReadAllLines(args[0]);

int rowLength = lines[0].Length;

string gammaRate = string.Empty;
string epsilonRate = string.Empty;

for (int i = 0; i < rowLength; i++)
{
    int highCount = 0;
    int lowCount = 0;
    foreach (string line in lines)
    {
        if (line[i] == '0')
            lowCount++;
        else
            highCount++;
    }

    gammaRate += (highCount > lowCount ? '1' : '0');
    epsilonRate += (highCount > lowCount ? '0' : '1');
}

int gammaRateInteger = Convert.ToInt32(gammaRate, 2);
int epsilonRateInteger = Convert.ToInt32(epsilonRate, 2);


Console.WriteLine(gammaRateInteger * epsilonRateInteger);