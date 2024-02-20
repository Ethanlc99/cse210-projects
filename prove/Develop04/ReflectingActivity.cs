class ReflectingActivity : Activity
{
//ATTRIBUTES
    private string _startText = "\n\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n";
    private string _promptMessage = "Consider the following prompt:\n";
    private string _prompt;
    private string _question;

    private List<string> _questions = new List<string>
    {
    "What emotions did you experience during that time?",
    "How did that experience impact your outlook on life?",
    "What did you learn about yourself from that experience?",
    "Who else was involved in the situation, and how did they influence it?",
    "What were the main challenges you faced, and how did you overcome them?",
    "What aspects of the experience brought you the most joy?",
    "In what ways did that experience change your perspective?",
    "What values or principles were important to you during that time?",
    "How did you feel physically during that experience?",
    "What were the significant events leading up to that moment?",
    "How did that experience contribute to your personal growth?",
    "What were the key decisions you had to make, and how did you make them?",
    "What memories do you associate with that experience?",
    "What obstacles did you encounter along the way, and how did you navigate them?",
    "What were your initial thoughts and feelings about the situation?",
    "How did your relationships with others evolve during that time?",
    "What role did gratitude play in your experience?",
    "What were the long-term effects of that experience?",
    "How did you cope with any challenges or setbacks you faced?",
    "What did you appreciate most about that experience?",
    "What were the most significant lessons you learned?",
    "How did that experience align with your personal values and beliefs?",
    "What were the consequences of your actions during that time?",
    "What did you discover about yourself that you didn't know before?",
    "How did that experience shape your goals and aspirations?",
    "What advice would you give to someone facing a similar situation?",
    "What moments of clarity did you have during that experience?",
    "How did your perspective change as a result of that experience?",
    "What strengths did you rely on to get through that experience?",
    "What impact did that experience have on your relationships with others?",
    "What role did self-care play in your ability to handle that experience?",
    "How did that experience influence your decisions going forward?",
    "What did you find most challenging about that experience?",
    "How did your understanding of yourself or others evolve as a result of that experience?",
    "What aspects of the experience brought you the most satisfaction?"
    };

    private List<string> _prompts = new List<string>
    {
    "Think of a time when you received unexpected help from someone.",
    "Think of a time when you faced a fear and overcame it.",
    "Think of a time when you felt deeply connected to nature.",
    "Think of a time when you learned a valuable lesson from a mistake.",
    "Think of a time when you felt proud of an accomplishment, big or small.",
    "Think of a time when you showed kindness to someone else.",
    "Think of a time when you experienced a moment of pure joy.",
    "Think of a time when you felt grateful for something in your life.",
    "Think of a time when you felt completely at peace.",
    "Think of a time when you had to make a difficult decision and how it turned out.",
    "Think of a time when you felt inspired by someone or something.",
    "Think of a time when you experienced a setback and how you bounced back from it.",
    "Think of a time when you felt a strong sense of community or belonging.",
    "Think of a time when you stood up for something you believe in.",
    "Think of a time when you took a risk and it paid off.",    
    "Think of a time when you had to step out of your comfort zone.",
    "Think of a time when you felt a deep sense of awe or wonder.",
    "Think of a time when you received constructive criticism and how you responded to it.",
    "Think of a time when you had to make a difficult sacrifice for the greater good.",
    "Think of a time when you experienced a major life transition and how you adapted to it."
    };

//METHODS

    public void SetPrompt()
    {
        int index = new Random().Next(_prompts.Count);
        _prompt = _prompts[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(_promptMessage + "--------" + _prompt + "--------");
        Console.WriteLine("When you have sometime in mind, press enter to continue");
        Console.ReadLine();
    }

    public void SetQuestion()
    {
        int index = new Random().Next(_questions.Count);
        _question = _questions[index];
    }
    public void DisplayQuestion(int time)
    {
        _startTime = DateTime.Now;
        _endTime = _startTime.AddSeconds(time);
        while (DateTime.Now < _endTime)
        {
        Console.WriteLine(_question);
        SetQuestion();
        DisplaySpinner(15);
        }

    }

    public void DisplayInfo()
    {
        Console.WriteLine(_startText);
    }
}