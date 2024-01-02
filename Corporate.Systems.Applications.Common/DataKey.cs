namespace Corporate.Systems.Applications.Common;

public class DataKey : IDataKey
{
    public DataKey(string identifier)
    {
        Identifier = identifier;
    }

    public string Identifier { get; init; }
}
