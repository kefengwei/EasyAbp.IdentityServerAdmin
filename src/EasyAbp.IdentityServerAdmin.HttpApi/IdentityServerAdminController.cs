using EasyAbp.IdentityServerAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.IdentityServerAdmin
{
    public abstract class IdentityServerAdminController : AbpController
    {
        protected IdentityServerAdminController()
        {
            LocalizationResource = typeof(IdentityServerAdminResource);
        }
    }
}
