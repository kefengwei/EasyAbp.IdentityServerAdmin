using System;
using System.Collections.Generic;
using System.Text;

namespace EasyAbp.IdentityServerAdmin.Clients.Dtos
{
    public class ClientSecretDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
