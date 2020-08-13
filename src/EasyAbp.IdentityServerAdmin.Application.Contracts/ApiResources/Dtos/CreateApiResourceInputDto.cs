using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAbp.IdentityServerAdmin.ApiResources.Dtos
{
    public class CreateApiResourceInputDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public List<string> UserClaims { get; set; }
    }
}
