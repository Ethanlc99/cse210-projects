using System;

class Program
{
    static void Main(string[] args)
    {

        // Create objects
        Entry entry1 = new Entry();
        Journal journal1 = new Journal();
        PromptGenerator prompt1 = new PromptGenerator();

        string userChoice = "1";

        // Display menu and take inputs until the user chooses to quit
        while (userChoice !="5")
        {
            Console.WriteLine("Welcome to your Personal Journal!");
            Console.WriteLine("Please select one of the options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            
        userChoice = Console.ReadLine();
        

            switch (userChoice)
            {
                // Write entry to journal
                case "1":
                    string prompt = prompt1.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    entry1._newEntry = $"{entry1.GetUserEntry(prompt)}";
                    journal1._currentEntries.Add(entry1._newEntry);
                    journal1._saved = 1;
                    break;
                // Display entries in journal
                case "2":
                    entry1.DisplayEntries(journal1._currentEntries);
                    break;
                // Load entry from journal
                case "3":
                    Console.WriteLine("Load");
                    Console.WriteLine("What file would you like to load?");
                    string filename = Console.ReadLine();
                    Console.WriteLine($"{journal1.LoadEntry(filename)}");
                    break;
                // Save entry
                case "4":
                    Console.WriteLine("Save");
                    Console.WriteLine("Enter the name the of file in which you would like to save your jounral entry to");
                    entry1._fileName = Console.ReadLine();
                    entry1.SaveEntry(entry1._fileName, entry1._newEntry);
                    journal1._saved = 0;
                    break;
                // Quit
                case "5":
                    Console.WriteLine("You really want to quit? [y/n]");
                    string response = Console.ReadLine();
                    // Confirm user wants to quit
                    if (response == "n" || response == "N" || response == "no" || response == "No")
                    {
                        userChoice = "1";
                        continue;
                    }
                    // Checks if the user has saved their most recent entry, and warns them if they haven't
                    if (journal1._saved == 1)
                    {
                        Console.WriteLine("You haven't saved your most recent entry. Are you sure you want to quit? (All unsaved changes will be lost) [y/n]");
                        string response2 = Console.ReadLine();
                        if (response2 == "n" || response2 == "N" || response2 == "no" || response2 == "No")
                        {
                            userChoice = "1";
                            continue;
                        }
                        else
                        {
                            break;
                        }   
                    }
                    break;
                default:
                    Console.WriteLine("Please choose an option on the screen.");
                    break;


            }
        }


        Console.WriteLine("Thanks for Journaling with us today!");






    }
}