public class Resistor : Element{


    public Resistor(string name, int realResistance) : base(name)
    {
        _realResistance = realResistance;
        _Type = "Resistor";
        _imaginaryResistance = 0;
    }


    public override void DisplayElement()
    {
        Console.WriteLine($"{_Type}: {_name} ({_realResistance} ohms)");
    }

    public override void SetPositiveTerminal(bool positiveTerminal){}
}