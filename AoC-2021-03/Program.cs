var input = File.ReadAllLines(@".\aoc-2021-03.txt")
    .ToList();
Console.WriteLine(PartTwo(input));

int PartOne(List<string> input)
{
    string gamma = "";
    string epsilon = "";
    for (int i = 0; i < input.First().Length; i++)
    {
        int o = 0;
        int z = 0;
        for (int j = 0; j < input.Count; j++)
        {
            if (input[j][i] == '0')
                z++;
            else
                o++;
        }

        if (o > z)
        {
            gamma += "1";
            epsilon += "0";
        }
        else
        {
            gamma += "0";
            epsilon += "1";
        }
    }
    int gammaRate = Convert.ToInt32(gamma, 2);
    int epsilonRate = Convert.ToInt32(epsilon, 2);
    return gammaRate * epsilonRate;
}

long PartTwo(List<string> input) => GetOxygenRating(input) * GetCO2ScrubberRating(input);

long GetOxygenRating(List<string> input)
{
    int j = 0;
    while (input.Count > 1 && j < input.First().Length)
    {
        var o = 0;
        var z = 0;
        int i;
        for (i = 0; i < input.Count; i++)
        {
            switch (input[i][j])
            {
                case '0':
                    z++;
                    break;
                case '1':
                    o++;
                    break;
            }
        }

        input = o >= z
            ? input.Where(x => x[j] == '1').ToList()
            : input.Where(x => x[j] == '0').ToList();
        j++;
    }
    return Convert.ToInt64(input.Single(),2);
}

long GetCO2ScrubberRating(List<string> input)
{
    int j = 0;
    while (input.Count > 1 && j < input.First().Length)
    {
        var o = 0;
        var z = 0;
        int i;
        for (i = 0; i < input.Count; i++)
        {
            switch (input[i][j])
            {
                case '0':
                    z++;
                    break;
                case '1':
                    o++;
                    break;
            }
        }

        input = o >= z
            ? input.Where(x => x[j] == '0').ToList()
            : input.Where(x => x[j] == '1').ToList();
        j++;
    }
    return Convert.ToInt64(input.Single(), 2);
}


