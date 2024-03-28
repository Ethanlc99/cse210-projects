public abstract class Element
{
    // Member Variables
    protected float _voltage;
    protected float _current;
    protected float _value;
    protected float _realResistance;
    protected float _imaginaryResistance;
    protected string _name;
    protected bool _isResistanceReal;
    protected float _phaseAngle;
    protected float _impedance;
    protected bool? _positiveTerminal;

    protected string _Type;

    // Constructor
    public Element(string name)
    {
        _name = name;
    }
    public Element(string name, float value){
        _name = name;
        _value = value;
    }
    public Element(float voltage, float current, float value)
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
    public float GetResistance()
    {
        return _realResistance;
    }

    public void SetValue(int value)
    {
        _value = value;
    }
    public float GetValue()
    {
        return _value;
    }

    public void SetVoltage(int voltage)
    {
        _voltage = voltage;
    }
    public float GetVoltage()
    {
        return _voltage;
    }

    public void SetCurrent(int current)
    {
        _current = current;
    }
    public float GetCurrent()
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

    public float GetPhaseAngle()
    {
        return _phaseAngle;
    }

    public void SetElementType(string type)
    {
        _Type = type;
    }
    public virtual void SetImpedance(int frequency)
    {}

    public virtual float GetImpedance()
    {
        return _impedance;
    }

    public string GetPositiveSide(bool? positive, string name)
    {
            if (positive == true)
            {
                return  "+" + name;
            }
            else if (positive == false)
            {
                return "-" + name;
            }
            else return name;
    }

    public abstract void SetPositiveTerminal(bool positiveTerminal);

    public abstract bool? GetPositiveTerminal();

    public float GetImaginaryResistance()
    {
        return _imaginaryResistance;
    }

    public virtual string GetElementType()
    {
        return _Type;
    }


    // Methods
    public abstract void DisplayElement();

    public string CalculateVoltage(Element element, Dictionary<string, List<Tuple<string, float, float, bool?>>> connections)
    {
        
        

        return $"{_voltage}";
    }

    public string CalculateCurrent()
    {
        return $"{_current}";
    }

    public string CalculateImpedance()
    {
        return $"{_impedance}";
    }
}