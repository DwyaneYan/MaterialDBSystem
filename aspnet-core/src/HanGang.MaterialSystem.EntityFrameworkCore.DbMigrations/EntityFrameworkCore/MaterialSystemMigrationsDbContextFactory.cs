using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HanGang.MaterialSystem.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class MaterialSystemMigrationsDbContextFactory : IDesignTimeDbContextFactory<MaterialSystemMigrationsDbContext>
    {
        public MaterialSystemMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MaterialSystemMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"));
                //.UseSqlServer(configuration.GetConnectionString("Default"));

            return new MaterialSystemMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
