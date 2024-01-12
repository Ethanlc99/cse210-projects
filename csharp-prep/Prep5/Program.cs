using System;

class Program
{  
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int num_squared = SquareNumber(num);
        DisplayResult(name, num_squared);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Thanks for entering your name {name}!");
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine($"{num}");
        return num;
    }

    static int SquareNumber(int num)
    {
        num = num*num;
        return num;
    }

    static void DisplayResult(string name, int num)
    {
        Console.WriteLine($"{name}, the square of your number is {num}");
    }

}