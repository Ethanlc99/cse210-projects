class Word
{
    //Define Member Variables
    private string _currentWords;

    //Checks if all words are hidden in string
    public bool IsHidden()
    {
        foreach (char c in _currentWords)
        {
            if (c != ' ' && c != '_')
            {
                return false;
            }

        }
        return true;
    }

    public void SetWords(string scripture)
    {
        _currentWords = scripture;
    }


}