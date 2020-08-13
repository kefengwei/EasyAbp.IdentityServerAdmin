using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.IdentityServerAdmin.MongoDB
{
    [ConnectionStringName(IdentityServerAdminDbProperties.ConnectionStringName)]
    public interface IIdentityServerAdminMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
