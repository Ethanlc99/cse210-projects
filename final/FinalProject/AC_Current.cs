public class AC_Current : Current
{
    // Constructor
    public AC_Current(string name, int current, int phaseAngle) : base(name, current)
    {
        _phaseAngle = phaseAngle;
        _elementType = "AC Current Source";
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_current} A, {_phaseAngle} degrees)");
    }
}