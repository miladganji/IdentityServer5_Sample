using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Test;
using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace blankOfDotNet.IdentitySrv
{
	//public class ProfileService : IProfileService
	//{
	//	public async Task GetProfileDataAsync(ProfileDataRequestContext context)
	//	{
	//		var Claims = new List<Claim>();

	//		foreach (var item in config.GetUsers())
	//		{
	//			var Claims2 = new List<Claim> {

	//			 new Claim(ClaimTypes.Role,item.Claims.FirstOrDefault(a=>a.Type=="role").Value),
	//			 new Claim("NationalCode","3920395905")
	//			};
	//			Claims = Claims2;
	//		}

	//		context.IssuedClaims.AddRange(Claims);
	//	}

	//	public async Task IsActiveAsync(IsActiveContext context)
	//	{
	//		context.IsActive = true;
	//	}
	//}



	public class MyProfileService : IProfileService
	{
		public Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			var claims = new List<Claim>();
			claims.Add(new Claim(JwtClaimTypes.WebSite, "https://leastprivilege.com"));
			claims.Add(new Claim("FullName", "Joe Tester"));
			claims.Add(new Claim("CustomClaim2", "SomeValue"));
			context.IssuedClaims = claims;
			return Task.FromResult(0);
		}
		public Task IsActiveAsync(IsActiveContext context)
		{
			context.IsActive = true;
			return Task.FromResult(0);
		}
	}
	public class config
	{
		public class ProfileWithRoleIdentityResource: IdentityResources.Profile
		{
			public ProfileWithRoleIdentityResource()
			{
				this.UserClaims.Add(JwtClaimTypes.Role);
			}
		}

		public static IEnumerable<IdentityResource> GetIdentityResources()
		{

			return new List<IdentityResource>{

				 new IdentityResources.OpenId(),
				 new ProfileWithRoleIdentityResource(),
				 new IdentityResources.Email(),
				 
				 
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
						new Claim("given_name","fff"),
						new Claim("name","milad ganji"),
						new Claim(JwtClaimTypes.Role,"miladAdmin"),
						new Claim("email","miladganjinezhad@gmail.com"),


					},
					
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
			AllowedGrantTypes = GrantTypes.Hybrid,
            
            // where to redirect to after login
            RedirectUris = { "https://localhost:44309/signin-oidc" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:44309/signout-callback-oidc" },

			AllowedScopes = new List<string>
			{
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile,
				IdentityServerConstants.StandardScopes.Email,
				
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
            RedirectUris = { "https://localhost:5007/authentication/login-callback" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:5007/authentication/logout-callback" },
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
            RedirectUris = { "https://localhost:5007/authentication/login-callback" },

            // where to redirect to after logout
            PostLogoutRedirectUris = { "https://localhost:5007/authentication/logout-callback" },
			AllowedCorsOrigins={ "http://localhost:5007"},
			RequirePkce = true,
			RequireClientSecret = false,

			AllowedScopes = new List<string>
			{
				IdentityServerConstants.StandardScopes.OpenId,
				IdentityServerConstants.StandardScopes.Profile,
				IdentityServerConstants.StandardScopes.Email,

				"blazorWASM2","mvc"
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

			},
			new ApiScope(){

				Name="mvc"



			},

			new ApiScope(){

				Name="role"



			}



			};
			

	}
	}
}
