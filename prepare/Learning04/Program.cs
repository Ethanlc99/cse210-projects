using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Jonny", "Coding C#");
        Console.WriteLine(assignment1.GetSummary());

        Console.WriteLine();

        WritingAssignment assignment2 = new WritingAssignment("Billy", "English 301", "Meditations");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInformation());

        Console.WriteLine();

        MathAssignment assignment3 = new MathAssignment("Trash", "Math 101", "Section 1", "5.6-6.9");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetHomeworkList());

    }
}