using EasyAbp.IdentityServerAdmin.ApiResources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.IdentityServerAdmin.ApiResources
{
    public interface IApiResourceAppService : IReadOnlyAppService<ApiResourceDto, Guid, GetApiResourceListInput>
    {

        Task<ApiResourceDto> CreateAsync(CreateApiResourceInputDto input);
        Task<ApiResourceDto> UpdateAsync(Guid id,UpdateApiResourceInputDto input);
        Task DeleteAsync(Guid id);
    }
}
