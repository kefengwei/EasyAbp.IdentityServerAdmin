using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(IdentityServerAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class IdentityServerAdminHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "IdentityServerAdmin";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(IdentityServerAdminApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
