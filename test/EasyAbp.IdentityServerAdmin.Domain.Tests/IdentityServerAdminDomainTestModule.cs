using EasyAbp.IdentityServerAdmin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(IdentityServerAdminEntityFrameworkCoreTestModule)
        )]
    public class IdentityServerAdminDomainTestModule : AbpModule
    {
        
    }
}
