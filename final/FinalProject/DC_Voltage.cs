public class DC_Voltage : Voltage
{
    // Constructor
    public DC_Voltage(string name, float voltage) : base(name, voltage)
    {
        _elementType = "DC Voltage Source";
        _phaseAngle = 0;
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_voltage} V)");
    }
}