public class SimpleGoal : Goal
{
    // Constructors
    public SimpleGoal() : base()
    {
    }
    public SimpleGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
        _goalType = "Simple";
    }
    public SimpleGoal(string goalName, string goalDescription, int points, bool isCompleted) : base(goalName, goalDescription, points, isCompleted)
    {
        _goalAccomplished = isCompleted;
        _goalType = "Simple";
    }


    // Methods
    public override void DisplayGoal()
    {
        if (_goalAccomplished == true)
        {
            Console.WriteLine($"[X] {_goalName} ({_goalDescription})");
        }
        else
        {
            Console.WriteLine($"[ ] {_goalName} ({_goalDescription})");
        }
    }

    public override int RecordEvent(Goal goal)
    {
        if (_goalAccomplished == false)
        {
            _goalAccomplished = true;    
            Console.WriteLine("Congratulations! you have earned {0} points!", _baseGoalPoints);
        }
        return _baseGoalPoints;
    }

}