using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        //Displaying that the funtions are working

        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFraction());
        Console.WriteLine(f1.GetDecimal());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFraction());
        Console.WriteLine(f2.GetDecimal());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFraction());
        Console.WriteLine(f3.GetDecimal());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFraction());
        Console.WriteLine(f4.GetDecimal());

        string _userchoice = "y";
        
        while (_userchoice == "y" || _userchoice == "Y")
        {

        Console.WriteLine("Your turn! Enter a number for the top: ");

        Fraction f5 = new Fraction();
        f5.SetTop(int.Parse(Console.ReadLine()));

        Console.WriteLine("Perfect, now enter a number for the bottom: ");
        f5.SetBottom(int.Parse(Console.ReadLine()));
        Console.WriteLine(f5.GetFraction());
        Console.WriteLine(f5.GetDecimal());

        Console.WriteLine("Would you like to try again? (Y/N) ");
        
        _userchoice = Console.ReadLine();
        }
        Console.WriteLine("Thanks for joining us!");
    }
}