using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace EasyAbp.IdentityServerAdmin.Clients
{
    public class ClientIdNotAllowedDuplicateException : BusinessException
    {
        public ClientIdNotAllowedDuplicateException(string clientId) : base("ClientIdNotAllowedDuplicate", $"Client Id {clientId} is duplicated!")
        {

        }
    }
}
