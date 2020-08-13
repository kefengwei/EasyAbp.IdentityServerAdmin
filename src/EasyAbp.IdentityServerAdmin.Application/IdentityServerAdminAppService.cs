using EasyAbp.IdentityServerAdmin.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.IdentityServerAdmin
{
    public abstract class IdentityServerAdminAppService : ApplicationService
    {
        protected IdentityServerAdminAppService()
        {
            LocalizationResource = typeof(IdentityServerAdminResource);
            ObjectMapperContext = typeof(IdentityServerAdminApplicationModule);
        }
    }
}
