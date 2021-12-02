List<int> depths = File.ReadAllLines(@".\aoc-2021-01.txt")
    .Select(line => Int32.Parse(line))
    .ToList();
Console.WriteLine(PartTwo(depths));

int PartOne(List<int> depths)
{
    int prev = depths.First();
    int res = 0;
    for (int i = 1; i < depths.Count; i++)
    {
        if (depths[i] > prev)
            res++;

        prev = depths[i];
    }
    return res;
}


int PartTwo(List<int> depths)
{
    int count = 0;
    for (int i = 0; i < depths.Count - 3; i++)
    {
        if (depths[i] + depths[i + 1] + depths[i + 2] < depths[i + 1] + depths[i + 2] + depths[i + 3])
            count++;
    }

    return count;
}