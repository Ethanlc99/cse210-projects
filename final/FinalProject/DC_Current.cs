public class DC_Current : Current
{
    // Constructors
    public DC_Current(string name, int current) : base(name, current)
    {
        _elementType = "DC Current Source";
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_current} A)");
    }
    
}