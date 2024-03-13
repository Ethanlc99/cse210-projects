public abstract class Current : Element
{

    protected bool _positiveTerminal;
    protected string _elementType;
    // Constructors
    public Current(string name, int current) : base(name)
    {
        _current = current;
    }
    public Current(string name) : base(name){}

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