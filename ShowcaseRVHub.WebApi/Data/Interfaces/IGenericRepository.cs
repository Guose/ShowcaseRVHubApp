namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task CreateAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task UpdateAsync(T model);
        void DeleteAsync(T model);
        bool HasChanges();
        Task SaveChanges();
    }
}