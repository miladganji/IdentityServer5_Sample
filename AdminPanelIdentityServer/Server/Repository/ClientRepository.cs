using AdminPanelIdentityServer.Server.Contract;
using AdminPanelIdentityServer.Shared.Dtos;
using blazorSource.Server.Ado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelIdentityServer.Server.Repository
{
	public class ClientRepository : IClient
	{
		private readonly AdoSettings setting;

		public ClientRepository(AdoSettings _setting)
		{
			setting = _setting;
		}



		public async Task<bool> AddClient(ClientDto dto)
		{
			if (setting.Connection.State==System.Data.ConnectionState.Closed)
			{
				setting.Connect();
			}

			try
			{
				string _client = "client_";
				string sql = "insert into Clients(Enabled,ClientId,ProtocolType,RequireClientSecret,ClientName" +
					",Description,ClientUri,LogoUri,RequireConsent," +
					"AllowRememberConsent,AlwaysIncludeUserClaimsInIdToken,RequirePkce," +
					"AllowPlainTextPkce,RequireRequestObject,AllowAccessTokensViaBrowser," +
					"FrontChannelLogoutUri,FrontChannelLogoutSessionRequired,BackChannelLogoutUri," +
					"BackChannelLogoutSessionRequired,AllowOfflineAccess,IdentityTokenLifetime,AllowedIdentityTokenSigningAlgorithms," +
					"AccessTokenLifetime,AuthorizationCodeLifetime,ConsentLifetime,AbsoluteRefreshTokenLifetime," +
					"SlidingRefreshTokenLifetime,RefreshTokenUsage,UpdateAccessTokenClaimsOnRefresh," +
					"RefreshTokenExpiration,AccessTokenType,EnableLocalLogin,IncludeJwtId,AlwaysSendClientClaims," +
					"ClientClaimsPrefix,PairWiseSubjectSalt,Created,Updated,LastAccessed,UserSsoLifetime,UserCodeType," +
					"DeviceCodeLifetime,NonEditable) values('" + 1 + "','" + dto.ClientId + "','oidc','" + 0 + "','" + dto.ClientName + "','" + null + "','" +
					null + "','" + null + "','" + 0 + "','" + 1 + "','" + 0 + "','" + 1 + "','" + 0 + "','" + 0 + "','" + 0 + "','" +
					null + "','" + 1 + "','" + null + "','" + 1 + "','" + 0 + "','" + 300 + "','" + null + "','" + 3600 + "','" + 300 + "','" + null + "','" + 2592000 + "','" +
					1296000 + "','" + 1 + "','" + 0 + "','" + 1 + "','" + 0 + "','" + 1 + "','" + 1 + "','" + 0 + "','" + _client + "','" + null + "','" + DateTime.Now + "','" +
					null + "','" + null + "','" + null + "','" + null + "','" + 300 + "','" + 0 + "'" + ")";
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = setting.Connection;
				cmd.CommandText = sql;
				cmd.CommandType = System.Data.CommandType.Text;
				await cmd.ExecuteNonQueryAsync();

				//add client to

				return true;


			}
			catch (Exception ex)
			{
			    
				throw new Exception(ex.Message);
			}
			finally {

				setting.DisConnect();
			 }
		}

		public Task<ClientDto> GetClient()
		{
			throw new NotImplementedException();
		}
	}
}
