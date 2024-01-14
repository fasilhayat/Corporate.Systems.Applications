using Corporate.Systems.Applications.Common;

namespace Corporate.Systems.Applications.Application5.Redis.Adapter;

public interface IDbContext : IDeletionPolicy
{
    T? GetData<T>(IDataKey key) where T : class;

    T SaveData<T>(IDataKey key, T o) where T : class;

    void ClearData(IDataKey key);

    void ClearAllData();
}
