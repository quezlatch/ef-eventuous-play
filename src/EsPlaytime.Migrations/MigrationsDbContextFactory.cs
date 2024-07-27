using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EsPlaytime.Migrations;

    public class MigrationsDbContextFactory : IDesignTimeDbContextFactory<EsDbContext>
    {
        public EsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EsDbContext>();
            optionsBuilder.UseSqlServer("YourConnectionStringHere",
            options => options.MigrationsAssembly("EsPlaytime.Migrations"));

            return new EsDbContext(optionsBuilder.Options);
        }
    }