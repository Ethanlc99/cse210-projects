using System.Globalization;
using System.Text;

class Scripture
{
    //Define Random for HideWords function
    Random rnd = new Random();
    
    //Define Member Variables
    private List<string> _currentScripture = new List<string>();
    private string _scriptureReference;
    private List<int> _hide = new List<int>();

    // Construct that stores reference and list of words
    public Scripture(string reference, string scripture)
    {
        _scriptureReference = reference;
        
        string[] words = scripture.Split(" ");

        foreach (string word in words)
        {
            _currentScripture.Add(word);
        }
    }


    // Hides 3 random words 
    public void HideWords()
    {
        
        for (int i = 0; i < 3; i++)
        {
            int randomNum = rnd.Next(0, _currentScripture.Count);

            int counter = _currentScripture.Count;
            while (_hide.Contains(randomNum) && counter != 0)
            {
                randomNum = rnd.Next(0, _currentScripture.Count);
                counter -= 1;
            }
            _hide.Add(randomNum);
        }

        foreach (int num in _hide)
        {
            string word = _currentScripture[num];
        
            StringBuilder sb = new StringBuilder();

            foreach (char c in word)
            {
                sb.Append('_');
            }

            _currentScripture[num] = sb.ToString();

        }

    }

    // Makes a string from the list of strings in _currentScripture
    public string GetScripture()
    {
        string updatedScripture = string.Join(" ",_currentScripture);
        return updatedScripture;
    }

    // Clears the console and prints the new scripture
    public void DisplayScripture()
    {
        Console.WriteLine($"{_scriptureReference} - \n{GetScripture()}\n\n");
    }

}