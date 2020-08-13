using System;
using System.Collections.Generic;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using EasyAbp.IdentityServerAdmin.Localization;
using EasyAbp.IdentityServerAdmin.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using EasyAbp.IdentityServerAdmin.Permissions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.IdentityServerAdmin.Web
{
  [DependsOn(
      typeof(IdentityServerAdminHttpApiModule),
      typeof(AbpAspNetCoreMvcUiThemeSharedModule),
      typeof(AbpAutoMapperModule)
  )]
  public class IdentityServerAdminWebModule : AbpModule
  {
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
      context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
      {
        options.AddAssemblyResource(typeof(IdentityServerAdminResource),
                  typeof(IdentityServerAdminWebModule).Assembly);
      });

      PreConfigure<IMvcBuilder>(mvcBuilder =>
      {
        mvcBuilder.AddApplicationPartIfNotExists(typeof(IdentityServerAdminWebModule).Assembly);
      });
      PreConfigure<IdentityServerAdminOptions>(options =>
      {
        options.MenuName = "IdentityServer";
        options.UrlBase = "IdentityServer";
        options.ApiResourceUserClaimSuggestions = new List<string>
          {
                    "sub",
                    "name",
                    "given_name",
                    "family_name",
                    "middle_name",
                    "nickname",
                    "preferrred_username",
                    "profile",
                    "picture",
                    "website",
                    "email",
                    "email_verified",
                    "gender",
                    "birthdate",
                    "zoneinfo",
                    "locale",
                    "phone_number",
                    "phone_number_verified",
                    "address",
                    "updated_at"
          };
      });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
      
      Configure<AbpNavigationOptions>(options =>
      {
        options.MenuContributors.Add(new IdentityServerAdminMenuContributor());
      });

      Configure<AbpVirtualFileSystemOptions>(options =>
      {
        options.FileSets.AddEmbedded<IdentityServerAdminWebModule>("EasyAbp.IdentityServerAdmin.Web");
      });

      context.Services.AddAutoMapperObjectMapper<IdentityServerAdminWebModule>();
      Configure<AbpAutoMapperOptions>(options =>
      {
        options.AddMaps<IdentityServerAdminWebModule>(validate: true);
      });

      var identityServerAdminOptions = context.Services.ExecutePreConfiguredActions<IdentityServerAdminOptions>();
      Configure<RazorPagesOptions>(options =>
      {
        options.Conventions.AuthorizePage($"/{identityServerAdminOptions.UrlBase}",
          IdentityServerAdminPermissions.ApiResource.Manage);
        //Configure authorization.
        options.Conventions.AddPageRoute("/IdentityServerAdmin",
            $"/{identityServerAdminOptions.UrlBase}");
      });
      context.Services.Configure<IdentityServerAdminOptions>(op =>
      {
        op.UrlBase = identityServerAdminOptions.UrlBase;
        op.MenuName = identityServerAdminOptions.MenuName;
        op.ApiResourceUserClaimSuggestions = identityServerAdminOptions.ApiResourceUserClaimSuggestions;
      });
      context.Services.AddRazorPages();
      context.Services.AddServerSideBlazor();
      context.Services.AddBlazorise(options => { options.ChangeTextOnKeyPress = false; }).AddBootstrapProviders()
          .AddFontAwesomeIcons();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
      var app = context.GetApplicationBuilder();
      app.ApplicationServices.UseBootstrapProviders().UseFontAwesomeIcons();
    }

    public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
    {
      var app = context.GetApplicationBuilder();
      var identityServerAdminOptions =
          app.ApplicationServices.GetRequiredService<IOptions<IdentityServerAdminOptions>>().Value;
      app.UseStaticFiles();
      app.UseConfiguredEndpoints(endpoints =>
      {
        endpoints.MapBlazorHub($"/{identityServerAdminOptions.UrlBase}/_blazor");
        endpoints.MapFallbackToPage($"~/{identityServerAdminOptions.UrlBase}" + "/{*clientroutes:nonfile}",
                  $"/IdentityServerAdmin/_Host");
      });
    }
  }
}