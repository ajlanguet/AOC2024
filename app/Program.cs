
// Day 1
string filePath = "../AOCProblemOne/AOCproblem1.txt";

string[] lines = File.ReadAllLines(filePath);

List<int> row1 = new List<int>();
List<int> row2 = new List<int>();


foreach(string line in lines){
    int[] numbers = line.GivesIntegersWithThreeSpace();
    row1.Add(numbers[0]);
    row2.Add(numbers[1]);
}

Console.WriteLine("Aoc Day 1 Part 1 Ans:");
Console.WriteLine(AocDayOne.PartOne(row1, row2));
Console.WriteLine("Aoc Day 1 Part 2 Ans:");
Console.WriteLine(AocDayOne.PartTwo(row1, row2));


// Day 2
string filePath2 = "../AOCProblemTwo/AOCproblem2.txt";

string[] lines2 = File.ReadAllLines(filePath2);

List<int[]> levels = new List<int[]>();

foreach(string line in lines2)
{
    int[] numbers = line.GiveIntegers();
    levels.Add(numbers);
}

Console.WriteLine("Aoc Day 2 Part 1 Ans");
Console.WriteLine(AocDayTwo.PartOne(levels));
Console.WriteLine("Aoc Day 2 Part 2 Ans");
Console.WriteLine(AocDayTwo.PartTwo(levels));


