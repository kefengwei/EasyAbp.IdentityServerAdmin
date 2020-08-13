using EasyAbp.IdentityServerAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.IdentityServerAdmin.Pages
{
    public abstract class IdentityServerAdminPageModel : AbpPageModel
    {
        protected IdentityServerAdminPageModel()
        {
            LocalizationResourceType = typeof(IdentityServerAdminResource);
        }
    }
}