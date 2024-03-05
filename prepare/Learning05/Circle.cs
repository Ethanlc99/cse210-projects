public class Circle : Shape{
    private double _radius;

    public Circle(string color, double radius)
    {
        _color = color;
        _radius = radius;
    }

    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }

}