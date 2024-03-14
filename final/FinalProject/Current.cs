public abstract class Current : Element
{

    protected bool _positiveTerminalSource;
    protected string _elementType;
    // Constructors
    public Current(string name, float current) : base(name)
    {
        _current = current;
    }
    public Current(string name) : base(name){}

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