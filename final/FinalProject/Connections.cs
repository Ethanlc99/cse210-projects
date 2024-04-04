public class Connections
{
    private Dictionary<string, List<Tuple<string, float, float, bool?>>> elementConnections;
    public Connections()
    {
        elementConnections = new Dictionary<string, List<Tuple<string, float, float, bool?>>>();
    }





// Methods

    public Dictionary<string, List<Tuple<string, float, float, bool?>>> GetElementConnections()
    {
        return elementConnections;
    }

    public KeyValuePair<string, List<Tuple<string, float, float, bool?>>> GetConnection(int connectionIndex) // Finds connection by name
    {
        return elementConnections.ElementAt(connectionIndex-1);
    }


    public void DisplayAllConnections() // Iterates through all declared connections and displays them with a number associated with each one.
    {
        // Checks if any connections have been made
        Console.WriteLine("Current Connections: ");
        if (elementConnections.Count() == 0)
        {
            Console.WriteLine("No connections have been made yet.");
        }

        // Iterates through Dict of connections and displays each connection with name of connection and elements involved
        int counter = 0;
        foreach (KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp in elementConnections)
        {
            Console.Write(counter + 1 + ". ");

            DisplaySingleConnection(kvp);

            counter += 1; 

            Console.WriteLine(")");

    
        }


    }

    public void DisplaySingleConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp) // Displays name of connection, and all elements who are connected together
    {
        // Iterates through List of element details and displays the name of element and the connection name
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

    public void ConnectSourceToElement(Element source, Element element)    // Connect Source to Element
    {
        // Makes name based off source and element types
        string connectionName = source.GetType() + "-" + element.GetType();

        // Define source and element details
        Tuple<string, float, float, bool?> sourceDetails = new Tuple<string, float, float, bool?>(source.GetPositiveSide(source.GetPositiveTerminal(), source.GetName()), source.GetValue(), source.GetPhaseAngle(), source.GetPositiveTerminal());
        Tuple<string, float, float, bool?> elementDetails = new Tuple<string, float, float, bool?>(element.GetPositiveSide(element.GetPositiveTerminal(), element.GetName()), element.GetResistance(), element.GetImaginaryResistance(), element.GetPositiveTerminal());

        // Add source and element details to list
        List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
        {
            sourceDetails,
            elementDetails
        };

        // Add list to dictionary and adds '*' if the connection name already exists
        while (elementConnections.Keys.Contains(connectionName))
        {
            connectionName += "*";
        }
        elementConnections.Add(connectionName, detailsList);    

        Console.WriteLine("Connect Source to Element");
    }

    public void ConnectSourceToSource(Element source1, Element source2) // Connect Source to Source
    {
        // Makes name based off sources types
        string connectionName = source1.GetType() + "-" + source2.GetType();

        // Define sources details
        Tuple<string, float, float, bool?> source1Details = new Tuple<string, float, float, bool?>(source1.GetPositiveSide(source1.GetPositiveTerminal(), source1.GetName()), source1.GetValue(), source1.GetPhaseAngle(), source1.GetPositiveTerminal());
        Tuple<string, float, float, bool?> source2Details = new Tuple<string, float, float, bool?>(source2.GetPositiveSide(source2.GetPositiveTerminal(), source2.GetName()), source2.GetValue(), source2.GetPhaseAngle(), source2.GetPositiveTerminal());

        // Add sources details to list
        List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
        {
            source1Details,
            source2Details
        };

        // Add list to dictionary and adds '*' if the connection name already exists
        while (elementConnections.Keys.Contains(connectionName))
        {
            connectionName += "*";
        }    
        elementConnections.Add(connectionName, detailsList);    

        
        Console.WriteLine("Connect Source to Source");    
    }

    public void ConnectElementToElement(Element element1, Element element2) // Connect Element to Element
    {
        // Makes name based off elements types
        string connectionName = element1.GetType() + "-" + element2.GetType();

        // Define elements details
        Tuple<string, float, float, bool?> element1Details = new Tuple<string, float, float, bool?>(element1.GetPositiveSide(element1.GetPositiveTerminal(), element1.GetName()), element1.GetValue(), element1.GetPhaseAngle(), element1.GetPositiveTerminal());
        Tuple<string, float, float, bool?> element2Details = new Tuple<string, float, float, bool?>(element2.GetPositiveSide(element2.GetPositiveTerminal(), element2.GetName()), element2.GetValue(), element2.GetPhaseAngle(), element2.GetPositiveTerminal());

        // Add elements details to list
        List<Tuple<string, float, float, bool?>> detailsList = new List<Tuple<string, float, float, bool?>>
        {
            element1Details,
            element2Details
        };

        // Add list to dictionary and adds '*' if the connection name already exists
        while (elementConnections.Keys.Contains(connectionName))
        {
            connectionName += "*";
        }
        elementConnections.Add(connectionName, detailsList);    

        Console.WriteLine("Connect Element to Element");
    }

    public void AddSourceToConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp, Element source)
    {
        // Defines current connection and adds source name to it
        List<Tuple<string, float, float, bool?>> existingConnection = kvp.Value;
        string connectionName = kvp.Key + "-" + source.GetType();

        // Define source details
        Tuple<string, float, float, bool?> sourceDetails = new Tuple<string, float, float, bool?>(source.GetPositiveSide(source.GetPositiveTerminal(), source.GetName()), source.GetValue(), source.GetPhaseAngle(), source.GetPositiveTerminal());

        // Add source details to list
        existingConnection.Add(sourceDetails);

        // Removes old connection and adds new one that has new source connected
        elementConnections.Remove(kvp.Key);
        elementConnections[connectionName] = existingConnection;
    }


    public void AddElementToConnection(KeyValuePair<string, List<Tuple<string, float, float, bool?>>> kvp, Element element)
    {
        // Defines current connection and adds element name to it
        List<Tuple<string, float, float, bool?>> existingConnection = kvp.Value;
        string connectionName = kvp.Key + "-" + element.GetType();

        // Define element details
        Tuple<string, float, float, bool?> elementDetails = new Tuple<string, float, float, bool?>(element.GetPositiveSide(element.GetPositiveTerminal(), element.GetName()), element.GetValue(), element.GetPhaseAngle(), element.GetPositiveTerminal());

        // Add element details to list
        existingConnection.Add(elementDetails);

        // Removes old connection and adds new one that has new element connected
        elementConnections.Remove(kvp.Key);
        elementConnections[connectionName] = existingConnection;
    }

}