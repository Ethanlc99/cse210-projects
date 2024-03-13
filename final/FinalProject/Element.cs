public abstract class Element
{
    // Member Variables
    protected int _voltage;
    protected int _current;
    protected int _value;
    protected int _realResistance;
    protected int _imaginaryResistance;
    protected string _name;
    protected bool _isResistanceReal;
    protected int _phaseAngle;
    protected string _Type;

    // Constructor
    public Element(string name)
    {
        _name = name;
    }
    public Element(string name, int value){
        _name = name;
        _value = value;
    }
    public Element(int voltage, int current, int value)
    {
        _voltage = voltage;
        _current = current;
        _value = value;
    }

    // Getters and Setters
    public void SetResistanceReal(bool isResistanceReal)
    {
        _isResistanceReal = isResistanceReal;
    }
    public bool GetResistanceReal()
    {
        return _isResistanceReal;
    }
    
    public void SetResistance(int realResistance)
    {
        _realResistance = realResistance;
    }
    public int GetResistance()
    {
        return _realResistance;
    }

    public void SetValue(int value)
    {
        _value = value;
    }
    public int GetValue()
    {
        return _value;
    }

    public void SetVoltage(int voltage)
    {
        _voltage = voltage;
    }
    public int GetVoltage()
    {
        return _voltage;
    }

    public void SetCurrent(int current)
    {
        _current = current;
    }
    public int GetCurrent()
    {
        return _current;
    }

    public void SetName(string name)
    {
        _name = name;
    }
    public string GetName()
    {
        return _name;
    }

    public void SetElementType(string type)
    {
        _Type = type;
    }
    public string GetElementType()
    {
        return _Type;
    }

    // Methods
    public abstract void DisplayElement();
}