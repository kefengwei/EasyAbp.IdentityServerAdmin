using EasyAbp.IdentityServerAdmin.PersistedGrants.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.IdentityServerAdmin.PersistedGrants
{
    public interface IPersistedGrantAppService : IReadOnlyAppService<PersistedGrantDto, Guid, GetPersistedGrantListInputDto>, IApplicationService
    {
        Task DeleteAsync(Guid id);
    }
}
