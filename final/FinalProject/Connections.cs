public class Connections
{
    public Dictionary<string, List<Tuple<string, float, float, bool?>>> connections;
    public Connections()
    {
        connections = new Dictionary<string, List<Tuple<string, float, float, bool?>>>();
    }
}