using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.IdentityServerAdmin.EntityFrameworkCore
{
    public class IdentityServerAdminModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public IdentityServerAdminModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}