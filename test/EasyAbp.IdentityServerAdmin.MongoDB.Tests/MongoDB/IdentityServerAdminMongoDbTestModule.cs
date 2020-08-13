using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin.MongoDB
{
    [DependsOn(
        typeof(IdentityServerAdminTestBaseModule),
        typeof(IdentityServerAdminMongoDbModule)
        )]
    public class IdentityServerAdminMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}