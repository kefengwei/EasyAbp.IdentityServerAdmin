using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using EasyAbp.IdentityServerAdmin.ApiResources;
using EasyAbp.IdentityServerAdmin.ApiResources.Dtos;
using EasyAbp.IdentityServerAdmin.Clients;
using EasyAbp.IdentityServerAdmin.Clients.Dtos;
using EasyAbp.IdentityServerAdmin.IdentityResources;
using EasyAbp.IdentityServerAdmin.IdentityResources.Dtos;
using EasyAbp.IdentityServerAdmin.PersistedGrants;
using EasyAbp.IdentityServerAdmin.PersistedGrants.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
using System.Linq;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.AutoMapper;
using Volo.Abp.IdentityServer.Grants;

namespace EasyAbp.IdentityServerAdmin
{
    public class IdentityServerAdminApplicationAutoMapperProfile : Profile
    {
        public IdentityServerAdminApplicationAutoMapperProfile()
        {
            CreateMap<ApiResource, ApiResourceDto>()
                .ForMember(des => des.UserClaims,
                    opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)))
                ;
            CreateMap<ApiResourceSecret, ApiSecretDto>().ReverseMap();
            CreateMap<ApiResourceScope, ApiScopeDto>().ReverseMap();

            CreateMap<UpdateApiResourceInputDto, ApiResource>()
                .Ignore(des => des.UserClaims)
                .Ignore(des => des.Id)
                .Ignore(des => des.Properties)
                .Ignore(des => des.ExtraProperties)
                .Ignore(des => des.ConcurrencyStamp)
                .Ignore(des => des.AllowedAccessTokenSigningAlgorithms)
                .Ignore(des => des.ShowInDiscoveryDocument)
                .IgnoreFullAuditedObjectProperties();




            CreateMap<Client, ClientDto>()
                .ForMember(des => des.IdentityProviderRestrictions,
                    opt => opt.MapFrom(src => src.IdentityProviderRestrictions.Select(x => x.Provider))
                )
                .ForMember(des => des.PostLogoutRedirectUris,
                    opt => opt.MapFrom(src => src.PostLogoutRedirectUris.Select(x => x.PostLogoutRedirectUri))
                )
                .ForMember(des => des.RedirectUris,
                    opt => opt.MapFrom(src => src.RedirectUris.Select(x => x.RedirectUri))
                )
                .ForMember(des => des.AllowedCorsOrigins,
                    opt => opt.MapFrom(src => src.AllowedCorsOrigins.Select(x => x.Origin))
                )
                .ForMember(des => des.AllowedGrantTypes,
                    opt => opt.MapFrom(src => src.AllowedGrantTypes.Select(x => x.GrantType))
                )
                .ForMember(des => des.AllowedScopes,
                    opt => opt.MapFrom(src => src.AllowedScopes.Select(x => x.Scope))
                )
                ;
            CreateMap<ClientSecret, ClientSecretDto>().ReverseMap();
            CreateMap<ClientProperty, ClientPropertyDto>().ReverseMap();
            CreateMap<ClientClaim, ClientClaimDto>().ReverseMap();

            CreateMap<UpdateClientInputDto, Client>()
                .Ignore(des => des.IdentityProviderRestrictions)
                .Ignore(des => des.PostLogoutRedirectUris)
                .Ignore(des => des.RedirectUris)
                .Ignore(des => des.AllowedCorsOrigins)
                .Ignore(des => des.AllowedGrantTypes)
                .Ignore(des => des.AllowedScopes)
                .Ignore(des => des.Id)
                .Ignore(des => des.Properties)
                .Ignore(des => des.ExtraProperties)
                .Ignore(des => des.ConcurrencyStamp)
                .Ignore(des=>des.AllowedIdentityTokenSigningAlgorithms)
                .Ignore(des => des.RequireRequestObject)
                .IgnoreFullAuditedObjectProperties()
                ;


            CreateMap<IdentityResource, IdentityResourceDto>()
                 .ForMember(des => des.UserClaims,
                    opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)))
                ;
            CreateMap<UpdateIdentityResourceInputDto, IdentityResource>()
                .Ignore(des => des.UserClaims)
                .Ignore(des => des.Id)
                .Ignore(des => des.Properties)
                .Ignore(des => des.ExtraProperties)
                .Ignore(des => des.ConcurrencyStamp)
                .IgnoreFullAuditedObjectProperties()
                ;

            CreateMap<PersistedGrant, PersistedGrantDto>();

        }
    }
}
