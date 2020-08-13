using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin.EntityFrameworkCore
{
    [DependsOn(
        typeof(IdentityServerAdminDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule)
    )]
    public class IdentityServerAdminEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityServerAdminDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}