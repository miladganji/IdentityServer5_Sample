using AdminPanelIdentityServer.Shared.Dtos;
using GrpcData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelIdentityServer.Client.services
{
	public class GRPCservice : IGRPCservice
	{
		private readonly dataService.dataServiceClient dataServiceClient;

		public GRPCservice(GrpcData.dataService.dataServiceClient dataServiceClient)
		{
			this.dataServiceClient = dataServiceClient;
		}
		public async Task<bool> AddClient(ClientDto input)
		{
			try
			{
				AddClientRequest addClientRequest = new AddClientRequest() { 
					AllowedCorsOrigins=input.AllowedCorsOrigins,
					ClientId=input.ClientName,
					ClientName=input.ClientName,
					ClientSecrets=input.ClientSecrets,
					PostLogoutRedirectUris=input.PostLogoutRedirectUris,
					RedirectUris=input.RedirectUris
				};
				var res = await dataServiceClient.AddClientAsync(addClientRequest);
				return res.Result;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}
}
