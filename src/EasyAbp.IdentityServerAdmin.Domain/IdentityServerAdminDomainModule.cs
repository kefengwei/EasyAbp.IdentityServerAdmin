using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(IdentityServerAdminDomainSharedModule)
        )]
    [DependsOn(
        typeof(AbpIdentityServerDomainModule)
        )]
    public class IdentityServerAdminDomainModule : AbpModule
    {

    }
}
