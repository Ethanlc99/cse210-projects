using System.ComponentModel.DataAnnotations;

public abstract class Goal
{
    // Attributes
    protected int _baseGoalPoints;
    protected string _goalName;
    protected string _goalDescription;
    protected bool _goalAccomplished;
    protected string _goalType;
    protected int _timesToComplete;
    protected int _timesCompleted;
    protected int _bonusPoints;


    // Constructors
    public Goal()
    {}

    public Goal(string goalName, string goalDescription, int points)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _baseGoalPoints = points;
        _goalAccomplished = false;
    }

    public Goal (string goalName, string goalDescription, int points, bool isComplete)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _baseGoalPoints = points;
        _goalAccomplished = isComplete;
    }


    //Getters and Setters
    public void SetGoalName(string goalName)
    {
        _goalName = goalName;
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    public void SetBaseGoalPoints(int points)
    {
        _baseGoalPoints = points;
    }

    public void SetGoalDescription(string goalDescription)
    {
        _goalDescription = goalDescription;
    }

    public string GetGoalDescription()
    {
        return _goalDescription;
    }


    // Methods
    public abstract int RecordEvent(Goal goal);

    // Saves goal to text file chosen by user
    public void SaveGoal(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename, true))
        {    
            if (_goalType == "Eternal" || _goalType == "Simple")
            {        
                outputFile.WriteLine(_goalType + ":" + _goalName + "~" + _goalDescription + "~" + _baseGoalPoints + "~" + _goalAccomplished);
            }
            else if (_goalType == "Checklist")
            {
                outputFile.WriteLine(_goalType + ":" + _goalName + "~" + _goalDescription + "~" + _baseGoalPoints + "~" + _goalAccomplished + "~" + _timesCompleted + "~" + _timesToComplete + "~" + _bonusPoints);
            }
        }
    }


    // Loads goals from text file, creates goals and adds them to list
    public int LoadGoals(string filename, List<Goal> goals)
    {   
        string[] lines = System.IO.File.ReadAllLines(filename);
        int points = 0;
        int timesCompleted = 0;
        int timesToComplete = 0;
        int bonusPoints = 0;

        foreach (string line in lines)
        {
            string[] typeAndInfo = line.Split(':');
            // Gets points from file
            if (typeAndInfo.Length == 1)
            {
                points = int.Parse(typeAndInfo[0]);
            }
            else
            {
                string[] parts = typeAndInfo[1].Split('~');
                string goalType = typeAndInfo[0];
                string goalName = parts[0];
                string goalDescription = parts[1];
                int basePoints = int.Parse(parts[2]);
                bool goalAccomplished = bool.Parse(parts[3]);
                if (parts.Length == 7)
                {
                    timesCompleted = int.Parse(parts[4]);
                    timesToComplete = int.Parse(parts[5]);
                    bonusPoints = int.Parse(parts[6]);
                }

                if (goalType == "Simple")
                {
                    goals.Add(new SimpleGoal(goalName, goalDescription, basePoints, goalAccomplished));
                }
                else if (goalType == "Eternal")
                {
                    goals.Add(new EternalGoal(goalName, goalDescription, basePoints, goalAccomplished));
                }
                else if (goalType == "Checklist")
                {
                    goals.Add(new ChecklistGoal(goalName, goalDescription, basePoints, timesToComplete, timesCompleted, bonusPoints, goalAccomplished));            
                }
            }
        }

        return points;
    }

    public abstract void DisplayGoal();


    public void DisplayGoals(List<Goal> goals)
        {
            foreach (Goal goal in goals)
            {
                goal.DisplayGoal();
            }
        }


       
}