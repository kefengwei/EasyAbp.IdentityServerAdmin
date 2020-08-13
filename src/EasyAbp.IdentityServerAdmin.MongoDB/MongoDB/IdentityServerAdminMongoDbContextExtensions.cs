using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.IdentityServerAdmin.MongoDB
{
    public static class IdentityServerAdminMongoDbContextExtensions
    {
        public static void ConfigureIdentityServerAdmin(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new IdentityServerAdminMongoModelBuilderConfigurationOptions(
                IdentityServerAdminDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}