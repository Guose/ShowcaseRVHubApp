using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data
{
    public class ShowcaseDbContext : DbContext
    {
        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options) : base(options) { }

        public DbSet<ShowcaseUserModel> ShowcaseUsers => Set<ShowcaseUserModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ShowcaseUserModel>().HasKey(x => x.Id);
        }
    }
}
