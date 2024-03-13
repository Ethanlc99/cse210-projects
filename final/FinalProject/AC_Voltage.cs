public class AC_Voltage : Voltage
{
    // Constructors
    public AC_Voltage(string name, int voltage, int phaseAngle) : base(name, voltage)
    {
        _phaseAngle = phaseAngle;
        _elementType = "AC Voltage Source";
    }


    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_voltage} V, {_phaseAngle} degrees)");
    }
}