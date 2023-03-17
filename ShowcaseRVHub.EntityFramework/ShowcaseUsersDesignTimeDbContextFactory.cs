using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowcaseRVHub.EntityFramework
{
    public class ShowcaseUsersDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShowcaseUsersDbContext>
    {
        public ShowcaseUsersDbContext CreateDbContext(string[]? args = null)
        {
            return new ShowcaseUsersDbContext(
                new DbContextOptionsBuilder().UseSqlite("Data Source=ShowcaseRVHub.db").Options);
        }
    }
}
