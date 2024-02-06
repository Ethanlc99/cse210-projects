using System.Net;

class Journal{

    public List<string> _currentEntries = new List<string>();

    public int _saved;

    // Reads file chosen by user and returns the contents as a string
    public List<string> LoadEntry(string _fileName)
    {
        string dir = $@"C:\Journal\{_fileName}\\Entry.txt";

        using (StreamReader sr = new StreamReader(dir))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                _currentEntries.Add(line);
            }
        }
        
        return _currentEntries;
    }

}