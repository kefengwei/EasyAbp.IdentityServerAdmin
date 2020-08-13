using EasyAbp.IdentityServerAdmin.ApiResources;
using EasyAbp.IdentityServerAdmin.ApiResources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using EasyAbp.IdentityServerAdmin.Permissions;
using System.Linq;

namespace EasyAbp.IdentityServerAdmin.Application.EasyAbp.IdentityServerAdmin.ApiResources
{
  [Authorize(IdentityServerAdminPermissions.ApiResource.Default)]
  public class ApiResourceAppService : ReadOnlyAppService<ApiResource, ApiResourceDto, Guid, GetApiResourceListInput>, IApiResourceAppService
  {
    private readonly IApiResourceRepository _repository;

    public ApiResourceAppService(IApiResourceRepository repository) : base((IReadOnlyRepository<ApiResource, Guid>)repository)
    {
      _repository = repository;
    }



    public override async Task<PagedResultDto<ApiResourceDto>> GetListAsync(GetApiResourceListInput input)
    {

      var totalCount = await _repository.GetCountAsync();
      var entities = await _repository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount, null, includeDetails: true);
      return new PagedResultDto<ApiResourceDto>(totalCount, entities.Select(MapToGetListOutputDto).ToList());

    }

    public override async Task<ApiResourceDto> GetAsync(Guid id)
    {
      var apiResource = await GetEntityByIdAsync(id);
      return MapToGetListOutputDto(apiResource);
    }


    [Authorize(IdentityServerAdminPermissions.ApiResource.Create)]
    public async Task<ApiResourceDto> CreateAsync(CreateApiResourceInputDto input)
    {

      var nameExist = await _repository.CheckNameExistAsync(input.Name);

      if (nameExist)
      {
        throw new ApiResourceNameNowAllowedDuplicateException(input.Name);
      }

      var apiResource = new ApiResource(GuidGenerator.Create(), input.Name, input.DisplayName, input.Description);
      input.UserClaims.ForEach(x => apiResource.AddUserClaim(x));
      apiResource = await _repository.InsertAsync(apiResource);
      return MapToGetOutputDto(apiResource);
    }

    [Authorize(IdentityServerAdminPermissions.ApiResource.Update)]
    public async Task<ApiResourceDto> UpdateAsync(Guid id, UpdateApiResourceInputDto input)
    {
      var nameExist = await _repository.CheckNameExistAsync(input.Name, id);

      if (nameExist)
      {
        throw new ApiResourceNameNowAllowedDuplicateException(input.Name);
      }
      var apiResource = await _repository.FindAsync(id, true);
      apiResource = ObjectMapper.Map<UpdateApiResourceInputDto, ApiResource>(input, apiResource);
      apiResource = await _repository.UpdateAsync(apiResource);
      return MapToGetListOutputDto(apiResource);
    }

    [Authorize(IdentityServerAdminPermissions.ApiResource.Delete)]
    public async Task DeleteAsync(Guid id)
    {
      var apiResource = await _repository.FindAsync(id);
      await _repository.DeleteAsync(apiResource);
    }
  }
}
