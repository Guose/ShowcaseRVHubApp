namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task SaveAsync();
        Task<bool> AddAsync(T model);
        bool HasChanges();
        void Remove(T model);
    }
}