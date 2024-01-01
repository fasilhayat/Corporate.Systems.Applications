namespace Corporate.Systems.Applications.Common;

public class DataKey : IDataKey
{
    public DataKey(string key)
    {
        Key = key;
    }

    public string Key { get; init; }
}
