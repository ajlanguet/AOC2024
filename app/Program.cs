﻿/*
// Day 1
string filePath = "../AOCProblemOne/AOCproblem1.txt";

string[] lines = File.ReadAllLines(filePath);

List<int> row1 = new List<int>();
List<int> row2 = new List<int>();


foreach(string line in lines){
    int[] numbers = line.GiveIntegers("   ");
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
    int[] numbers = line.GiveIntegers(" ");
    levels.Add(numbers);
}

Console.WriteLine("Aoc Day 2 Part 1 Ans:");
Console.WriteLine(AocDayTwo.PartOne(levels));
Console.WriteLine("Aoc Day 2 Part 2 Ans:");
Console.WriteLine(AocDayTwo.PartTwo(levels));

// Day 3

string filePath3 = "../AOCProblemThree/AOCproblem3.txt";

string[] lines3 = File.ReadAllLines(filePath3);

Console.WriteLine("Aoc Day 3 Part 1 Ans:");
Console.WriteLine(AocDayThree.PartOne(lines3));
Console.WriteLine("Aoc Day 3 Part 2 Ans:");
Console.WriteLine(AocDayThree.PartTwo(lines3));

// Day 4

string filePath4 = "../AOCProblemFour/AOCproblem4.txt";

string[] lines4 = File.ReadAllLines(filePath4);

Console.WriteLine("Aoc Day 4 Part 1 Ans:");
Console.WriteLine(AocDayFour.PartOne(lines4));
Console.WriteLine("Aoc Day 4 Part 2 Ans:");
Console.WriteLine(AocDayFour.PartTwo(lines4));

// Day 5

string filePath5a = "../AOCProblemFive/AOCproblem5a.txt";

string filePath5b = "../AOCProblemFive/AOCproblem5b.txt";

string [] lines5a = File.ReadAllLines(filePath5a);

string [] lines5b = File.ReadAllLines(filePath5b);

List<int[]> order = new List<int[]>();
List<int[]> update = new List<int[]>();

foreach(string line5a in lines5a)
{
    order.Add(line5a.GiveIntegers("|"));
}

foreach(string line5b in lines5b)
{
    update.Add(line5b.GiveIntegers(","));
}

Console.WriteLine("Aoc Day 5 Part 1 Ans:");
Console.WriteLine(AocDayFive.PartOne(order, update));
Console.WriteLine("Aoc Day 5 Part 2 Ans:");
Console.WriteLine(AocDayFive.PartTwo(order, update));

// Day 6

string filePath6 =  "../AOCProblemSix/AOCproblem6.txt";

string [] lines6 = File.ReadAllLines(filePath6);

Console.WriteLine("Aoc Day 6 Part 1 Ans:");
Console.WriteLine(AocDaySix.PartOne(lines6));
Console.WriteLine("Aoc Day 6 Part 2 Ans:");
Console.WriteLine(AocDaySix.PartTwo(lines6));
*/

// Day 7
string filePath7 =  "../AOCProblemSeven/AOCproblem7.txt";

string [] lines7 = File.ReadAllLines(filePath7);

List<long> keys = new List<long>();
List<long[]> vals = new List<long[]>();

foreach(string line7 in lines7)
{
    string[] initial_split = line7.Split(": ");

    keys.Add(Int64.Parse(initial_split[0]));
    vals.Add(initial_split[1].GiveIntegers(" "));
}

Console.WriteLine("Aoc Day 7 Part 1 Ans:");
Console.WriteLine(AocDaySeven.PartOne(keys, vals));
Console.WriteLine("Aoc Day 7 Part 2 Ans:");
Console.WriteLine(AocDaySeven.PartTwo(keys, vals));
