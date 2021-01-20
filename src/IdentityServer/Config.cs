using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blankOfDotNet.IdentitySrv
{
	public class config
	{

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{

			return new List<IdentityResource>{
			
				 new IdentityResources.OpenId(),
				 new IdentityResources.Profile()
			};
		}

		public static List<TestUser> GetUsers()
		{

			return new List<TestUser>() { 
			 
				new TestUser(){ 
				 
					SubjectId="1",
					Username="milad",
					Password="password"
				},
				new TestUser(){

					SubjectId="2",
					Username="ganji",
					Password="password"
				}
			};
		}
		public static IEnumerable<ApiResource> GetApiResources()
		{

			return new List<ApiResource>() {
			 new ApiResource("BlankOfDotNetAPI","Api for Customer") };
			
			
		}

		public static IEnumerable<Client> GetClientData()
		{

			return new List<Client>() {

			new Client(){

				ClientId="client",
				AllowedGrantTypes=GrantTypes.ClientCredentials,
				ClientSecrets={
				 new Secret("secret".Sha256())
				},
				AllowedScopes={ "IdentityServer5" }
			},
			new Client(){

				ClientId="ro.client",
				AllowedGrantTypes=GrantTypes.Code,
				ClientSecrets={
				 new Secret("secret".Sha256())
				},
				AllowedScopes={ "BlankOfDotNetAPI" }
			},
			//new Client(){
			// ClientId="mvc",
			// ClientName="mvc",
			// //IdentityProviderRestrictions={"refah"},

			// ClientSecrets={
			//	 new Secret("mvc".Sha256())
			//	},

			// AllowedGrantTypes=GrantTypes.Code,
			// RedirectUris={"http://localhost:5003/signin-oidc" },
			// PostLogoutRedirectUris={ "http://localhost:5003/signout-callback-oidc" },
			// AllowedScopes=new List<string>{
			// "mvc",
			//  IdentityServerConstants.StandardScopes.OpenId,
			//  IdentityServerConstants.StandardScopes.Profile,
			  
			// },RequireConsent=false,
			 

			//}

			new Client
		{
			ClientId = "mvc",
			ClientSecrets = { new Secret("secret".Sha256()) },

			AllowedGrantTypes = GrantTypes.Code,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:44309/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:44309/signout-callback-oidc" },

			AllowedScopes = new List<string>
			{
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile
			},
			RequireConsent=false,
			BackChannelLogoutSessionRequired=false,
			FrontChannelLogoutSessionRequired=false,
			
		}
			};
		}

		public static ICollection<ApiScope> GetScopData()
		{

			return new List<ApiScope>() {

			new ApiScope(){

				Name="IdentityServer5"
			},

			};
		}

	}
}
