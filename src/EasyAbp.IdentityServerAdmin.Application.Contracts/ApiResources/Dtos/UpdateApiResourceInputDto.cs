using EasyAbp.IdentityServerAdmin.ApiResources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAbp.IdentityServerAdmin.ApiResources.Dtos
{
    public class UpdateApiResourceInputDto
    {
        public bool Enabled { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public List<string> UserClaims { get; set; }
        public List<ApiSecretDto> Secrets { get; set; }
        public List<ApiScopeDto> Scopes { get; set; }
    }
}
