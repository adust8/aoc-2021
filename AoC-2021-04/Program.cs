var input = File.ReadAllLines(@".\aoc-2021-04.txt");

var numbers = input[0]
    .Split(',', '\n', '\t').Select(num => int.Parse(num)).ToArray();


var i = 0;
var j = 0;
List<int[,]> matrixes = new();
var matrix = new int[5, 5];

foreach (var str in input.Skip(1).Where(str => !string.IsNullOrWhiteSpace(str)))
{
    var nums = str.Split(" ").Where(n => !string.IsNullOrWhiteSpace(n)).Select(n => int.Parse(n)).ToArray();
    for (var k = 0; k < 5; k++) matrix[j, k] = nums[k];

    if (j == 4)
    {
        matrixes.Add(matrix);
        matrix = new int[5, 5];
        j = 0;
    }
    else
    {
        j++;
    }
}

Console.WriteLine(Bingo());


List<(int row, int col)> GetIndexOfMarkedNumber(int[,] matrix, int number)
{
    var indexes = new List<(int, int)>();
    for (var i = 0; i < 5; i++)
    for (var j = 0; j < 5; j++)
        if (matrix[i, j] == number)
            indexes.Add((i, j));
    return indexes;
}

void Print(List<int[,]> matrixes)
{
    for (var i = 0; i < matrixes.Count; i++)
    {
        for (var j = 0; j < 5; j++)
        {
            for (var k = 0; k < 5; k++) Console.Write(matrixes[i][j, k] + " ");

            Console.WriteLine();
        }

        Console.WriteLine($"{i} matrix - {IsNumberExists(matrixes[i], 26)}");
        Console.WriteLine("\n");
    }
}

bool IsNumberExists(int[,] matrix, int num)
{
    for (var i = 0; i < 5; i++)
    for (var j = 0; j < 5; j++)
        if (matrix[i, j] == num)
            return true;
    return false;
}

bool IsWin(int[,] matrix, int row, int col)
{
    var rowRes = true;
    var colRes = true;
    for (var i = 0; i < 5; i++)
    {
        if (matrix[row, i] != -1)
            rowRes = false;
        if (matrix[i, col] != -1)
            colRes = false;
    }

    return rowRes || colRes;
}

int Bingo()
{
    var winners = new List<int[,]>();
    var uMatrixes = new List<int[,]>(matrixes); 
    var sum = 0;
    var lastN = 0;
    foreach (var number in numbers)
    {
        foreach (var matr in matrixes)
        {
            if (uMatrixes.Contains(matr))
            {
                var indexes = GetIndexOfMarkedNumber(matr, number);
                foreach (var index in indexes)
                {
                    matr[index.row, index.col] = -1;

                    if (IsWin(matr, index.row, index.col) && uMatrixes.Contains(matr))
                    {
                        winners.Add(matr);
                        uMatrixes.Remove(matr);
                        lastN = number;
                    }
                }
            }
        }
    }
    return CalcSum(winners.Last(),lastN);
}

int CalcSum(int[,] matr,int number)
{
    var sum = 0;
    for (var q = 0; q < 5; q++)
    for (var z = 0; z < 5; z++)
        if (matr[q, z] != -1)
            sum += matr[q, z];
    return sum * number;
}