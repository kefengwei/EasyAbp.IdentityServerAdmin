using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.IdentityServerAdmin.EntityFrameworkCore
{
    public class IdentityServerAdminHttpApiHostMigrationsDbContext : AbpDbContext<IdentityServerAdminHttpApiHostMigrationsDbContext>
    {
        public IdentityServerAdminHttpApiHostMigrationsDbContext(DbContextOptions<IdentityServerAdminHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureIdentityServerAdmin();
        }
    }
}
