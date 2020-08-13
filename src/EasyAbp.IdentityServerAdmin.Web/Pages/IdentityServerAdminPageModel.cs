using EasyAbp.IdentityServerAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.IdentityServerAdmin.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class IdentityServerAdminPageModel : AbpPageModel
    {
        protected IdentityServerAdminPageModel()
        {
            LocalizationResourceType = typeof(IdentityServerAdminResource);
            ObjectMapperContext = typeof(IdentityServerAdminWebModule);
        }
    }
} 