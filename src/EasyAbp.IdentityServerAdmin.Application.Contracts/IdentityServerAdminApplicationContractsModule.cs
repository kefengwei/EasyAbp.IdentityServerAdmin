using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(IdentityServerAdminDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class IdentityServerAdminApplicationContractsModule : AbpModule
    {

    }
}
