using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.IdentityServerAdmin.MongoDB
{
    [ConnectionStringName(IdentityServerAdminDbProperties.ConnectionStringName)]
    public class IdentityServerAdminMongoDbContext : AbpMongoDbContext, IIdentityServerAdminMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureIdentityServerAdmin();
        }
    }
}