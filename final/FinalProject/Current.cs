public abstract class Current : Element
{

    protected string _elementType;
    // Constructors
    public Current(string name, int current) : base(name)
    {
        _current = current;
    }
    public Current(string name) : base(name){}

    // Methods
    public override abstract void DisplayElement();
}