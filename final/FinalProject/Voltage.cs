public abstract class Voltage : Element
{
    // Member Variables
    protected bool _positiveTerminalSource;
    protected string _elementType;
    
    // Constructors
    public Voltage(string name, float voltage) : base(name, voltage)
    {
        _voltage = voltage;
    }
    public Voltage(string name) : base(name){}


    // Methods
    public override abstract void DisplayElement();


    public override void SetPositiveTerminal(bool positiveTerminal)
    {
        _positiveTerminalSource = positiveTerminal;
    }

    public override bool? GetPositiveTerminal()
    {
        return _positiveTerminalSource;
    }

    public override string GetElementType()
    {
        return _elementType;
    }

}