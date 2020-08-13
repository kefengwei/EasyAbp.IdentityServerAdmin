using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(IdentityServerAdminApplicationModule),
        typeof(IdentityServerAdminDomainTestModule)
        )]
    public class IdentityServerAdminApplicationTestModule : AbpModule
    {

    }
}
