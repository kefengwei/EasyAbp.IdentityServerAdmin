using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Reflection;

namespace EasyAbp.IdentityServerAdmin.Permissions
{
    public class IdentityServerAdminPermissions
    {
        public const string GroupName = "EasyAbp.IdentityServerAdmin";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdentityServerAdminPermissions));
        }

        public class ApiResource
        {
            public const string Default = GroupName + ".ApiResource";
            public const string Manage = Default + ".Manage"; 
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete"; 
        }

        public class Client
        {
            public const string Default = GroupName + ".Client";
            public const string Manage = Default + ".Manage";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class IdentityResource
        {
            public const string Default = GroupName + ".IdentityResource";
            public const string Manage = Default + ".Manage";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class PersistedGrant
        {
            public const string Default = GroupName + ".PersistedGrant";
            public const string Manage = Default + ".Manage";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}