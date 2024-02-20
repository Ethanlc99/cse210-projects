class BreathingActivity : Activity
{
//ATTRIBUTES
    private string _startText = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. \nThis will help you to relax and release stress. \n";

//METHODS

    public void DisplayInfo()
    {
        Console.WriteLine(_startText);
    }

    //Displays breathing instructions for as long as the user wants
    public void DisplayBreathing(int time)
    {
        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(time);
        while (DateTime.Now < _endTime)
        {
            Console.Write("\n\nBreathe in...");
            Console.Write("6");
            Thread.Sleep(1500);
            Console.Write("\b \b");
            Console.Write("5");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("4");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("0");
            Thread.Sleep(1100);
            Console.Write("\b \b");

            Console.Write("\n\nNow breathe out...");
            Console.Write("4");
            Thread.Sleep(1500);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1100);
            Console.Write("\b \b");
            Console.Write("0");
            Thread.Sleep(1100);
            Console.Write("\b \b");
        }
    }



}