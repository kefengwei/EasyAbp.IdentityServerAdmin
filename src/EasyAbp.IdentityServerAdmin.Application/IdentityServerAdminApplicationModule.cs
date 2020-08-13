using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace EasyAbp.IdentityServerAdmin
{
    [DependsOn(
       typeof(AbpIdentityServerDomainModule),
       typeof(IdentityServerAdminApplicationContractsModule),
       typeof(AbpDddApplicationModule),
       typeof(AbpAutoMapperModule)
       )]
    public class IdentityServerAdminApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<IdentityServerAdminApplicationAutoMapperProfile>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<IdentityServerAdminApplicationAutoMapperProfile>(validate: true);
            }
            );
            
            
        }
    }
}
