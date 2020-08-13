using System.Collections.Generic;

namespace EasyAbp.IdentityServerAdmin.Web
{
  public class IdentityServerAdminOptions
  {
    public string MenuName { get; set; }
    public string UrlBase { get; set; }
    public List<string> ApiResourceUserClaimSuggestions { get; set; }
    public int DefaultPageSize { get; set; } = 10;
  }
}