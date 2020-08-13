using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.IdentityServerAdmin.ApiResources.Dtos
{
    [Serializable]
    public class ApiResourceDto : FullAuditedEntityDto<Guid>
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