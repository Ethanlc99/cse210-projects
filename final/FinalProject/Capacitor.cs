public class Capacitor : Element
{

    // Constructor
    public Capacitor(string name, float value, float frequency) : base(name, value)
    {
        _Type = "Capacitor";
        _impedance = -1/(frequency*_value);
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_Type}: {_name} ({_value} F)");
    }

    public override void SetPositiveTerminal(bool positiveTerminal){}

    // public override void SetImpedance(int frequency)
    // {
    //     _impedance = -1/(frequency*_value);
    // }
    public override bool? GetPositiveTerminal()
    {
        return null;
    }
}