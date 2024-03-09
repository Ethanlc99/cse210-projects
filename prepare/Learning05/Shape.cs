public abstract class Shape
{
    protected string _color;

    public string GetColor()
    {
        return _color;
    }
    public abstract double GetArea();

    // public void Celebrate()
    //  {
    //     for (int i = 0; i < 20; i++)
    //     {
    //         Console.Clear(); // Clear console for smoother animation
    //         DrawLetters(i);
    //         Thread.Sleep(100); // Adjust animation speed
    //     }
    // }

    // static void DrawLetters(int position)
    // {
    //     string letters = "GREATJOB";
    //     int maxPosition = Console.WindowHeight - letters.Length;

    //     for (int i = 0; i < letters.Length; i++)
    //     {
    //         int currentPos = (position + i) % (2 * maxPosition); // Oscillate between 0 and maxPosition
    //         if (currentPos > maxPosition)
    //             currentPos = 2 * maxPosition - currentPos; // Move back down after reaching maxPosition

    //         Console.SetCursorPosition(0, currentPos);
    //         Console.WriteLine(letters[i]);
    //     }
    // }

}