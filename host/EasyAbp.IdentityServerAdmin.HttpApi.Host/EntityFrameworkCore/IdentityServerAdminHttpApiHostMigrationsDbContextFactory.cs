using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.IdentityServerAdmin.EntityFrameworkCore
{
    public class IdentityServerAdminHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<IdentityServerAdminHttpApiHostMigrationsDbContext>
    {
        public IdentityServerAdminHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<IdentityServerAdminHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("IdentityServerAdmin"));

            return new IdentityServerAdminHttpApiHostMigrationsDbContext(builder.Options);
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
