using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your grade percentage");
        string response = Console.ReadLine();

        int grade = int.Parse(response);

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >=70)
        {
            letter = "C";
        }
        else if (grade >=60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade for the class was {letter}.");

        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine("Congratulations on passing the class!!");
        }
        else
        {
            Console.WriteLine("Looks like you didn't pass the class. That's ok! Schedule an appointment with an advisor, and we hope to see you back next semester!");
        }

    }
}