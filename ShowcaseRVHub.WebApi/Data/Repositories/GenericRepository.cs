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

        public async Task<bool> AddAsync(TEntity model)
        {
            if (model == null)
            {
                return false;
            }

            await Context.Set<TEntity>().AddAsync(model);
            await SaveAsync();
            return true;
        }

        public void Remove(TEntity model)
        {            
            if (model != null)
            {
                Context.Set<TEntity>().Remove(model);
            }            
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