public class ChecklistGoal : Goal
{
    // Constructors
    public ChecklistGoal(string goalName, string goalDescription, int basePoints, int timesToComplete, int bonusPoints) : base(goalName, goalDescription, basePoints)
    {
        _timesToComplete = timesToComplete;
        _timesCompleted = 0;
        _goalType = "Checklist";
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string goalName, string goalDescription, int basePoints, int timesToComplete, int timesCompleted, int bonusPoints, bool isComplete) : base(goalName, goalDescription, basePoints, isComplete)
    {
        _timesToComplete = timesToComplete;
        _timesCompleted = timesCompleted;
        _goalType = "Checklist";
        _bonusPoints = bonusPoints;

    }

    // Methods
    public override void DisplayGoal()
    {
        if (_goalAccomplished == true)
        {
            Console.WriteLine($"[X] {_goalName} ({_goalDescription}) -- Currently completed {_timesCompleted}/{_timesToComplete}");
        }
        else
        {
            Console.WriteLine($"[ ] {_goalName} ({_goalDescription}) -- Currently completed {_timesCompleted}/{_timesToComplete}");
        }
    }

    public override int RecordEvent(Goal goal)
    {
        _timesCompleted += 1;
        // Adds points and bonus points if completed
        if (_timesCompleted == _timesToComplete)
        {   
            _goalAccomplished = true;
            Console.WriteLine("Congratulations! You have completed this goal and earned {0} points!!", _bonusPoints + _baseGoalPoints);
            return _baseGoalPoints + _bonusPoints;
        }
        else
        {
            Console.WriteLine("Congratulations! You have earned {0} points!", _baseGoalPoints);
            return _baseGoalPoints;
        }
    }
}