class Entry
{

    public string _fileName;
    public string _newEntry;
    public DateTime _dateAndTime = DateTime.Now;

    // Shows each entry in the journal from this session
    public void DisplayEntries(List<string> _userResponses)
    {
        foreach (string response in _userResponses)
        Console.WriteLine($"{response}");
    }

    // Temporarily stored journal entry, as well as the date and time it was created
    public string GetUserEntry(string prompt)
    {
        Console.WriteLine("Enter your Journal Entry below");
        string _userResponse = Console.ReadLine();
        string savedEntry = $"{_dateAndTime}:\n{prompt}\n{_userResponse}\n\n"; 
        return savedEntry;
    }

    // Saves entry to journal
    public void SaveEntry(string _fileName, List<string> _currentEntries)
    {
        List<string> entries = _currentEntries;
        // Check if directory exists, and creates it if it doesn't, then saves entry to that text file
        string dir = $@"C:\Journal\{_fileName}\Entry.txt";
        if (Directory.Exists(dir))
        { 
            foreach (string entry in entries)
            {
            StreamWriter sw = new StreamWriter(Path.Combine(dir), true);
            sw.WriteLine(entry);
            sw.Close();
            }
            // File.WriteAllText(Path.Combine($@"C:\Journal\{_fileName}", "Entry.txt"), _entry);
        }
        else
        {
            Directory.CreateDirectory($@"C:\Journal\{_fileName}");
            foreach (string entry in entries)
            {
            File.AppendAllText(Path.Combine(dir), entry);
            }
        }

        
    }    


}