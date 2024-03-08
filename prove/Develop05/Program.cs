using System;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        DateTime _startSpinner;
        DateTime _endSpinner;

        string _rank = "Peasant"; 

        List<Goal> _goalList = new List<Goal>();

        int _currentPoints = 0;
        int _userChoice = 0;


        // Program
        while (_userChoice != 6)
        {
            DisplayRank();
            Console.WriteLine("Your current points are: " + _currentPoints);
            Console.WriteLine(" ");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            // Catches if user input is not a number
            try
            {
                _userChoice = int.Parse(Console.ReadLine());
            }
            catch 
            {
                _userChoice = 0;
            }
                switch(_userChoice)
                {
                    case 1: // Create New Goal
                        Console.Clear();
                        Console.WriteLine("The types of Goals are: \n1. Simple Goal \n2. Eternal Goal \n3. Checklist Goal \nWhich type of goal would you like to create?");
                        int _userChoice2 = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch(_userChoice2)
                        {
                            case 1: // Simple Goal
                                Console.WriteLine("What is the name of your goal?");
                                string sGoalName = Console.ReadLine();
                                Console.WriteLine("What is a short description of it?");
                                string sGoalDescription = Console.ReadLine(); // (Console.ReadLine());
                                Console.WriteLine("How many points would you like to assign to this goal?");
                                int sGoalBaseGoalPoints= int.Parse(Console.ReadLine());
                                SimpleGoal simpleGoal = new SimpleGoal(sGoalName, sGoalDescription, sGoalBaseGoalPoints);
                                _goalList.Add(simpleGoal);
                                Console.Clear();
                                DisplayGoals();
                                Console.WriteLine();
                                break;
                            case 2: // Eternal Goal
                                Console.WriteLine("What is the name of your goal?");
                                string eGoalName = Console.ReadLine();
                                Console.WriteLine("What is a short description of it?");
                                string eGoalDescription = Console.ReadLine();
                                Console.WriteLine("How many points would you like to assign to this goal?");
                                int eGoalBaseGoalPoints = int.Parse(Console.ReadLine());
                                EternalGoal eternalGoal = new EternalGoal(eGoalName, eGoalDescription, eGoalBaseGoalPoints);
                                _goalList.Add(eternalGoal);
                                Console.Clear();
                                DisplayGoals();
                                Console.WriteLine();

                                break;
                            case 3: // Checklist Goal
                                Console.WriteLine("What is the name of your goal?");
                                string cGoalName = Console.ReadLine();
                                Console.WriteLine("What is a short description of it?");
                                string cGoalDescription = Console.ReadLine();
                                Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
                                int cGoalTimesToAccomplish = int.Parse(Console.ReadLine());
                                Console.WriteLine("How many points would you like to assign to this goal?");
                                int cGoalBaseGoalPoints = int.Parse(Console.ReadLine());
                                Console.WriteLine("How many points do you get for completing the goal?");
                                int cGoalBonusPoints = int.Parse(Console.ReadLine());
                                ChecklistGoal checklistGoal = new ChecklistGoal(cGoalName, cGoalDescription, cGoalBaseGoalPoints, cGoalTimesToAccomplish, cGoalBonusPoints);
                                _goalList.Add(checklistGoal);
                                Console.Clear();
                                Console.WriteLine();
                                DisplayGoals();
                                break;
                        }
                        break;
                    case 2: // List Goals
                        DisplayGoals();
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine(); 
                        break;
                    case 3: // Save Goals
                        Console.WriteLine("What do you want to name your save file?");
                        string filename = Console.ReadLine();
                        using (StreamWriter outputFile = new StreamWriter(filename))
                        {
                            outputFile.WriteLine(_currentPoints);
                        }
                        foreach (Goal goal in _goalList)
                        {
                            Console.WriteLine(goal);
                            DisplaySpinner(1);
                            goal.SaveGoal(filename);
                        }
                        break;
                    case 4: // Load Goals
                        SimpleGoal goal1 = new SimpleGoal();
                        Console.WriteLine("What do you want to name your load file?");
                        string filename2 = Console.ReadLine();
                        _currentPoints = goal1.LoadGoals(filename2, _goalList);
                        break;
                    case 5: // Record Event
                        DisplayGoals();
                        Console.WriteLine("Which goal did you accomplish?");
                        int _userChoice3 = int.Parse(Console.ReadLine());
                        _currentPoints += _goalList[_userChoice3 - 1].RecordEvent(_goalList[_userChoice3 - 1]);
                        DisplaySpinner(8);
                        Console.Clear();
                        break;
                    case 6: // Quit
                        Console.WriteLine("Thanks for using our program today. Have a great day!!");
                        DisplaySpinner(5);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Sorry, I don't understand. Please choose a number between 1 and 6.");
                        DisplaySpinner(5);
                        Console.Clear();
                        break;
                }


        }

    // Shows rank and congratulates if user has reached new rank
    void DisplayRank()
    {
        string newRank = SetRank();
        if (_rank != newRank)
        {
            Console.WriteLine("Congratulations! You have Levelled Up! \nNew Rank: " + newRank);
            _rank = newRank;
            DisplaySpinner(5);
            Console.Clear();
            Console.WriteLine("Your current rank is: " + _rank);
        }
        else
        {
            Console.WriteLine("Your current rank is: " + _rank);
        }
    }
    
    // Sets rank based on current points
    string SetRank()
    {
        int points = _currentPoints;
        string rank;
        if (points >= 10000)
        {
            rank = "GOD (you have ascended the heavens!)";
        }
        else if (points >= 7500)
        {
            rank = "Demi-God (what can I say except 'You're Welcome!'?)";
        }
        else if (points >= 5000)
        {
            rank = "Chosen Warrior of Heaven (now that's what I'm talking about!)";
        }
        else if (points >= 4000)
        {
            rank = "Foot Soldier of the Heavenly Hosts (small fish big pond again, but good job)";
        }
        else if (points >= 3000)
        {
            rank = "Cloud Breacher (you have surpassed mortal comprehension)";
        }
        else if (points >= 2000)
        {
            rank = "The Divinely Chosen One (someone made it on the special list)";
        }
        else if (points >= 1500)
        {
            rank = "Destroyer of Nations (nuff said)";
        }
        else if (points >= 1000)
        {
            rank = "Mountain Champion (Everest should've never messed with you. I kinda liken that mountain )':  )";
        }
        else if (points >= 750)
        {
            rank = "Supreme Hero";
        }
        else if(points >= 500)
        {
            rank = "Dragon Slayer (in one of many ways...)";
        }
        else if (points >= 400)
        {
            rank = "Actually Cool Hero (can i get an autograph?)";
        }
        else if (points >= 300)
        {
            rank = "Pretty Cool Hero (i guess)";
        }
        else if (points >= 200)
        {
            rank = "Hero";
        }
        else if (points >= 100)
        {
            rank = "Nobel Knight";
        }
        else
        {
            rank = "Peasant";
        }
        return rank;
    }
    
    void DisplayGoals()
    {
        Console.Clear();
        int counter = 1;
        foreach (Goal goal in _goalList)
        {
            Console.Write(counter + ". "); 
            goal.DisplayGoal();
            counter += 1;
        }

    }
    
    void DisplaySpinner(int time)
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
}
