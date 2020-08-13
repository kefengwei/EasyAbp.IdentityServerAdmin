using EasyAbp.IdentityServerAdmin.Clients.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EasyAbp.IdentityServerAdmin.Clients
{
    public interface IClientAppService : IReadOnlyAppService<ClientDto, Guid, GetClientListInputDto>, IApplicationService
    {
        Task<ClientDto> CreateAsync(CreateClientInputDto input);
        Task<ClientDto> UpdateAsync(Guid id, UpdateClientInputDto input);
        Task DeleteAsync(Guid id);
    }
}
