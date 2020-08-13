using EasyAbp.IdentityServerAdmin.IdentityResources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.IdentityServerAdmin.IdentityResources
{
    public interface IIdentityResourceAppService : IReadOnlyAppService<IdentityResourceDto, Guid, GetIdentityResourceListInputDto>, IApplicationService
    {
        Task<IdentityResourceDto> CreateAsync(CreateIdentityResourceInputDto input);
        Task<IdentityResourceDto> UpdateAsync(Guid id, UpdateIdentityResourceInputDto input);
        Task DeleteAsync(Guid id);
    }
}
