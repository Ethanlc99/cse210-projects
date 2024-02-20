class Activity
{
//ATTRIBUTES

    //Defines all Member Variables
    private DateTime _startSpinner = DateTime.Now;
    private DateTime _endSpinner = DateTime.Now;
    protected DateTime _startTime = DateTime.Now;
    protected DateTime _endTime = DateTime.Now;
    private string[] _startMessage = {"Welcome to the ", " Activity!"};
    private string[] _endingMessage = {"Well done!", "You have completed another ", " seconds of the ", " Activity"};

    private int _activityDuration;

    private string _activityName;

//METHODS

    public void SetName(string name)
    {
        _activityName = name;
    }

    //Displays start message with appropriate activity name
    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine(_startMessage[0] + _activityName + _startMessage[1]);
    }

    //Displays at the end of each activity, giving information on what they accomplished 
    public void DisplayEndMessage()
    {
        Console.WriteLine("\n\n" + _endingMessage[0] + "\n" + _endingMessage[1] + _activityDuration + _endingMessage[2] + _activityName + _endingMessage[3]);
        DisplaySpinner(10);
        Console.Clear();
    }

    //Sets the duration of the activity based on user input
    public int SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _activityDuration = int.Parse(Console.ReadLine());
        return _activityDuration;
    }

    public int GetDuration()
    {
        return _activityDuration;
    }

    // Displays "Get Ready" message
    public void DisplayGetReady()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplaySpinner(3);
        Console.Clear();
    }

    //Displays spinner animation for set time at 1 second intervals
    public void DisplaySpinner(int time)
    {
        _startSpinner = DateTime.Now;
        _endSpinner = _startSpinner.AddSeconds(time);
        while (DateTime.Now < _endSpinner)
        {
            Console.Write("/");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(125);
            Console.Write("\b \b");
        }
    }



}