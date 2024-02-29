using System;

class Program
{

    static void Main(string[] args)
    {
        int _userChoice = 0;

        //Display Menu until User quits   
        while (_userChoice != 4)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            _userChoice = int.Parse(Console.ReadLine());


            switch (_userChoice)
            {
                case 1:
                    BreathingActivity activity1 = new BreathingActivity();
                    activity1.SetName("Breathing");
                    activity1.DisplayStartMessage();
                    activity1.DisplayInfo();
                    activity1.DisplayGetReady();
                    activity1.DisplayBreathing(activity1.SetDuration());
                    activity1.DisplayEndMessage();
                    break;
                case 2:
                    ReflectingActivity activity2 = new ReflectingActivity();
                    if (activity2.SetPrompt() == false)
                    {
                        break;
                    }
                    activity2.SetName("Reflecting");
                    activity2.DisplayStartMessage();
                    activity2.DisplayInfo();
                    activity2.SetDuration();
                    activity2.SetQuestion();
                    activity2.DisplayGetReady();
                    activity2.DisplayPrompt();
                    activity2.DisplayQuestion(activity2.GetDuration());
                    activity2.DisplayEndMessage();
                    break;
                case 3:
                    ListingActivity activity3 = new ListingActivity();
                    if (activity3.SetPrompt() == false)
                    {
                        break;
                    }
                    activity3.SetName("Listing");
                    activity3.DisplayStartMessage();
                    activity3.DisplayInfo();
                    activity3.SetDuration();
                    activity3.DisplayGetReady();
                    activity3.DisplayPrompt();
                    activity3.GetResponses(activity3.GetDuration());
                    activity3.DisplayResponses();
                    activity3.DisplayEndMessage();
                    break;
                case 4:
                    Console.WriteLine("Thanks for using our Mindfullness program.\nHave a great day!");
                    break;
                default:
                    Console.WriteLine("Sorry, I don't understand. Please choose a number between 1 and 4.");
                    break;
            }
        }

        // activity1.DisplaySpinner(10);
    }
}