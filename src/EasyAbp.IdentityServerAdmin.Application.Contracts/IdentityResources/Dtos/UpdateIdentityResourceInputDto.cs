using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAbp.IdentityServerAdmin.IdentityResources.Dtos
{
    public class UpdateIdentityResourceInputDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public List<string> UserClaims { get; set; }
    }
}
