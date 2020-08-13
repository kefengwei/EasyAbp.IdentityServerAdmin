using EasyAbp.IdentityServerAdmin.Permissions;
using EasyAbp.IdentityServerAdmin.PersistedGrants.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.Grants;

namespace EasyAbp.IdentityServerAdmin.PersistedGrants
{
  [Authorize(IdentityServerAdminPermissions.PersistedGrant.Default)]
  public class PersistedGrantAppService : ReadOnlyAppService<PersistedGrant, PersistedGrantDto, Guid, GetPersistedGrantListInputDto>, IPersistedGrantAppService
  {
    private readonly IPersistentGrantRepository _repository;

    public PersistedGrantAppService(IPersistentGrantRepository repository) : base((IReadOnlyRepository<PersistedGrant, Guid>)repository)
    {
      _repository = repository;
    }

    public override Task<PagedResultDto<PersistedGrantDto>> GetListAsync(GetPersistedGrantListInputDto input)
    {
      return base.GetListAsync(input);
    }
    [Authorize(IdentityServerAdminPermissions.PersistedGrant.Delete)]
    public async Task DeleteAsync(Guid id)
    {
      var persistedGrant = await _repository.FindAsync(id);
      await _repository.DeleteAsync(persistedGrant);
    }
  }
}
