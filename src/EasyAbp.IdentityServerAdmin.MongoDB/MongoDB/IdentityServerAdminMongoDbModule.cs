using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.IdentityServer.MongoDB;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace EasyAbp.IdentityServerAdmin.MongoDB
{
    [DependsOn(
        typeof(IdentityServerAdminDomainModule),
        typeof(AbpMongoDbModule),
        typeof(AbpIdentityServerMongoDbModule)
        )]
    public class IdentityServerAdminMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<IdentityServerAdminMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
