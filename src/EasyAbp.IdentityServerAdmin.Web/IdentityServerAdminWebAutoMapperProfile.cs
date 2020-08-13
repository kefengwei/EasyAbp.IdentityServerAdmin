using AutoMapper;
using EasyAbp.IdentityServerAdmin.ApiResources.Dtos;
using EasyAbp.IdentityServerAdmin.Clients.Dtos;
using EasyAbp.IdentityServerAdmin.IdentityResources.Dtos;

namespace EasyAbp.IdentityServerAdmin.Web
{
    public class IdentityServerAdminWebAutoMapperProfile : Profile
    {
        public IdentityServerAdminWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */


            CreateMap<ApiResourceDto, UpdateApiResourceInputDto>();
            CreateMap<ClientDto, UpdateClientInputDto>();
            CreateMap<IdentityResourceDto, UpdateIdentityResourceInputDto>();
        }
    }
}