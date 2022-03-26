namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object data);
        void Add(string key, object data, int duration);
        T Get<T>(string key);
        object Get(string key);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
