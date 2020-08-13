using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.IdentityServerAdmin
{
    [Dependency(ReplaceServices = true)]
    public class IdentityServerAdminBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "IdentityServerAdmin";
    }
}
