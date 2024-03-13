public class Dep_Voltage : Voltage
{

    private string _voltageEquation;
    // Constructor
    public Dep_Voltage(string name, string voltageEquation) : base(name)
    {
        _voltageEquation = voltageEquation;
        _elementType = "Dependent Voltage Source";
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_elementType}: {_name} ({_voltageEquation} V)");
    }
}