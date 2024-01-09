using Corporate.Systems.Applications.Common;

namespace Corporate.Systems.Applications.Application1.Redis.Adapter;

public interface IDataAccess : IDeletionPolicy
{
    T? GetCachedData<T>(IDataKey key) where T : class;

    T CacheData<T>(IDataKey key, T o) where T : class;

    void ClearCachedData(IDataKey key);

    void ClearCache();
}
