using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace EasyAbp.IdentityServerAdmin.IdentityResources
{
    [Serializable]
    public class IdentityResourceNameNotAllowedDuplicateException : BusinessException
    {
        public IdentityResourceNameNotAllowedDuplicateException(string name) : base("IdentityResourceNameNotAllowedDuplicate", $"Identity resource name {name} is duplicated!")
        {

        }
    }
}