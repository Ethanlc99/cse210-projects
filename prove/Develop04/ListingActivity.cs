class ListingActivity : Activity
{
//ATTRIBUTES

     private string _startText = "\n\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n";
     private string _promptMessage = "List as many responses you can to the following prompt: \n";
     private string _prompt;
     private List<string> _responses = new List<string>();

     private List<string> _prompts = new List<string> {
            "List things you're grateful for today:",
            "List things that bring you inner peace:",
            "List things you love about yourself:",
            "List things you want to accomplish this week:",
            "List things that make you smile:",
            "List things you can do to show kindness to others today:",
            "List things you're looking forward to in the near future:",
            "List things you can do to take care of your body today:",
            "List things that inspire you:",
            "List things you've learned recently:",
            "List things you're proud of yourself for:",
            "List things you appreciate about nature:",
            "List things that bring you joy:",
            "List things you're curious about:",
            "List things you're grateful for in your life:",
            "List things you can do to declutter your mind:",
            "List things you're excited about today:",
            "List things you can do to relax and unwind:",
            "List things you're grateful for in your relationships:",
            "List things that make you feel grounded:"};

//METHODS

     // Sets _prompt to a random prompt from the _prompts list
     public void SetPrompt()
     {
         int index = new Random().Next(_prompts.Count);
         _prompt = _prompts[index];
     }

     public string GetPrompt()
     {
         return _prompt;
     }

     // Displays prompt, and then counts down from 5
    public void DisplayPrompt()
    {
          Console.WriteLine(_promptMessage + "--------" + _prompt + "--------");
          Console.Write("You may begin in: ");
          for (int i = 5; i > 0; i--)
          {
              Console.Write(i);
              Thread.Sleep(1000);
              Console.Write("\b \b");
          }
          Console.WriteLine();
    }

     // Gets responses and adds them to list
    public void GetResponses(int time)
    {
          _startTime = DateTime.Now;
          _endTime = _startTime.AddSeconds(time);
          while (DateTime.Now < _endTime)
          {
              Console.Write("> ");
              string response = Console.ReadLine();
              _responses.Add(response);
          }
    }

     // Displays number of responses
     public void DisplayResponses()
     {
          Console.WriteLine("You listed {0} items!", _responses.Count);
     }

     // Displays Description of Activity
    public void DisplayInfo()
    {
        Console.WriteLine(_startText);
    }
    
}