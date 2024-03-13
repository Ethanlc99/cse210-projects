public class Dep_Current : Current
{
    private string _currentEquation;

    // Constructor
    public Dep_Current(string name, string currentEquation) : base(name)
    {
        _currentEquation = currentEquation;
        _elementType = "Dependent Current Source";
    }



    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_currentEquation} A)");
    }
}