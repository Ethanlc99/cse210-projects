using System.Diagnostics;
using System.Dynamic;
using System.Reflection;

class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        // Default constructor sets fraction to 1/1
        _top = 1;
        _bottom = 1;
    }    

    public Fraction(int num)
    {
        // Sets default bottom to 1 for whole numbers
        _top = num;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFraction()
    {
        string fraction = $"{_top}/{_bottom}";

        return fraction;
    }

    public double GetDecimal()
    {
       return (double)_top/(double)_bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }


}