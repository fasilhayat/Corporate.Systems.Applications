namespace Corporate.Systems.Applications.Common
{
    public interface IDeletionPolicy
    {
        public void Delete(IDataKey key);
    }
}