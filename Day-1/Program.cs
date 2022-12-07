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
Console.WriteLine($"{max} total calories carried by the elf with the most");
