# EasyAbp.IdentityServerAdmin
Abp IdentityServer4 Admin Panel

## Get Started
1. Install the following NuGet packages.
  * `EasyAbp.IdentityServerAdmin.Application`
  * `EasyAbp.IdentityServerAdmin.Web`
2. Add `DependsOn(typeof(xxx))` attribute to configure the module dependencies.
  > Due to `Volo.Abp.IdentityServer.Domain`'s target framework is `netcoreapp3.1`, so you should depends on `IdentityServerAdminWebModule` and `IdentityServerAdminApplicationModule` in your web module project at the same time.
