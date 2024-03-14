public class DC_Current : Current
{
    // Constructors
    public DC_Current(string name, float current) : base(name, current)
    {
        _elementType = "DC Current Source";
        _phaseAngle = 0;
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_current} A)");
    }
    
}