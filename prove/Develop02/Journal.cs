using System.Net;

class Journal{

    public List<string> _currentEntries = new List<string>();

    public int _saved;

    // Reads file chosen by user and returns the contents as a string
    public string LoadEntry(string _fileName)
    {
        string dir = $@"C:\Journal\{_fileName}";
        string entry = File.ReadAllText(dir + "\\Entry.txt");
        return entry;
    }

}