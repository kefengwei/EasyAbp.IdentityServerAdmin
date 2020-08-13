using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.IdentityServerAdmin.MongoDB
{
    public class IdentityServerAdminMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public IdentityServerAdminMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}