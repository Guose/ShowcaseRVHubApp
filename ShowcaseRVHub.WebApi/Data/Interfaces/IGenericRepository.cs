namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task SaveAsync();
        Task AddAsync(T model);
        bool HasChanges();
        void Remove(T model);
    }
}