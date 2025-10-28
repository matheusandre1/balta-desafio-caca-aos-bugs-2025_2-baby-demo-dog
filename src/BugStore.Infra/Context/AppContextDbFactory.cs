using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BugStore.Infra.Context;
public class AppContextDbFactory : IDesignTimeDbContextFactory<AppContextDb>
{
    public AppContextDb CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppContextDb>();

        optionsBuilder.UseSqlite("Data source=bugstore.db");

        return new AppContextDb(optionsBuilder.Options);
    }
}
