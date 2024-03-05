using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("Red", 4); 
        Rectangle rec1 = new Rectangle("Blue", 4, 5);
        Circle circle1 = new Circle("Yellow", 5);

        List<Shape> shapes = new List<Shape>{square1, rec1, circle1};

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            Console.WriteLine();
        }

    }
}