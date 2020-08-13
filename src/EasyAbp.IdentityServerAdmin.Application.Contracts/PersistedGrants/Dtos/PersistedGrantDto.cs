using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.IdentityServerAdmin.PersistedGrants.Dtos
{
    public class PersistedGrantDto:EntityDto<Guid>
    {
        public  string Key { get; set; }

        public  string Type { get; set; }

        public  string SubjectId { get; set; }

        public  string ClientId { get; set; }

        public  DateTime CreationTime { get; set; }

        public  DateTime? Expiration { get; set; }

        public  string Data { get; set; }   
    }  
}
 