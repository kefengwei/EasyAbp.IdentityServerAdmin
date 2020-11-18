using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.IdentityServerAdmin
{
    [Dependency(ReplaceServices = true)]
    public class IdentityServerAdminBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "IdentityServerAdmin";
    }
}
