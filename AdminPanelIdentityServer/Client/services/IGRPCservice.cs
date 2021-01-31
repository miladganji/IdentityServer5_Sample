using AdminPanelIdentityServer.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelIdentityServer.Client.services
{
public	interface IGRPCservice
	{
		Task<bool> AddClient(ClientDto input);
	}
}
