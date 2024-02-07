using System.Globalization;
using System.Text;

class Scripture
{
    Random rnd = new Random();

    // private Dictionary<string, string> _scriptureDict = new Dictionary<string, string>();
    
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
        // hide[1] = rnd.Next(0, 10);
        // hide[2] = rnd.Next(0, 10);

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








    // private void MakeScriptureList(string scripture)
    // {
    //     string[] words = scripture.Split(" ");

    //     foreach (string word in words)
    //     {
    //         _currentScripture.Add(word);
    //     }
    // }

    // public string GetReference()
    // {
    //     return _scriptureReference;
    // }

    // public void SetScripture(string scripture)
    // {
    //     _scriptureDict.Add(_scriptureReference, scripture);
    // }

        // private void SetCurrentScripture(string scripture)
    // {

    // }