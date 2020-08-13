using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.IdentityServerAdmin.EntityFrameworkCore
{
    [ConnectionStringName(IdentityServerAdminDbProperties.ConnectionStringName)]
    public class IdentityServerAdminDbContext : AbpDbContext<IdentityServerAdminDbContext>, IIdentityServerAdminDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public IdentityServerAdminDbContext(DbContextOptions<IdentityServerAdminDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureIdentityServerAdmin();
        }
    }
}