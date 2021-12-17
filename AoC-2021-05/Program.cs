int[,] coordinates = new int[1_000,1_000];
int overlaps = 0;
FillMatrix(0);
foreach (var str in File.ReadAllLines(@".\aoc-2021-05.txt"))
{
    var coord = str.Split(" -> ")
        .Select(s => s.Split(",")
            .Select(int.Parse)
            .ToArray())
        .Select(c => new Tuple<int, int>(c[0],c[1]))
        .ToArray();

    if (coord[0].Item1 == coord[1].Item1)
    {
        for (int i = Math.Min(coord[0].Item2, coord[1].Item2); i <= Math.Max(coord[0].Item2, coord[1].Item2); i++)
        {
            if (coordinates[i, coord[0].Item1] == 1)
                overlaps++;
            coordinates[i, coord[0].Item1]++;
        }
    }
    else if (coord[0].Item2 == coord[1].Item2)
    {
        for (int i = Math.Min(coord[0].Item1, coord[1].Item1); i <= Math.Max(coord[0].Item1, coord[1].Item1); i++)
        {
            if (coordinates[coord[0].Item2, i] == 1)
                overlaps++;
            coordinates[coord[0].Item2,i]++;
        }
    }
        
}
Console.WriteLine(overlaps);

void FillMatrix(int num)
{
    for (int i = 0; i < 1_000; i++)
    {
        for (int j = 0; j < 1_000; j++)
        {
            coordinates[i, j] = num;
        }
    }
}
