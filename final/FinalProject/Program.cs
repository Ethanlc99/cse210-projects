using System;
using System.Diagnostics;



// Add feature that add connected sources to elementConnections Dictionary, and calculates values. 
// Future : Add feature that shows circuit in schematic form.



class Program
{
    static void Main(string[] args)
    {
        DateTime _startSpinner;
        DateTime _endSpinner;
        int userChoice1 = 0;
        int _frequency = 0;

        // Dict that hold values a such: 
        // string Element_ConnectedElement : 
        // ([string ElementName, int (Value of Voltage Current or real Resistance], int [Value of Voltage or Current Phase Shift or imaginary part of resistance/impedance], bool [true if positive terminal, false if negative terminal, null if n/a]), 
        // (string ElementName, int [Value of Voltage Current or real Resistance], int [Value of Voltage or Current Phase Shift or imaginary part of resistance/impedance], bool [true if positive terminal, false if negative terminal, null if n/a])))
        Dictionary<string, Tuple<Tuple<string, int, int, bool>, Tuple<string, int, int, bool>>> elementConnections = new Dictionary<string, Tuple<Tuple<string, int, int, bool>, Tuple<string, int, int, bool>>>();

        List<Element> elementList = new List<Element>();
        // Main Menu
        while (userChoice1 != 7)
        {
            // DisplayElements();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. View All Elements");
            Console.WriteLine("2. Add Source");
            Console.WriteLine("3. Add Element");
            Console.WriteLine("4. Connect Elements and Sources");
            Console.WriteLine("5. Find Value");
            Console.WriteLine("6. View Schematic");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do?: ");
        
        try
        {
            userChoice1 = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Please enter a number between 1 and 7");
            // DisplaySpinner(5);
        }

            switch(userChoice1)
            {
                case 1: 
                    Console.WriteLine("View All Elements");
                    DisplayElements();
                    break;


                case 2: // Prompt user to add source
                    bool sourceAdded = false;
                    while (!sourceAdded)
                    {
                    Console.WriteLine("Source Options: ");
                    Console.WriteLine("1. DC Voltage");
                    Console.WriteLine("2. DC Current");
                    Console.WriteLine("3. AC Voltage");
                    Console.WriteLine("4. AC Current");
                    Console.WriteLine("5. Back to Main Menu");
                    Console.Write("What kind of source would you like to add?: ");
                    int userChoice3 = 0;
                    try
                    {
                        userChoice3 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1 and 4");
                        // DisplaySpinner(5);
                        userChoice3 = 0;
                    }
                    switch(userChoice3)
                    {
                        case 1: // DC Voltage
                            Console.Write("What would you like to name your Voltage Source?: ");
                            string voltageName = Console.ReadLine();
                            Console.Write("What is the value of the Voltage Source in Volts?: ");
                            int voltageValue = int.Parse(Console.ReadLine());
                            DC_Voltage voltageSource = new DC_Voltage(voltageName, voltageValue);
                            elementList.Add(voltageSource);
                            voltageSource.DisplayElement();
                            sourceAdded = true;
                            Console.WriteLine("Voltage Source Added");
                            break;
                        case 2: // DC Current
                            Console.Write("What would you like to name your Current Source?: ");
                            string currentName = Console.ReadLine();
                            Console.Write("What is the value of the Current Source in Amps?: ");
                            int currentValue = int.Parse(Console.ReadLine());
                            DC_Current currentSource = new DC_Current(currentName, currentValue);
                            elementList.Add(currentSource);
                            currentSource.DisplayElement();
                            sourceAdded = true;
                            Console.WriteLine("Current Source Added");
                            break;
                        case 3: // AC Voltage
                            Console.WriteLine("What would you like to name your Voltage Source?: ");
                            string voltageName2 = Console.ReadLine();
                            Console.WriteLine("What is the amplitude of the Voltage Source in Volts?: ");
                            int voltageValue2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("What is the phase angle of the Voltage Source in degrees?: ");
                            int phaseAngle = int.Parse(Console.ReadLine());
                            AC_Voltage voltageSource2 = new AC_Voltage(voltageName2, voltageValue2, phaseAngle);
                            elementList.Add(voltageSource2);
                            voltageSource2.DisplayElement();
                            sourceAdded = true;
                            break;
                        case 4: // AC Current
                            Console.WriteLine("What would you like to name your Current Source?: ");
                            string currentName2 = Console.ReadLine();
                            Console.WriteLine("What is the amplitude of the Current Source in Amps?: ");
                            int currentValue2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("What is the phase angle of the Current Source in degrees?: ");
                            int phaseAngle2 = int.Parse(Console.ReadLine());
                            AC_Current currentSource2 = new AC_Current(currentName2, currentValue2, phaseAngle2);
                            elementList.Add(currentSource2);
                            currentSource2.DisplayElement();
                            sourceAdded = true;
                            break;
                        case 5:
                            sourceAdded = true;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Please enter a number between 1 and 5");
                            // DisplaySpinner(5);
                            break;
                    }
                }

                    break;


                case 3: // Prompt user to add element
                    bool elementAdded = false;
                    while (!elementAdded)
                    {
                    Console.WriteLine("Element Options: ");
                    Console.WriteLine("1. Resistor");
                    Console.WriteLine("2. Inductor");
                    Console.WriteLine("3. Capacitor");
                    Console.WriteLine("4. Back to Main Menu");
                    Console.Write("What kind of source would you like to add?: ");
                    int userChoice2 = 0;
                    try
                    {
                        userChoice2 = int.Parse(Console.ReadLine());
                    }
                    catch
                    {   
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1 and 4");
                        // DisplaySpinner(5);
                        userChoice2 = 0;
                    }
                        switch(userChoice2)
                        {

                            case 1:
                                Console.Write("What would you like to name your Resistor?: ");
                                string resistorName = Console.ReadLine();
                                Console.Write("What is the resistance of your resistor in Ohms?: ");
                                int resistorValue = int.Parse(Console.ReadLine());
                                Resistor resistor = new Resistor(resistorName, resistorValue);
                                elementList.Add(resistor);
                                resistor.DisplayElement();
                                elementAdded = true;
                                Console.WriteLine("Resistor Added");
                                break;
                            case 2:
                                Console.Write("What would you like to name your Inductor?: ");
                                string inductorName = Console.ReadLine();
                                Console.Write("What is the value of the Inductor in Henrys?: ");
                                int inductorValue = int.Parse(Console.ReadLine());
                                Inductor inductor = new Inductor(inductorName, inductorValue);
                                elementList.Add(inductor);
                                inductor.DisplayElement();
                                Console.WriteLine("Inductor Added");
                                elementAdded = true;
                                break;
                            case 3:
                                Console.Write("What would you like to name your Capacitor?: ");
                                string capacitorName = Console.ReadLine();
                                Console.Write("What is the value of the Capacitor in Farads?: ");
                                int capacitorValue = int.Parse(Console.ReadLine());
                                Capacitor capacitor = new Capacitor(capacitorName, capacitorValue);
                                elementList.Add(capacitor);
                                capacitor.DisplayElement();
                                Console.WriteLine("Capacitor Added");
                                elementAdded = true;
                                break;
                            case 4:
                                Console.WriteLine("Back to Main Menu");
                                elementAdded = true;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Please enter a number between 1 and 4");
                                // DisplaySpinner(5);
                                break;
                        }
                    }
                    break;


                case 4: // Connect elements and sources
                    DisplayElements();
                    Console.Write("Choose the first element you would like to connect: ");
                    int element1 = int.Parse(Console.ReadLine());
                    Console.Write($"Choose the element you would like to connect to {elementList[element1-1].GetName()}: ");
                    int element2 = int.Parse(Console.ReadLine());

                    string typeElement1 = elementList[element1-1].GetElementType();
                    string typeElement2 = elementList[element2-1].GetElementType();

                    if (typeElement1 == "AC Voltage Source" || typeElement1 == "DC Voltage Source" || typeElement1 == "AC Current Source" || typeElement1 == "DC Current Source")
                    {
                        Console.Write($"Are you connecting the positive terminal of {elementList[element1-1].GetName()} to {elementList[element2-1].GetName()}?: ");
                        string positiveTerminal = Console.ReadLine();
                        if (positiveTerminal == "y" || positiveTerminal == "Y")
                        {
                            elementList[element1-1].SetPositiveTerminal(true);
                        }
                        else
                        {
                            elementList[element1-1].SetPositiveTerminal(false);
                        }
                    }

                    if (typeElement2 == "AC Voltage Source" || typeElement2 == "DC Voltage Source" || typeElement2 == "AC Current Source" || typeElement2 == "DC Current Source")
                    {
                        Console.Write($"Are you connecting the positive terminal of {elementList[element2-1].GetName()} to {elementList[element1-1].GetName()}?: ");
                        string positiveTerminal = Console.ReadLine();
                        if (positiveTerminal == "y" || positiveTerminal == "Y")
                        {
                            elementList[element2-1].SetPositiveTerminal(true);
                        }
                        else
                        {
                            elementList[element2-1].SetPositiveTerminal(false);
                        }
                    }



                    Console.WriteLine("Connect Elements and Sources");
                    break;


                case 5:
                    Console.WriteLine("Find Value");
                    break;


                case 6: // Views schematic with all elements attached and values shown
                    Console.WriteLine("View Schematic");
                    break;

                case 7:
                    Console.WriteLine("Quit");
                    break;


                default:
                    Console.WriteLine("Please enter a number between 1 and 7");
                    // DisplaySpinner(5);
                    break;
            }

        }

        void DisplayElements()
        {   
            List<Element> sortedList = elementList.OrderBy(o=>o.GetElementType()).ToList();
            elementList = sortedList;
            int counter = 1;
            foreach (Element element in sortedList)
            {
                Console.Write(counter + ". ");
                element.DisplayElement();
                counter += 1;
            }
        }



        // Methods
        void DisplaySpinner(int time)
        {
            _startSpinner = DateTime.Now;
            _endSpinner = _startSpinner.AddSeconds(time);
            while (DateTime.Now < _endSpinner)
            {
                Console.Write("/");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("|");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(125);
                Console.Write("\b \b");
                Console.Write("|");
                Thread.Sleep(125);
                Console.Write("\b \b");
            }

    }
    }
}