using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace EasyAbp.IdentityServerAdmin.ApiResources
{
    public class ApiResourceNameNowAllowedDuplicateException : BusinessException
    {
        public ApiResourceNameNowAllowedDuplicateException(string name) : base("ApiResouceNameNowAllowedDuplicate", $"The api source name {name} is duplicated! ")
        {

        }
    }
}
