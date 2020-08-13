using System.Threading.Tasks;
using EasyAbp.IdentityServerAdmin.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.IdentityServerAdmin.Web.Menus
{
    public class IdentityServerAdminMenuContributor : IMenuContributor
    {
       

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            await Task.CompletedTask;
            var _options = context.ServiceProvider.GetRequiredService<IOptions<IdentityServerAdminOptions>>().Value;
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(_options.MenuName, _options.MenuName,
                url: $"/{_options.UrlBase}"));
        }
    }
}