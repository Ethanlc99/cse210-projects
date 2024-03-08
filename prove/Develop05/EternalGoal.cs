public class EternalGoal : Goal
{
    // Constructors
    public EternalGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {
        _goalType = "Eternal";
    }
    public EternalGoal(string goalName, string goalDescription, int points, bool isCompleted) : base(goalName, goalDescription, points, isCompleted)
    {
        _goalType = "Eternal";
        _goalAccomplished = isCompleted;
    }

    // Methods
    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {_goalName} ({_goalDescription})");
    }

    public override int RecordEvent(Goal goal)
    {
        return _baseGoalPoints;
    }
}