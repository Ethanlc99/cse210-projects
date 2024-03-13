public abstract class Voltage : Element
{
    // Member Variables
    protected bool _positiveTerminal = true;
    protected bool _negativeTerminal = false;
    protected string _elementType;
    
    // Constructors
    public Voltage(string name, int voltage) : base(name, voltage)
    {
        _voltage = voltage;
    }
    public Voltage(string name) : base(name){}


    // Methods
    public override abstract void DisplayElement();

}