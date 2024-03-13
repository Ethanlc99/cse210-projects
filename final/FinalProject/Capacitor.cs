public class Capacitor : Element
{
    // Constructor
    public Capacitor(string name, int value) : base(name, value)
    {
        _Type = "Capacitor";
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_Type}: {_name} ({_value} F)");
    }
}