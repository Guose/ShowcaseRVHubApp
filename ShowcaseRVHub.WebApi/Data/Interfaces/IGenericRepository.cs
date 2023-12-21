namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task SaveAsync();
        Task<bool> AddAsync(T model);
        bool HasChanges();
        void Remove(T model);
    }
}