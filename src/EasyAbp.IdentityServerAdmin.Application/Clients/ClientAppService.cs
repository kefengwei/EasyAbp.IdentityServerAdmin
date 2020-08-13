using EasyAbp.IdentityServerAdmin.Clients.Dtos;
using EasyAbp.IdentityServerAdmin.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.Clients;

namespace EasyAbp.IdentityServerAdmin.Clients
{
  [Authorize(IdentityServerAdminPermissions.Client.Default)]
  public class ClientAppService : ReadOnlyAppService<Client, ClientDto, Guid, GetClientListInputDto>, IClientAppService
  {
    private readonly IClientRepository _repository;

    public ClientAppService(IClientRepository repository) : base((IReadOnlyRepository<Client, Guid>)repository)
    {
      _repository = repository;
    }


    public override Task<PagedResultDto<ClientDto>> GetListAsync(GetClientListInputDto input)
    {
      return base.GetListAsync(input);
    }

    public override Task<ClientDto> GetAsync(Guid id)
    {
      return base.GetAsync(id);
    }
    [Authorize(IdentityServerAdminPermissions.Client.Create)]
    public async Task<ClientDto> CreateAsync(CreateClientInputDto input)
    {
      var clientIdIsExist = await _repository.CheckClientIdExistAsync(input.ClientId.Trim());
      if (clientIdIsExist)
      {
        throw new ClientIdNotAllowedDuplicateException(input.ClientId);
      }

      var client = new Client(GuidGenerator.Create(), input.ClientId.Trim())
      {
        ClientName = input.ClientName?.Trim(),
        ClientUri = input.ClientUri?.Trim(),
        LogoUri = input.LogoUri?.Trim(),
        Description = input.Description?.Trim()
      };

      ConfigureClient(client, input.ClientType);
      client = await _repository.InsertAsync(client);
      return MapToGetOutputDto(client);
    }


    [Authorize(IdentityServerAdminPermissions.Client.Update)]
    public async Task<ClientDto> UpdateAsync(Guid id, UpdateClientInputDto input)
    {
      var clientIdIsExist = await _repository.CheckClientIdExistAsync(input.ClientId, id);
      if (clientIdIsExist)
      {
        throw new ClientIdNotAllowedDuplicateException(input.ClientId);
      }
      var client = await _repository.FindAsync(id, true);
      client = ObjectMapper.Map<UpdateClientInputDto, Client>(input, client);

      client.RemoveAllIdentityProviderRestrictions();
      input.IdentityProviderRestrictions
        .ForEach(x => client.AddIdentityProviderRestriction(x));

      client.RemoveAllPostLogoutRedirectUris();
      input.PostLogoutRedirectUris
        .ForEach(x => client.AddPostLogoutRedirectUri(x));

      client.RemoveAllRedirectUris();
      input.RedirectUris
        .ForEach(x => client.AddRedirectUri(x));

      client.RemoveAllCorsOrigins();
      input.AllowedCorsOrigins
        .ForEach(x => client.AddCorsOrigin(x));

      client.RemoveAllAllowedGrantTypes();
      input.AllowedGrantTypes
        .ForEach(x => client.AddGrantType(x));

      client.RemoveAllScopes();
      input.AllowedScopes
        .ForEach(x => client.AddScope(x));

      client = await _repository.UpdateAsync(client);
      return MapToGetOutputDto(client);
    }
    [Authorize(IdentityServerAdminPermissions.Client.Delete)]
    public async Task DeleteAsync(Guid id)
    {
      var client = await _repository.FindAsync(id);

      await _repository.DeleteAsync(client);
    }


    private void ConfigureClient(Client client, ClientType clientType)
    {
      switch (clientType)
      {
        case ClientType.Empty:
          break;
        case ClientType.Device:
          ConfigureDevice(client);
          break;
        case ClientType.WebServerSideRenderer:
          ConfigureWebServiceSide(client);
          break;
        case ClientType.Spa:
          ConfigureWebSpa(client);
          break;
        case ClientType.WebHybrid:
          ConfigureWebHybrid(client);
          break;
        case ClientType.Native:
          ConfigureNative(client);
          break;
        case ClientType.Machine:
          ConfigureMachine(client);
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(ClientType));
      }
    }

    private void ConfigureClientDefaultUrls(Client client)
    {
      if (!string.IsNullOrEmpty(client.ClientUri))
      {
        client.AddCorsOrigin(client.ClientUri);
        client.AddRedirectUri(client.ClientUri);
        if (!client.PostLogoutRedirectUris.Any())
        {
          client.AddPostLogoutRedirectUri(client.ClientUri);
        }
      }
    }

    private void ConfigureDevice(Client client)
    {
      client.AddGrantType(IdentityServer4.Models.GrantType.DeviceFlow);
      client.AddScope("openid");
      client.RequireClientSecret = false;
      client.AllowOfflineAccess = true;
    }

    private void ConfigureWebServiceSide(Client client)
    {
      client.AddGrantType(IdentityServer4.Models.GrantType.AuthorizationCode);
      client.AllowAccessTokensViaBrowser = false;
      client.RequireClientSecret = true;
      client.RequirePkce = true;
      client.AddScope("openid");
      client.AddScope("profile");
      ConfigureClientDefaultUrls(client);
    }

    private void ConfigureWebSpa(Client client)
    {
      client.AddGrantType(IdentityServer4.Models.GrantType.AuthorizationCode);
      client.RequireClientSecret = false;
      client.RequirePkce = true;
      client.AddScope("openid");
      client.AddScope("profile");
      ConfigureClientDefaultUrls(client);
    }
    private void ConfigureWebHybrid(Client client)
    {
      client.AddGrantType(IdentityServer4.Models.GrantType.Hybrid);
      client.AddScope("openid");
      client.AddScope("profile");
      ConfigureClientDefaultUrls(client);
    }

    private void ConfigureNative(Client client)
    {
      client.AddGrantType(IdentityServer4.Models.GrantType.AuthorizationCode);
      client.RequireClientSecret = false;
      client.AddScope("openid");
      client.AddScope("profile");
    }
    private void ConfigureMachine(Client client)
    {
      client.AddGrantType(IdentityServer4.Models.GrantType.ClientCredentials);
      client.AddScope("openid");
      client.RequireConsent = false;
      client.RequireClientSecret = true;
    }
  }
}
