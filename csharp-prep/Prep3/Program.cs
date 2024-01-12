using System;

class Program
{
    static void Main(string[] args)
    {
        // Set up Random number and define variables
        Random rnd = new Random();
        int num = rnd.Next(1,101);
        int guess;
        
        // Console.WriteLine(num);

        // Console.WriteLine($"What is the magic number? {num}");

        // Loop that asks for input from user to guess the number until they get it right
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            Console.WriteLine($"{guess}");
            if (guess < num)
            {
                Console.WriteLine("Higher!");
            }
            else if (guess > num)
            {
                Console.WriteLine("Lower!");
            }
            else 
            {
                Console.WriteLine("You guessed it!");
            }
        } while (guess != num);
    }
}