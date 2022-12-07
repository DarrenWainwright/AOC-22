// AOC '22 Day 1

// Part 1 - find calorie count for elf carrying the most
int max = 0;
int temp = 0;
File.ReadAllLines("input.txt").ToList().ForEach(line =>
{
    if (line != string.Empty)
        temp += int.Parse(line);
    else
    {
        max = temp > max ? temp : max;
        temp = 0;
    }
});
Console.WriteLine($"Part 1: {max} total calories carried by the elf with the most");


// Part 2 - find calorie total for top 3
temp = 0;
List<int> calsPerElf = new List<int>();
File.ReadAllLines("input.txt").ToList().ForEach(line =>
{
    if (line != string.Empty)
        temp += int.Parse(line);
    else
    {
        calsPerElf.Add(temp);
        temp = 0;
    }
});
var top3Total = calsPerElf.OrderByDescending(l => l).Take(3).Sum();
Console.WriteLine($"Part 2: {top3Total} total calories carried by the top 3 elves");
