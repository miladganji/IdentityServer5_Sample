using AdminPanelIdentityServer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelIdentityServer.Server.Contract
{
	public interface IClient
	{
		Task<ClientDto> GetClient();
		Task<bool> AddClient(ClientDto dto);

	}
}
