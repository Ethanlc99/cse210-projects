public abstract class Voltage : Element
{
    // Member Variables
    protected bool _positiveTerminal;
    protected string _elementType;
    
    // Constructors
    public Voltage(string name, int voltage) : base(name, voltage)
    {
        _voltage = voltage;
    }
    public Voltage(string name) : base(name){}


    // Methods
    public override abstract void DisplayElement();


    public override void SetPositiveTerminal(bool positiveTerminal)
    {
        _positiveTerminal = positiveTerminal;
    }

    public override string GetElementType()
    {
        return _elementType;
    }

}