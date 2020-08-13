using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EasyAbp.IdentityServerAdmin.MongoDB;
using EasyAbp.IdentityServerAdmin.MultiTenancy;
using EasyAbp.IdentityServerAdmin.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.MongoDB;
using Volo.Abp.SettingManagement.MongoDB;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.MongoDB;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.Threading;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
        typeof(IdentityServerAdminWebModule),
        typeof(IdentityServerAdminApplicationModule),
        typeof(IdentityServerAdminMongoDbModule),
        typeof(AbpAuditLoggingMongoDbModule),
        typeof(AbpAutofacModule),
        typeof(AbpAccountWebModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpSettingManagementMongoDbModule),
        typeof(AbpPermissionManagementMongoDbModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityMongoDbModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementMongoDbModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreSerilogModule)
    )]
    public class IdentityServerAdminWebUnifiedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(IdentityServerAdminApplicationModule).Assembly);
            });
            
            

            Configure<AbpDbContextOptions>(options => { options.UseSqlServer(); });

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<IdentityServerAdminDomainSharedModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            string.Format("..{0}..{0}src{0}EasyAbp.IdentityServerAdmin.Domain.Shared",
                                Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<IdentityServerAdminDomainModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            string.Format("..{0}..{0}src{0}EasyAbp.IdentityServerAdmin.Domain",
                                Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<IdentityServerAdminApplicationContractsModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            string.Format("..{0}..{0}src{0}EasyAbp.IdentityServerAdmin.Application.Contracts",
                                Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<IdentityServerAdminApplicationModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            string.Format("..{0}..{0}src{0}EasyAbp.IdentityServerAdmin.Application",
                                Path.DirectorySeparatorChar)));
                    options.FileSets.ReplaceEmbeddedByPhysical<IdentityServerAdminWebModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            string.Format("..{0}..{0}src{0}EasyAbp.IdentityServerAdmin.Web",
                                Path.DirectorySeparatorChar)));
                });
            }

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "IdentityServerAdmin API", Version = "v1"});
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português (Brasil)"));
                options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });

            Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseAuthentication();

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAbpRequestLocalization();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API"); });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();

            using (var scope = context.ServiceProvider.CreateScope())
            {
                AsyncHelper.RunSync(async () =>
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                });
            }
        }
    }
}