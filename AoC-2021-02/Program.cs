List<string> instructions = File.ReadAllLines(@".\aoc-2021-02.txt").ToList();
int res = PartTwo(instructions);
Console.WriteLine(res);


int PartOne(List<string> instructions)
{
    Dictionary<string, int> dict = new Dictionary<string, int>();

    foreach (var ins in instructions.Select(x => x.Split(" ")))
    {
        string direction = ins[0];
        int x = int.Parse(ins[1]);
        if (!dict.ContainsKey(direction))
            dict.Add(direction, x);
        else
            dict[direction] += x;
    }
    return dict["forward"] * (dict["down"] - dict["up"]);
}
int PartTwo(List<string> instructions)
{
    int aim = 0;
    int depth = 0;
    int horizontal = 0;
    foreach (string ins in instructions)
    {
        string direction = ins.Split(" ")[0];
        int x = int.Parse(ins.Split(" ")[1]);
        switch (direction)
        {
            case "down":
                {
                    aim += x;
                }
                break;
            case "up":
                {
                    aim -= x;
                }
                break;
            case "forward":
                {
                    horizontal += x;
                    depth += aim * x;
                }
                break;
            default: throw new Exception();
        }
    }
    return horizontal * depth;
}