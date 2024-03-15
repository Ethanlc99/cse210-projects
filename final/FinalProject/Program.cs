using System;
using System.Data;
using System.Diagnostics;



// TODO: TODO: find values of Impedance and resistance across series and parallel elements. Start with Resistors -> capacitors and inductors. Then move on to sources and find voltage across Resistors -> inductors and capacitors. Add feature that calculates values (Thevinin and Norton, parrallel impedance). 
// Future : Add feature that shows circuit in schematic form.



class Program
{
    static void Main(string[] args)
    {
        // Variables
        DateTime _startSpinner;
        DateTime _endSpinner;
        int userChoice1 = 0;
        int _frequency = 0;
        bool _frequencySet = false;


        // Dict that hold values a such: 
        // string Element_ConnectedElement : 
        // ([string ElementName, int (Value of Voltage Current or real Resistance], int [Value of Voltage or Current Phase Shift or imaginary part of resistance/impedance], bool [true if positive terminal, false if negative terminal, null if n/a]), 
        Dictionary<string, List<Tuple<string, float, float, bool?>>> elementConnections = new Dictionary<string, List<Tuple<string, float, float, bool?>>>();

        List<Element> elementList = new List<Element>();
        
        
        
        // Test Elements
        DC_Voltage test_dC_Voltage = new DC_Voltage("V1", 5);
        Resistor test_resistor = new Resistor("R1", 1000);
        DC_Current test_dC_Current = new DC_Current("C1", 5);
        Resistor test_resistor2 = new Resistor("R2", 1000);

        elementList.Add(test_dC_Voltage);
        elementList.Add(test_resistor);
        elementList.Add(test_dC_Current);
        elementList.Add(test_resistor2);
        
        
        
        
        
        
        // Main Menu
        while (userChoice1 != 7)
        {
            // DisplayElements();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. View All Elements/Connections");
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
                case 1: // Shows all elements in elementList
                    int userChoiceView = 0;
                    bool viewElements = false;
                    while (!viewElements)
                    {
                        Console.WriteLine("1. View All Elements \n2. View All Connections \n3. Back to Main Menu");
                        Console.Write("Which would you like to see?: ");
                        try
                        {
                            userChoiceView = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a number between 1 and 3");
                                // DisplaySpinner(5);
                                userChoiceView = 0;
                            }
                        switch (userChoiceView)
                        {
                            case 1:
                                Console.Clear();
                                DisplayElements();
                                viewElements = true;
                                // DisplaySpinner(5);
                                break;
                            case 2:
                                Console.Clear();
                                DisplayAllConnections();
                                viewElements = true;
                                // DisplaySpinner(5);
                                break;
                            case 3:
                                viewElements = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a number between 1 and 2");
                                userChoiceView = 0;
                                // DisplaySpinner(5);
                                break;
                        }
                    }
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
                            float voltageValue = float.Parse(Console.ReadLine());
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
                            float currentValue = float.Parse(Console.ReadLine());
                            DC_Current currentSource = new DC_Current(currentName, currentValue);
                            elementList.Add(currentSource);
                            currentSource.DisplayElement();
                            sourceAdded = true;
                            Console.WriteLine("Current Source Added");
                            break;
                        case 3: // AC Voltage
                            SetFrequency();
                            Console.WriteLine("What would you like to name your Voltage Source?: ");
                            string voltageName2 = Console.ReadLine();
                            Console.WriteLine("What is the amplitude of the Voltage Source in Volts?: ");
                            float voltageValue2 = float.Parse(Console.ReadLine());
                            Console.WriteLine("What is the phase angle of the Voltage Source in degrees?: ");
                            float phaseAngle = float.Parse(Console.ReadLine());
                            AC_Voltage voltageSource2 = new AC_Voltage(voltageName2, voltageValue2, phaseAngle);
                            elementList.Add(voltageSource2);
                            voltageSource2.DisplayElement();
                            sourceAdded = true;
                            break;
                        case 4: // AC Current
                            SetFrequency();
                            Console.WriteLine("What would you like to name your Current Source?: ");
                            string currentName2 = Console.ReadLine();
                            Console.WriteLine("What is the amplitude of the Current Source in Amps?: ");
                            float currentValue2 = float.Parse(Console.ReadLine());
                            Console.WriteLine("What is the phase angle of the Current Source in degrees?: ");
                            float phaseAngle2 = float.Parse(Console.ReadLine());
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

                            case 1: // Adding Resistor
                                Console.Write("What would you like to name your Resistor?: ");
                                string resistorName = Console.ReadLine();
                                Console.Write("What is the resistance of your resistor in Ohms?: ");
                                float resistorValue = float.Parse(Console.ReadLine());
                                Resistor resistor = new Resistor(resistorName, resistorValue);
                                elementList.Add(resistor);
                                resistor.DisplayElement();
                                elementAdded = true;
                                Console.WriteLine("Resistor Added");
                                break;
                            case 2: // Adding Inductor
                                SetFrequency();
                                Console.Write("What would you like to name your Inductor?: ");
                                string inductorName = Console.ReadLine();
                                Console.Write("What is the value of the Inductor in Henrys?: ");
                                float inductorValue = float.Parse(Console.ReadLine());
                                Inductor inductor = new Inductor(inductorName, inductorValue, _frequency);
                                // inductor.SetImpedance(_frequency);
                                elementList.Add(inductor);
                                inductor.DisplayElement();
                                Console.WriteLine("Inductor Added");
                                elementAdded = true;
                                break;
                            case 3: // Adding Capacitor
                                SetFrequency();
                                Console.Write("What would you like to name your Capacitor?: ");
                                string capacitorName = Console.ReadLine();
                                Console.Write("What is the value of the Capacitor in Farads?: ");
                                float capacitorValue = float.Parse(Console.ReadLine());
                                Capacitor capacitor = new Capacitor(capacitorName, capacitorValue, _frequency);
                                // capacitor.SetImpedance(_frequency);
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
                    DisplayAllConnections();
                    bool pass = false;
                    int userChoiceConnecting = 0;
                    while(!pass)
                    {
                    Console.Write("Options: \n1. Adding a new Connection \n2. Adding to an existing Connection \n3. Return to Main Menu \nWhich would you like to do?: ");
                    try
                    {
                        userChoiceConnecting = int.Parse(Console.ReadLine());
                        pass = true;
                    }
                    catch
                    {   
                        Console.Clear();
                        Console.WriteLine("Please enter a number between 1 and 3");
                        // DisplaySpinner(5);
                        userChoiceConnecting = 0;
                    }
                    }



                    if (userChoiceConnecting == 1)
                    {
                        Console.Write("Choose the first element you would like to connect: ");
                        int element1 = int.Parse(Console.ReadLine());
                        Console.Write($"Choose the element you would like to connect to {elementList[element1-1].GetName()}: ");
                        int element2 = int.Parse(Console.ReadLine());
                        
                        // Makes sure that user doesn't connect an element to itself
                        if (element1 == element2)
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry, this program does not permit connecting an element to itself");
                            break;
                        }
                        string typeElement1 = elementList[element1-1].GetElementType();
                        string typeElement2 = elementList[element2-1].GetElementType();
                        bool element1IsSource = false;
                        bool element2IsSource = false;

                        if (typeElement1 == "AC Voltage Source" || typeElement1 == "DC Voltage Source" || typeElement1 == "AC Current Source" || typeElement1 == "DC Current Source")
                        {
                            Console.Write($"Are you connecting the positive terminal of {elementList[element1-1].GetName()} to {elementList[element2-1].GetName()}? [y/n]: ");
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

                        if (element1IsSource== true && element2IsSource == true)
                        {
                            ConnectSourceToSource(elementList[element1-1], elementList[element2-1]);
                        }
                        else if (element1IsSource == true && element2IsSource == false)
                        {
                            ConnectSourceToElement(elementList[element1-1], elementList[element2-1]);
                        }
                        else if (element1IsSource == false && element2IsSource == true)
                        {
                            ConnectSourceToElement(elementList[element2-1], elementList[element1-1]);
                        }
                        else
                        {
                            ConnectElementToElement(elementList[element1-1], elementList[element2-1]);
                        }
                    }
                    else if (userChoiceConnecting == 2)
                    {
                        // TODO: Add function that will allow user to connect a single element to an existing connection


                        Console.Clear();
                        DisplayAllConnections();
                        Console.Write("Which connection would you like to add to?: ");
                        int connectionChoice = int.Parse(Console.ReadLine());
                        KeyValuePair<string, List<Tuple<string, float, float, bool?>>> chosenConnection = elementConnections.ElementAt(connectionChoice-1);
                        DisplayElements();
                        Console.Write($"Which element would you like to add to this connection - ");
                        DisplaySingleConnection(chosenConnection);
                        Console.WriteLine(")?:");
                        int elementConnectionChoice = int.Parse(Console.ReadLine());
                        string chosenElement = elementList[elementConnectionChoice-1].GetElementType();


                        // if (elementConnections.Value.Item1)
                        // {
                        //     Console.Clear();
                        //     Console.WriteLine("Sorry, this program does not permit connecting an element to itself");
                        //     break;
                        // }



                        if(chosenElement == "Resistor" || chosenElement == "Inductor" || chosenElement == "Capacitor")
                        {
                            AddElementToConnection(chosenConnection, elementList[elementConnectionChoice-1]);
                        }
                        else
                        {
                            Console.Write($"Are you connecting the positive terminal of {elementList[elementConnectionChoice-1].GetName()} to ");
                            DisplaySingleConnection(chosenConnection); 
                            Console.Write(")? [y/n]: ");
                            string positiveTerminal = Console.ReadLine();
                            if (positiveTerminal == "y" || positiveTerminal == "Y")
                            {
                                elementList[elementConnectionChoice-1].SetPositiveTerminal(true);
                            }
                            else
                            {
                                elementList[elementConnectionChoice-1].SetPositiveTerminal(false);
                            }
                            AddSourceToConnection(chosenConnection, elementList[elementConnectionChoice-1]);
                        }
                    }


                    Console.WriteLine("Connect Elements and Sources");
                    break;


                case 5: // Find Value
                    Console.Clear();
                    Console.WriteLine("Which element would you like to find the value of?");
                    DisplayElements();
                    int elementChoice = int.Parse(Console.ReadLine());
                    string elementType = elementList[elementChoice-1].GetElementType();
                    if (elementType == "Resistor" || elementType == "Inductor" || elementType == "Capacitor")
                    {
                        Console.WriteLine("What kind of value would you like from this element?");
                        Console.WriteLine("1.Voltage (Volts) \n2.Current (Amps) \n3.Resistance(Ohms)");
                        string elementValueType = Console.ReadLine();
                        switch(elementValueType)
                        {
                            case "1": // Get Voltage across element
                                break;
                            case "2": // Get current through element
                                break;
                            case "3":
                                float elementValue = elementList[elementChoice-1].GetImpedance();
                                if (elementType == "Inductor" || elementType == "Capacitor")
                                {   
                                    if (elementValue < 0)
                                    {
                                        Console.WriteLine("-j" + Math.Abs(elementValue) + " Ω");
                                    }
                                    else
                                    {
                                        Console.WriteLine("j" + elementValue + " Ω");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(elementList[elementChoice-1].GetResistance()+ " Ω");
                                }
                                break;
                            default:
                                Console.WriteLine("Please enter a number between 1 and 3");
                                break;
                        }

                    }
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
    





        // Methods
        void DisplayElements()
        {   
            Console.WriteLine("Current Elements: ");
            if (elementList.Count == 0)
            {
                Console.WriteLine("No elements have been added yet.");
            }
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

        void SetFrequency()
        {
            if (_frequencySet == false)
            {
                Console.Write("What is the frequency of the circuit in Radians/sec?: ");
                int frequency = int.Parse(Console.ReadLine());
                _frequency = frequency;
                _frequencySet = true;
            }
        }

        void DisplayAllConnections()
        {
            Console.WriteLine("Current Connections: ");
            if (elementConnections.Count() == 0)
            {
                Console.WriteLine("No connections have been made yet.");
            }
            int counter = 0;
            foreach (KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp in elementConnections)
            {
                Console.Write(counter + 1 + ". ");

                DisplaySingleConnection(kvp);

                // int listCounter = 0;
                // foreach(Tuple<string, float, float, bool?> item in kvp.Value)
                // {
                //     // string positive;
                //     // if (kvp.Value[listCounter].Item4 == true)
                //     // {
                //     //     positive = "+";
                //     // }
                //     // else if (kvp.Value[listCounter].Item4 == false)
                //     // {
                //     //     positive = "-";
                //     // }
                //     // else
                //     // {
                //     //     positive = "";
                //     // }

                //     if(listCounter == 0)
                //     {                
                //         Console.Write(kvp.Key + " : (" + kvp.Value[0].Item1);
                //     }
                //     else
                //     {
                //         Console.Write(" <-> " + kvp.Value[listCounter].Item1);
                //     }

                //     listCounter += 1;
                // }
                counter += 1; 

                Console.WriteLine(")");

     
            }


        }

        void DisplaySingleConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp)
        {
            // KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp = elementConnections.FirstOrDefault(x => x.Key == key);
            int listCounter = 0;
                foreach(Tuple<string, float, float, bool?> item in kvp.Value)
                {
                    if(listCounter == 0)
                    {                
                        Console.Write(kvp.Key + " : (" + kvp.Value[0].Item1);
                    }
                    else
                    {
                        Console.Write(" <-> " + kvp.Value[listCounter].Item1);
                    }

                    listCounter += 1;
                }
        }

        // string SetPositiveSide(bool? positive, string name)
        // {
        //     if (positive == true)
        //     {
        //         return "+" + name;
        //     }
        //     else if (positive == false)
        //     {
        //         return "-" + name;
        //     }
        //     else
        //     {
        //         return name;
        //     }
        // }

        void ConnectSourceToElement(Element source, Element element)    // Connect Source to Element
        {
            string connectionName = source.GetType() + "-" + element.GetType();
            // source.SetPositiveSide(source.GetPositiveTerminal(), source.GetName());
            // element.SetPositiveSide(element.GetPositiveTerminal(), element.GetName());
            Tuple<string, float, float, bool?> sourceDetails = new Tuple<string, float, float, bool?>(source.GetPositiveSide(source.GetPositiveTerminal(), source.GetName()), source.GetValue(), source.GetPhaseAngle(), source.GetPositiveTerminal());
            Tuple<string, float, float, bool?> elementDetails = new Tuple<string, float, float, bool?>(element.GetPositiveSide(element.GetPositiveTerminal(), element.GetName()), element.GetResistance(), element.GetImaginaryResistance(), element.GetPositiveTerminal());
            List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
            {
                sourceDetails,
                elementDetails
            };
            elementConnections.Add(connectionName, detailsList);
            Console.WriteLine("Connect Source to Element");
        }

        void ConnectSourceToSource(Element source1, Element source2) // Connect Source to Source
        {
            string connectionName = source1.GetType() + "-" + source2.GetType();
            Tuple<string, float, float, bool?> source1Details = new Tuple<string, float, float, bool?>(source1.GetPositiveSide(source1.GetPositiveTerminal(), source1.GetName()), source1.GetValue(), source1.GetPhaseAngle(), source1.GetPositiveTerminal());
            Tuple<string, float, float, bool?> source2Details = new Tuple<string, float, float, bool?>(source2.GetPositiveSide(source2.GetPositiveTerminal(), source2.GetName()), source2.GetValue(), source2.GetPhaseAngle(), source2.GetPositiveTerminal());
            List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
            {
                source1Details,
                source2Details
            };
            elementConnections.Add(connectionName, detailsList);
            Console.WriteLine("Connect Source to Source");    
        }

        void ConnectElementToElement(Element element1, Element element2) // Connect Element to Element
        {
            string connectionName = element1.GetType() + "-" + element2.GetType();
            Tuple<string, float, float, bool?> element1Details = new Tuple<string, float, float, bool?>(element1.GetPositiveSide(element1.GetPositiveTerminal(), element1.GetName()), element1.GetValue(), element1.GetPhaseAngle(), element1.GetPositiveTerminal());
            Tuple<string, float, float, bool?> element2Details = new Tuple<string, float, float, bool?>(element2.GetPositiveSide(element2.GetPositiveTerminal(), element2.GetName()), element2.GetValue(), element2.GetPhaseAngle(), element2.GetPositiveTerminal());
            List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
            {
                element1Details,
                element2Details
            };
            elementConnections.Add(connectionName, detailsList);
            Console.WriteLine("Connect Element to Element");
        }

        void AddSourceToConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp, Element source)
        {
            List<Tuple<string, float, float, bool?>> existingConnection = kvp.Value;
            string connectionName = kvp.Key + "-" + source.GetType();

            Tuple<string, float, float, bool?> sourceDetails = new Tuple<string, float, float, bool?>(source.GetPositiveSide(source.GetPositiveTerminal(), source.GetName()), source.GetValue(), source.GetPhaseAngle(), source.GetPositiveTerminal());
            existingConnection.Add(sourceDetails);
            elementConnections.Remove(kvp.Key);
            elementConnections[connectionName] = existingConnection;

        }

        void AddElementToConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp, Element element)
        {
            Console.WriteLine(kvp.Key);
        }

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