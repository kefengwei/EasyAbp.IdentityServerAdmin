using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.IdentityServerAdmin.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.IdentityServer;


namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    [DependsOn(
        typeof(AbpIdentityServerDomainSharedModule)
        )]
    public class IdentityServerAdminDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<IdentityServerAdminDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<IdentityServerAdminResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/IdentityServerAdmin");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("IdentityServerAdmin", typeof(IdentityServerAdminResource));
            });
        }
    }
}
