namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task SaveAsync();
        Task<bool> CreateAsync(T model);
        bool HasChanges();
        Task<bool> DeleteAsync(T model);
    }
}