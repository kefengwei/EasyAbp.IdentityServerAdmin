using EasyAbp.IdentityServerAdmin.Localization;
using EasyAbp.IdentityServerAdmin.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.IdentityServerAdmin.Application.Contracts.EasyAbp.IdentityServerAdmin.Permissions
{
    public class IdentityServerAdminPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var identityServerAdminGroup = context.AddGroup(IdentityServerAdminPermissions.GroupName,
                L("Permission:IdentityServerAdmin"));
            var apiResourcesPermission =
                identityServerAdminGroup.AddPermission(IdentityServerAdminPermissions.ApiResource.Default,
                    L("Permission:ApiResource"));
            apiResourcesPermission.AddChild(IdentityServerAdminPermissions.ApiResource.Manage, L("Permission:Manage"));
            apiResourcesPermission.AddChild(IdentityServerAdminPermissions.ApiResource.Create, L("Permission:Create"));
            apiResourcesPermission.AddChild(IdentityServerAdminPermissions.ApiResource.Update, L("Permission:Update"));
            apiResourcesPermission.AddChild(IdentityServerAdminPermissions.ApiResource.Delete, L("Permission:Delete"));


            var clientsPermission =
                identityServerAdminGroup.AddPermission(IdentityServerAdminPermissions.Client.Default,
                    L("Permission:Client"));
            clientsPermission.AddChild(IdentityServerAdminPermissions.Client.Manage, L("Permission:Manage"));
            clientsPermission.AddChild(IdentityServerAdminPermissions.Client.Create, L("Permission:Create"));
            clientsPermission.AddChild(IdentityServerAdminPermissions.Client.Update, L("Permission:Update"));
            clientsPermission.AddChild(IdentityServerAdminPermissions.Client.Delete, L("Permission:Delete"));

            var identityResourcesPermission = identityServerAdminGroup.AddPermission(
                IdentityServerAdminPermissions.IdentityResource.Default, L("Permission:IdentityResource"));
            identityResourcesPermission.AddChild(IdentityServerAdminPermissions.IdentityResource.Manage,
                L("Permission:Manage"));
            identityResourcesPermission.AddChild(IdentityServerAdminPermissions.IdentityResource.Create,
                L("Permission:Create"));
            identityResourcesPermission.AddChild(IdentityServerAdminPermissions.IdentityResource.Update,
                L("Permission:Update"));
            identityResourcesPermission.AddChild(IdentityServerAdminPermissions.IdentityResource.Delete,
                L("Permission:Delete"));


            var persistedGrantsPermission =
                identityServerAdminGroup.AddPermission(IdentityServerAdminPermissions.PersistedGrant.Default,
                    L("Permission:PersistedGrant"));
            persistedGrantsPermission.AddChild(IdentityServerAdminPermissions.PersistedGrant.Manage,
                L("Permission:Manage"));
            persistedGrantsPermission.AddChild(IdentityServerAdminPermissions.PersistedGrant.Create,
                L("Permission:Create"));
            persistedGrantsPermission.AddChild(IdentityServerAdminPermissions.PersistedGrant.Update,
                L("Permission:Update"));
            persistedGrantsPermission.AddChild(IdentityServerAdminPermissions.PersistedGrant.Delete,
                L("Permission:Delete"));
        }


        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<IdentityServerAdminResource>(name);
        }
    }
}