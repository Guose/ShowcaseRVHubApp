using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
    {
        protected readonly TContext Context;
        protected GenericRepository(TContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TEntity model)
        {
            await Context.Set<TEntity>().AddAsync(model);
        }

        public void Remove(TEntity model)
        {
            Context.Set<TEntity>().Remove(model);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsyncEF();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Context.Set<TEntity>().FirstAsyncEF(i => i.Equals(id));
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}