public class Inductor : Element
{
    // Constructors
    public Inductor(string name, float value, float frequency) : base(name, value)
    {
        _Type = "Inductor";
        _impedance = frequency*_value;
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_Type}: {_name} ({_value} H)");
    }

    public override void SetPositiveTerminal(bool positiveTerminal){}

    // public override void SetImpedance(int frequency)
    // {
    //     _impedance = frequency*_value;
    // }
    public override bool? GetPositiveTerminal()
    {
        return null;
    }
}