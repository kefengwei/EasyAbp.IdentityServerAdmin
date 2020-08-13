using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(IdentityServerAdminHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class IdentityServerAdminConsoleApiClientModule : AbpModule
    {
        
    }
}
