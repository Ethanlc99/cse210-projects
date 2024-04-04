using System;
using System.Data;
using System.Diagnostics;



// TODO: Add feature that allows user to find values of Impedance and resistance across series and parallel elements. Start with Resistors -> capacitors and inductors. Then move on to sources and find voltage across Resistors -> inductors and capacitors. Add feature that calculates values (Thevinen and Norton, parallel impedance). 
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
        
        Connections elementConnections = new Connections();
        
        
        
        // Dictionary<string, List<Tuple<string, float, float, bool?>>> elementConnections = new Dictionary<string, List<Tuple<string, float, float, bool?>>>();



        // Connections elementConnections = new Connections();


        List<Element> elementList = new List<Element>();
        
        
        
        // Test Elements
        float test_capacitance = (float) 0.00005;


        DC_Voltage test_dC_Voltage = new DC_Voltage("V1", 5);
        Resistor test_resistor = new Resistor("R1", 1000);
        DC_Current test_dC_Current = new DC_Current("C1", 5);
        Resistor test_resistor2 = new Resistor("R2", 1000);
        Capacitor test_capacitor = new Capacitor("Cap1", test_capacitance, 1000);

        elementList.Add(test_dC_Voltage);
        elementList.Add(test_resistor);
        elementList.Add(test_dC_Current);
        elementList.Add(test_resistor2);
        elementList.Add(test_capacitor);



        
        



        // Main Menu
        while (userChoice1 != 6)
        {
            Console.Clear();
            // DisplayElements();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. View All Elements/Connections");
            Console.WriteLine("2. Add Source");
            Console.WriteLine("3. Add Element");
            Console.WriteLine("4. Connect Elements and Sources");
            Console.WriteLine("5. Find Value");
            Console.WriteLine("6. Quit");
            // Console.WriteLine(". View Schematic");
            Console.Write("What would you like to do?: ");
        
        try
        {
            userChoice1 = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Please enter a number between 1 and 6");
            // DisplaySpinner(5);
        }

            switch(userChoice1)
            {
                case 1: // Shows all elements in elementList
                    int userChoiceView = 0;

                    // Loops that makes sure that the user either views all elements or all connections, or goes back to main menu
                    bool viewElements = false;
                    while (!viewElements)
                    {
                        Console.Clear();
                        Console.WriteLine("Options: \n1. View All Elements \n2. View All Connections \n3. Back to Main Menu");
                        Console.Write("Which would you like to see?: ");

                        // Makes sure user inputs appropriate number
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

                        // Switch statement that displays all elements or all connections
                        switch (userChoiceView)
                        {
                            case 1:
                                Console.Clear();
                                DisplayElements();
                                viewElements = true;
                                // DisplaySpinner(5);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                elementConnections.DisplayAllConnections();
                                viewElements = true;
                                // DisplaySpinner(5);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 3:
                                viewElements = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a number between 1 and 2");
                                userChoiceView = 0;
                                // DisplaySpinner(5);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;


                case 2: // Prompt user to add source
                    // Loops that makes sure that the user either adds a source or goes back to main menu
                    bool sourceAdded = false;
                    while (!sourceAdded)
                    {
                        Console.Clear();
                        // Displays options
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
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            userChoice3 = 0;
                        }
                        switch(userChoice3)
                        {
                            case 1: // DC Voltage
                                Console.Clear();
                            // Gets info from user
                                Console.Write("What would you like to name your Voltage Source?: ");
                                string voltageName = Console.ReadLine();
                                Console.Write("What is the value of the Voltage Source in Volts?: ");
                                float voltageValue = float.Parse(Console.ReadLine());

                            // Creates Source and adds it to elementList
                                DC_Voltage voltageSource = new DC_Voltage(voltageName, voltageValue);
                                elementList.Add(voltageSource);
                                voltageSource.DisplayElement();
                                sourceAdded = true;
                                Console.WriteLine("DC Voltage Source Added! \nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            case 2: // DC Current
                                Console.Clear();
                            // Gets into from user
                                Console.Write("What would you like to name your Current Source?: ");
                                string currentName = Console.ReadLine();
                                Console.Write("What is the value of the Current Source in Amps?: ");
                                float currentValue = float.Parse(Console.ReadLine());

                            // Creates Source and adds it to elementList
                                DC_Current currentSource = new DC_Current(currentName, currentValue);
                                elementList.Add(currentSource);
                                currentSource.DisplayElement();
                                sourceAdded = true;
                                Console.WriteLine("DC Current Source Added! \nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            case 3: // AC Voltage
                                Console.Clear();
                            //Gets info from user
                                SetFrequency();
                                Console.WriteLine("What would you like to name your Voltage Source?: ");
                                string voltageName2 = Console.ReadLine();
                                Console.WriteLine("What is the amplitude of the Voltage Source in Volts?: ");
                                float voltageValue2 = float.Parse(Console.ReadLine());
                                Console.WriteLine("What is the phase angle of the Voltage Source in degrees?: ");
                                float phaseAngle = float.Parse(Console.ReadLine());

                            // Creates Source and adds it to elementList
                                AC_Voltage voltageSource2 = new AC_Voltage(voltageName2, voltageValue2, phaseAngle);
                                elementList.Add(voltageSource2);
                                voltageSource2.DisplayElement();
                                sourceAdded = true;
                                Console.WriteLine("AC Voltage Source Added! \nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            case 4: // AC Current
                                Console.Clear();
                            // Gets info from user
                                SetFrequency();
                                Console.WriteLine("What would you like to name your Current Source?: ");
                                string currentName2 = Console.ReadLine();
                                Console.WriteLine("What is the amplitude of the Current Source in Amps?: ");
                                float currentValue2 = float.Parse(Console.ReadLine());
                                Console.WriteLine("What is the phase angle of the Current Source in degrees?: ");
                                float phaseAngle2 = float.Parse(Console.ReadLine());

                            // Creates Source and adds it to elementList
                                AC_Current currentSource2 = new AC_Current(currentName2, currentValue2, phaseAngle2);
                                elementList.Add(currentSource2);
                                currentSource2.DisplayElement();
                                sourceAdded = true;
                                Console.WriteLine("AC Current Source Added! \nPress any key to continue...");
                                Console.ReadKey();
                                break;
                            case 5: // Back to main menu
                                sourceAdded = true;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Please enter a number between 1 and 5");
                                // DisplaySpinner(5);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;


                case 3: // Prompt user to add element
                // Loop that makes sure that the user either creates an element or goes back to main menu
                    bool elementAdded = false;
                    while (!elementAdded)
                    {
                        Console.Clear();
                    // Displays options
                        Console.WriteLine("Element Options: ");
                        Console.WriteLine("1. Resistor");
                        Console.WriteLine("2. Inductor");
                        Console.WriteLine("3. Capacitor");
                        Console.WriteLine("4. Back to Main Menu");
                        Console.Write("What kind of source would you like to add?: ");
                        int userChoice2 = 0;

                    // Makes sure user enters appropriate number
                        try
                        {
                            userChoice2 = int.Parse(Console.ReadLine());
                        }
                        catch
                        {   
                            Console.Clear();
                            Console.WriteLine("Please enter a number between 1 and 4");
                            // DisplaySpinner(5);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            userChoice2 = 0;
                        }
                            switch(userChoice2)
                            {

                                case 1: // Adding Resistor
                                    Console.Clear();
                                // Gets info from user
                                    Console.Write("What would you like to name your Resistor?: ");
                                    string resistorName = Console.ReadLine();
                                    Console.Write("What is the resistance of your resistor in Ohms?: ");
                                    float resistorValue = float.Parse(Console.ReadLine());
                                // Create Resistor, adds it to elementList, and displays element
                                    Resistor resistor = new Resistor(resistorName, resistorValue);
                                    elementList.Add(resistor);
                                    resistor.DisplayElement();
                                    elementAdded = true;
                                    Console.WriteLine("Resistor Added");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                case 2: // Adding Inductor
                                    Console.Clear();
                                // Gets info from user
                                    SetFrequency();
                                    Console.Write("What would you like to name your Inductor?: ");
                                    string inductorName = Console.ReadLine();
                                    Console.Write("What is the value of the Inductor in Henrys?: ");
                                    float inductorValue = float.Parse(Console.ReadLine());
                                // Create Inductor, adds it to elementList, and displays element
                                    Inductor inductor = new Inductor(inductorName, inductorValue, _frequency);
                                    elementList.Add(inductor);
                                    inductor.DisplayElement();
                                    Console.WriteLine("Inductor Added");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    elementAdded = true;
                                    break;
                                case 3: // Adding Capacitor
                                    Console.Clear();
                                // Gets info from user
                                    SetFrequency();
                                    Console.Write("What would you like to name your Capacitor?: ");
                                    string capacitorName = Console.ReadLine();
                                    Console.Write("What is the value of the Capacitor in Farads?: ");
                                    float capacitorValue = float.Parse(Console.ReadLine());
                                // Create Capacitor, adds it to elementList, and displays element
                                    Capacitor capacitor = new Capacitor(capacitorName, capacitorValue, _frequency);
                                    elementList.Add(capacitor);
                                    capacitor.DisplayElement();
                                    Console.WriteLine("Capacitor Added");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
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
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                            }
                    }
                    break;


                case 4: // Connect elements and sources
                    Console.Clear();
                    DisplayElements();
                    elementConnections.DisplayAllConnections();

                    // Loop that makes sure that the user either create or adds to a connection, or goes back to main menu
                    bool pass = false;
                    int userChoiceConnecting = 0;
                    while(!pass)
                    {
                    Console.Write("Options: \n1. Adding a new Connection \n2. Adding to an existing Connection \n3. Return to Main Menu \nWhich would you like to do?: ");
                    // Makes sure user enters appropriate response
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
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        userChoiceConnecting = 0;
                    }
                    }



                    if (userChoiceConnecting == 1)
                    {   
                        // Prompts user to choose which element to connect
                        Console.Write("Choose the first element you would like to connect: ");
                        int element1 = int.Parse(Console.ReadLine());
                        // Prompts user to choose which element to connect to first element
                        Console.Write($"Choose the element you would like to connect to {elementList[element1-1].GetName()}: ");
                        int element2 = int.Parse(Console.ReadLine());
                        
                        // Makes sure that user doesn't connect an element to itself
                        if (element1 == element2)
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry, this program does not permit connecting an element to itself");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                        
                        // 
                        string typeElement1 = elementList[element1-1].GetElementType();
                        string typeElement2 = elementList[element2-1].GetElementType();
                        bool element1IsSource = false;
                        bool element2IsSource = false;

                        if (typeElement1 == "AC Voltage Source" || typeElement1 == "DC Voltage Source" || typeElement1 == "AC Current Source" || typeElement1 == "DC Current Source")
                        {
                            element1IsSource = true;
                            // Sets the positive terminal of the source
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
                            element2IsSource = true;
                            // Sets the positive terminal of the source
                            Console.Write($"Are you connecting the positive terminal of {elementList[element2-1].GetName()} to {elementList[element1-1].GetName()}? [y/n]: ");
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

                        // Runs proper function to connect elements/sources
                        if (element1IsSource == true && element2IsSource == true)
                        {
                            elementConnections.ConnectSourceToSource(elementList[element1-1], elementList[element2-1]);
                            elementConnections.DisplayAllConnections();
                        }
                        else if (element1IsSource == true && element2IsSource == false)
                        {
                            elementConnections.ConnectSourceToElement(elementList[element1-1], elementList[element2-1]);
                            elementConnections.DisplayAllConnections();
                        }
                        else if (element1IsSource == false && element2IsSource == true)
                        {
                            elementConnections.ConnectSourceToElement(elementList[element2-1], elementList[element1-1]);
                            elementConnections.DisplayAllConnections();
                        }
                        else
                        {
                            elementConnections.ConnectElementToElement(elementList[element1-1], elementList[element2-1]);
                            elementConnections.DisplayAllConnections();
                        }
                    }
                    else if (userChoiceConnecting == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("This feature is not yet useable. Once we are able to analyze multiple loops/meshes we will reenable this feature. Thank you for your patience.");

        //     // Implementation that has been disabled until we can analyze multiple loops/meshes
        //     // Shows Current Connections and prompts User which connection they would like to add to
        //     elementConnections.DisplayAllConnections();
        //     if (elementConnections.GetElementConnections().Count() == 0)
        //     {
        //         // DisplaySpinner(5);
        //         Console.WriteLine("Press any key to continue...");
        //         Console.ReadKey();
        //         break;
        //     }
        //     Console.Write("Which connection would you like to add to?: ");
        //     int connectionChoice = int.Parse(Console.ReadLine());
        //     KeyValuePair<string, List<Tuple<string, float, float, bool?>>> chosenConnection = elementConnections.GetConnection(connectionChoice);

        //     // Shows all elements and prompts user which element they would like to add to chosen connection
        //     DisplayElements();
        //     Console.Write($"Which element would you like to add to this connection - ");
        //     elementConnections.DisplaySingleConnection(chosenConnection);
        //     Console.WriteLine(")?:");
        //     int elementConnectionChoice = int.Parse(Console.ReadLine());
        //     string chosenElement = elementList[elementConnectionChoice-1].GetElementType();

        //     // Makes sure that user doesn't connect an element to itself
        //     foreach(Tuple<string, float, float, bool?> element in chosenConnection.Value)
        //     {
        //         if (element.Item1 == elementList[elementConnectionChoice-1].GetName())
        //         {
        //             Console.Clear();
        //             Console.WriteLine("Sorry, this program does not permit connecting a single element to a connection twice.");
        //             // DisplaySpinner(5);
        //             Console.WriteLine("Press any key to continue...");
        //             Console.ReadKey();
        //             break;
        //         }
        //     }

        //     // Adds element to chosen connection
        //     if(chosenElement == "Resistor" || chosenElement == "Inductor" || chosenElement == "Capacitor")
        //     {
        //         elementConnections.AddElementToConnection(chosenConnection, elementList[elementConnectionChoice-1]);
        //     }
        //     else
        //     {
        //         // Sets the positive terminal of the source
        //         Console.Write($"Are you connecting the positive terminal of {elementList[elementConnectionChoice-1].GetName()} to ");
        //         elementConnections.DisplaySingleConnection(chosenConnection); 
        //         Console.Write(")? [y/n]: ");
        //         string positiveTerminal = Console.ReadLine();
        //         if (positiveTerminal == "y" || positiveTerminal == "Y")
        //         {
        //             elementList[elementConnectionChoice-1].SetPositiveTerminal(true);
        //         }
        //         else
        //         {
        //             elementList[elementConnectionChoice-1].SetPositiveTerminal(false);
        //         }
        //         elementConnections.AddSourceToConnection(chosenConnection, elementList[elementConnectionChoice-1]);
        //     }
                    
                    }
                    Console.WriteLine("Element has been added! \nPress any key to continue...");
                    Console.ReadKey();
                    break;


                case 5: // Find Value
                    Console.Clear();
                    Console.Write("Options: \n1. A single element \n2. Multiple elements that are connected \n3. Equivalent Impedance \n4. Back to main menu \nWhat would you like to analyze?: ");
                    int userChoiceFinding = int.Parse(Console.ReadLine());
                    switch (userChoiceFinding)
                    {
                        case 1: // analyze single element 
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
                                elementConnections.DisplayAllConnections();
                                // Console.Write("Which Connection contains the positive terminal?: ");
                                // elementChoice = int.Parse(Console.ReadLine());     




// TODO: Calculate Zeq and use voltage divider equation to find voltage across this element. Make sure that there is a complete loop for this to work. If the circuit is not complete, show 0 for voltage and explain that the circuit needs to be complete to find voltage across an element

                                break;
                            case "2": // Get current through element

// TODO: Calculate Zeq and find current through whole circuit if there is a voltage source, or show current source value. If there is no source, or circuit is not complete, show 0 for current

                                break;
                            case "3": // Gets resistance and impedance of each element
                                float elementImpedance = elementList[elementChoice-1].GetImpedance();
                                if (elementType == "Inductor" || elementType == "Capacitor")
                                {   
                                    if (elementImpedance < 0)
                                    {
                                        Console.WriteLine("-j" + Math.Abs(elementImpedance) + " Ω");
                                        // DisplaySpinner(5);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("j" + elementImpedance + " Ω");
                                        // DisplaySpinner(5);
                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(elementList[elementChoice-1].GetResistance()+ " Ω");
                                    // DisplaySpinner(5);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                Console.WriteLine("Please enter a number between 1 and 3");
                                // DisplaySpinner(5);
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                        }

                    }

                            break;
                        case 2: // analyze multiple elements that are connected 
                            Console.WriteLine("Connections: ");
                            elementConnections.DisplayAllConnections();

                            // Prompts the user to declare which elements they want to analyze
                            Console.Write("Which Connections would you like to analyze? (Enter number of connection, separated by commas): ");
                            List<int> connectionChoice = new List<int>();
                            string connectionChoiceString = Console.ReadLine();
                            string[] connectionChoiceArray = connectionChoiceString.Split(',');
                            foreach (string connection in connectionChoiceArray)
                            {
                                connectionChoice.Add(int.Parse(connection));
                            }
                            List<string> elementNames1 = new List<string>();

// TODO: Make sure that the elements are connected to each other. We cannot analyze an elements that are not connected to each another

                            int dictCounter = 1;
                            // Iterates through each chosen element and adds element names to a list
                            foreach (KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp in elementConnections.GetElementConnections())
                            {
                                if (connectionChoice.Contains(dictCounter));
                                {
                                    foreach (Tuple<string, float, float, bool?> element in kvp.Value)
                                    {
                                        if (!elementNames1.Contains(element.Item1))
                                        {
                                            elementNames1.Add(element.Item1);
                                        }
                                    }
                                }
                                dictCounter++;  
                            }

                            // Displays Zeq for combined elements
                            Console.WriteLine(CalculateZeq(elementNames1));

                            break;
                        case 3: // Get Zeq for whole circuit
                            List<string> elementNames2 = new List<string>();
                            
                            // Check if connections have been made
                            if (elementConnections.GetElementConnections().Count() == 0)
                            {
                                Console.WriteLine("No connections have been made yet.");
                                break;
                            }

                            // Makes a list of resistive elements in declared connections
                            foreach (KeyValuePair<string, List<Tuple<string, float, float, bool?>>> item in elementConnections.GetElementConnections())
                            {
                                foreach (Tuple<string, float, float, bool?> element in item.Value)
                                {
                                    elementNames2.Add(element.Item1);
                                }
                            }

                            Console.WriteLine("Zeq: " + CalculateZeq(elementNames2));
                            DisplaySpinner(6);
                            break;
                        case 4: // return to main menu
                            break;
                        default:
                            break;
                    }





                    Console.WriteLine("Find Value");
                    break;


                // case 6: // Views schematic with all elements attached and values shown
                //     Console.WriteLine("View Schematic");
                //     break;

                case 6:
                    Console.WriteLine("Thanks for using our program today!");
                    // DisplaySpinner(5);
                    Console.WriteLine("Program terminated...");
                    break;


                default:
                    Console.WriteLine("Please enter a number between 1 and 6");
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

            // Iterates through list and displays all items with number associated with it
            foreach (Element element in sortedList)
            {
                Console.Write(counter + ". ");
                element.DisplayElement();
                counter += 1;
            }
        }

        void SetFrequency() // Adds frequency for circuit
        {
            if (_frequencySet == false)
            {
                Console.Write("What is the frequency of the circuit in Radians/sec?: ");
                int frequency = int.Parse(Console.ReadLine());
                _frequency = frequency;
                _frequencySet = true;
            }
        }


// TODO: Add to separate class for connections
        // void DisplayAllConnections() // Iterates through all declared connections and displays them with a number associated with each one.
        // {
        //     // Checks if any connections have been made
        //     Console.WriteLine("Current Connections: ");
        //     if (elementConnections.Count() == 0)
        //     {
        //         Console.WriteLine("No connections have been made yet.");
        //     }

        //     // Iterates through Dict of connections and displays each connection with name of connection and elements involved
        //     int counter = 0;
        //     foreach (KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp in elementConnections)
        //     {
        //         Console.Write(counter + 1 + ". ");

        //         DisplaySingleConnection(kvp);

        //         counter += 1; 

        //         Console.WriteLine(")");

     
        //     }


        // }

// TODO: Add to separate class for connections
        // void DisplaySingleConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp) // Displays name of connection, and all elements who are connected together
        // {
        //     // Iterates through List of element details and displays the name of element and the connection name
        //     int listCounter = 0;
        //         foreach(Tuple<string, float, float, bool?> item in kvp.Value)
        //         {
        //             if(listCounter == 0)
        //             {                
        //                 Console.Write(kvp.Key + " : (" + kvp.Value[0].Item1);
        //             }
        //             else
        //             {
        //                 Console.Write(" <-> " + kvp.Value[listCounter].Item1);
        //             }

        //             listCounter += 1;
        //         }
        // }


        string CalculateZeq(List<string> elementNames) // Calculates Zeq
        {
            
            List<string> addedElements = new List<string>();

            float realImpedance = 0;
            float imaginaryImpedance = 0;

            // Iterates through list of element names provided, finds corresponding element in elementList, and adds to real and imaginary impedance
            foreach (Element component in elementList)
            {
                if (elementNames.Contains(component.GetName()))
                {
                    if (component.GetElementType() == "Resistor" || component.GetElementType() == "Capacitor" || component.GetElementType() == " Inductor")
                    {
                        if (!addedElements.Contains(component.GetName()))
                        {
                            realImpedance += component.GetResistance();
                            imaginaryImpedance += component.GetImpedance();
                            elementNames.Add(component.GetName());
                        }
                    }
                }
            }
            return realImpedance + " + j" + "(" + imaginaryImpedance + ")" + " Ω";
        }


// TODO: Add to separate class for connections
    //    void ConnectSourceToElement(Element source, Element element)    // Connect Source to Element
    //     {
    //         // Makes name based off source and element types
    //         string connectionName = source.GetType() + "-" + element.GetType();

    //         // Define source and element details
    //         Tuple<string, float, float, bool?> sourceDetails = new Tuple<string, float, float, bool?>(source.GetPositiveSide(source.GetPositiveTerminal(), source.GetName()), source.GetValue(), source.GetPhaseAngle(), source.GetPositiveTerminal());
    //         Tuple<string, float, float, bool?> elementDetails = new Tuple<string, float, float, bool?>(element.GetPositiveSide(element.GetPositiveTerminal(), element.GetName()), element.GetResistance(), element.GetImaginaryResistance(), element.GetPositiveTerminal());

    //         // Add source and element details to list
    //         List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
    //         {
    //             sourceDetails,
    //             elementDetails
    //         };

    //         // Add list to dictionary and adds '*' if the connection name already exists
    //         while (elementConnections.Keys.Contains(connectionName))
    //         {
    //             connectionName += "*";
    //         }
    //         elementConnections.Add(connectionName, detailsList);    

    //         Console.WriteLine("Connect Source to Element");
    //     } 

// TODO: Add to separate class for connections
        // void ConnectSourceToSource(Element source1, Element source2) // Connect Source to Source
        // {
        //     // Makes name based off sources types
        //     string connectionName = source1.GetType() + "-" + source2.GetType();

        //     // Define sources details
        //     Tuple<string, float, float, bool?> source1Details = new Tuple<string, float, float, bool?>(source1.GetPositiveSide(source1.GetPositiveTerminal(), source1.GetName()), source1.GetValue(), source1.GetPhaseAngle(), source1.GetPositiveTerminal());
        //     Tuple<string, float, float, bool?> source2Details = new Tuple<string, float, float, bool?>(source2.GetPositiveSide(source2.GetPositiveTerminal(), source2.GetName()), source2.GetValue(), source2.GetPhaseAngle(), source2.GetPositiveTerminal());

        //     // Add sources details to list
        //     List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
        //     {
        //         source1Details,
        //         source2Details
        //     };

        //     // Add list to dictionary and adds '*' if the connection name already exists
        //     while (elementConnections.Keys.Contains(connectionName))
        //     {
        //         connectionName += "*";
        //     }    
        //     elementConnections.Add(connectionName, detailsList);    

            
        //     Console.WriteLine("Connect Source to Source");    
        // }

// TODO: Add to separate class for connections
        // void ConnectElementToElement(Element element1, Element element2) // Connect Element to Element
        // {
        //     // Makes name based off elements types
        //     string connectionName = element1.GetType() + "-" + element2.GetType();

        //     // Define elements details
        //     Tuple<string, float, float, bool?> element1Details = new Tuple<string, float, float, bool?>(element1.GetPositiveSide(element1.GetPositiveTerminal(), element1.GetName()), element1.GetValue(), element1.GetPhaseAngle(), element1.GetPositiveTerminal());
        //     Tuple<string, float, float, bool?> element2Details = new Tuple<string, float, float, bool?>(element2.GetPositiveSide(element2.GetPositiveTerminal(), element2.GetName()), element2.GetValue(), element2.GetPhaseAngle(), element2.GetPositiveTerminal());

        //     // Add elements details to list
        //     List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
        //     {
        //         element1Details,
        //         element2Details
        //     };

        //     // Add list to dictionary and adds '*' if the connection name already exists
        //     while (elementConnections.Keys.Contains(connectionName))
        //     {
        //         connectionName += "*";
        //     }
        //     elementConnections.Add(connectionName, detailsList);    

        //     Console.WriteLine("Connect Element to Element");
        // }

// TODO: Add to separate class for connections
        // void AddSourceToConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp, Element source)
        // {
        //     // Defines current connection and adds source name to it
        //     List<Tuple<string, float, float, bool?>> existingConnection = kvp.Value;
        //     string connectionName = kvp.Key + "-" + source.GetType();

        //     // Define source details
        //     Tuple<string, float, float, bool?> sourceDetails = new Tuple<string, float, float, bool?>(source.GetPositiveSide(source.GetPositiveTerminal(), source.GetName()), source.GetValue(), source.GetPhaseAngle(), source.GetPositiveTerminal());

        //     // Add source details to list
        //     existingConnection.Add(sourceDetails);

        //     // Removes old connection and adds new one that has new source connected
        //     elementConnections.Remove(kvp.Key);
        //     elementConnections[connectionName] = existingConnection;
        // }

// TODO: Add to separate class for connections
        // void AddElementToConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp, Element element)
        // {
        //     // Defines current connection and adds element name to it
        //     List<Tuple<string, float, float, bool?>> existingConnection = kvp.Value;
        //     string connectionName = kvp.Key + "-" + element.GetType();

        //     // Define element details
        //     Tuple<string, float, float, bool?> elementDetails = new Tuple<string, float, float, bool?>(element.GetPositiveSide(element.GetPositiveTerminal(), element.GetName()), element.GetValue(), element.GetPhaseAngle(), element.GetPositiveTerminal());

        //     // Add element details to list
        //     existingConnection.Add(elementDetails);

        //     // Removes old connection and adds new one that has new element connected
        //     elementConnections.Remove(kvp.Key);
        //     elementConnections[connectionName] = existingConnection;
        // }

        void DisplaySpinner(int time) // Displays spinner for a specified time
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