using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> nums = new List<int>();;
        int response;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            response = int.Parse(Console.ReadLine());
            Console.WriteLine($"{response}");   
            if (response != 0){
            nums.Add(response);
            }
        } while (response != 0);

        int sum = nums.Sum();
        double mean = nums.Average();
        int max = nums.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The Average Value is: {mean}");
        Console.WriteLine($"The largest number is: {max}");
    }
}