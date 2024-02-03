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
    public void SaveEntry(string _fileName, string _newEntry)
    {
        string _entry = $"{_newEntry}";
        // Check if directory exists, and creates it if it doesn't, then saves entry to that text file
        string dir = $@"C:\Journal\{_fileName}\Entry.txt";
        if (Directory.Exists(dir))
        { 
            File.WriteAllText(Path.Combine($@"C:\Journal\{_fileName}", "Entry.txt"), _entry);
        }
        else
        {
            Directory.CreateDirectory($@"C:\Journal\{_fileName}");
            File.AppendAllText(Path.Combine(dir), _entry);
        }

        
    }    


}