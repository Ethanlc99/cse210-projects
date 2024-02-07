using System;

class Program
{
    static void Main(string[] args)
    {
        //Set up all classes and variables for Main
        Random rnd = new Random();

        ScriptureLibrary library = new ScriptureLibrary();

        List<List<string>> allScriptures = library.GetAllKeys();

        List<string> choice = new List<string>();
        
        //Pick a random scripture from ScriptureLibrary
        int num = rnd.Next(0, allScriptures.Count); 

        choice = allScriptures[num];

        string verses = library.GetScripture(choice);


        // foreach (string i in choice){
        // Console.WriteLine($"{i}");}
        // Console.WriteLine(choice.Count);

        if (choice.Count == 3)
        {
            Reference ref1 = new Reference(choice[0], choice[1], choice[2]);
            string reference = ref1.GetReference();
            Word word1 = new Word();
            Scripture script1 = new Scripture(reference, verses);
            // Console.WriteLine("Only one Verse");
            Run(word1, script1);
        }
        else if (choice.Count == 4)
        {
            Reference ref1 = new Reference(choice[0], choice[1], choice[2], choice[3]);
            string reference = ref1.GetReference();
            Word word1 = new Word();
            Scripture script1 = new Scripture(reference, verses);
            // Console.WriteLine("Multiple Verses");
            Run(word1, script1);            
        }





        void Run( Word word, Scripture script)
        {

            script.DisplayScripture();

            string userChoice = "";

            word.SetWords(script.GetScripture());

            while (userChoice != "quit")
            {
                Console.WriteLine("Press enter to continue or type quit to exit.");
                userChoice = Console.ReadLine();
                Console.Clear();
                if (word.IsHidden())
                {
                    break;
                }
                script.HideWords();
                word.SetWords(script.GetScripture());
                script.DisplayScripture();

            }
        }
    }
}