public class Inductor : Element
{
    // Constructors
    public Inductor(string name, int value) : base(name, value)
    {
        _Type = "Inductor";
    }

    // Methods
    public override void DisplayElement()
    {
        Console.WriteLine($"{_Type}: {_name} ({_value} H)");
    }
}