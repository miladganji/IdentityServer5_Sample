using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace blankOfDotNet.IdentitySrv
{
	public class config
	{

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{

			return new List<IdentityResource>{
			
				 new IdentityResources.OpenId(),
				 new IdentityResources.Profile(),
				 new IdentityResources.Email()
			};
		}

		public static List<TestUser> GetUsers()
		{

			return new List<TestUser>() {

				new TestUser(){

					SubjectId="1",
					Username="milad",
					Password="password",
					Claims=new List<Claim>(){ 
					 
						new Claim(ClaimTypes.Name,"mgn"),
						new Claim(ClaimTypes.Email,"mgn@mgn.com"),
						new Claim(ClaimTypes.Role,"miladAdmin"),

					}
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
			
			ClientName="mvc client",
			AllowedGrantTypes = GrantTypes.Code,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:44309/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:44309/signout-callback-oidc" },

			AllowedScopes = new List<string>
			{
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile,
				IdentityServerConstants.StandardScopes.Email
			},
			RequireConsent=false,
			BackChannelLogoutSessionRequired=false,
			FrontChannelLogoutSessionRequired=false,
			
		},



			new Client
		{
			ClientId = "blazorWASM",
			ClientSecrets = { new Secret("blazorWASM".Sha256()) },

			AllowedGrantTypes = GrantTypes.Code,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:5005/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "http://localhost:5005/signout-callback-oidc" },
			AllowedCorsOrigins={ "http://localhost:5005"},
			RequirePkce = true,
			RequireClientSecret = false,
			AllowedScopes = new List<string>
			{
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile,
				//"blazorWASM"
			},
			RequireConsent=false,
			BackChannelLogoutSessionRequired=false,
			FrontChannelLogoutSessionRequired=false,

		},

			new Client
		{
			ClientId = "blazorWASM2",
			ClientSecrets = { new Secret("blazorWASM2".Sha256()) },
			ClientName="wasm2",
			AllowedGrantTypes = GrantTypes.Code,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:5007/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "http://localhost:5007/signout-callback-oidc" },
			AllowedCorsOrigins={ "http://localhost:5007"},
			RequirePkce = true,
			RequireClientSecret = false,
			
			AllowedScopes = new List<string>
			{
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile,
				"blazorWASM2"
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

			new ApiScope(){

				Name="blazorWASM"

			},
			new ApiScope(){

				Name="blazorWASM2"

			}

			};


		}

	}
}
