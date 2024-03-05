public abstract class Shape
{
    protected string _color;

    public string GetColor()
    {
        return _color;
    }
    public abstract double GetArea();

}