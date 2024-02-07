class Word
{
    private string _currentWords;


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