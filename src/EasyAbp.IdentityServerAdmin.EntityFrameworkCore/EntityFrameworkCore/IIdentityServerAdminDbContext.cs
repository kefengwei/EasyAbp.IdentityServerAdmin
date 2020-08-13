using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.IdentityServerAdmin.EntityFrameworkCore
{
    [ConnectionStringName(IdentityServerAdminDbProperties.ConnectionStringName)]
    public interface IIdentityServerAdminDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}