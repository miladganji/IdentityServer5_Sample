using blazorSource.Server.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSignalR.Server.Utilities
{
	public interface IGeneratedToken
	{

		Task<string> Execute(string UserName, string Password);

	}

	public class GeneratedToken : IGeneratedToken
	{
		private readonly IConfiguration configuration;
		private readonly IuserRepopsitoryADO repopsitoryADO;

		//private readonly IuserRepopsitory userRepository;
		//private readonly IuserRepopsitoryADO iuserRepopsitoryADO;

		private string Mytoken { get; set; }
		public GeneratedToken(IConfiguration configuration, IuserRepopsitoryADO repopsitoryADO)
		{
			this.configuration = configuration;
			this.repopsitoryADO = repopsitoryADO;
		}
		public async Task<string> Execute(string UserName, string Password)
		{
			var userr = await repopsitoryADO.GetUser(UserName, Password);
			if (userr.Email != null)
			{

				var claims = new[]
				{
				new Claim(ClaimTypes.Name,UserName),
						new Claim(JwtRegisteredClaimNames.UniqueName,UserName),
						  new Claim("FisrtName",userr.Name),
						  new Claim("LastName",userr.LastName),
			};

				string SecKey = configuration.GetSection("jwt:JwtSecurityKey").Value;
				string JwtIssuer = configuration.GetSection("jwt:JwtIssuer").Value;
				string JwtExpiryInDays = configuration.GetSection("jwt:JwtExpiryInDays").Value;
				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecKey));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
				var expiry = DateTime.Now.AddDays(Convert.ToInt32(JwtExpiryInDays));
				var token = new JwtSecurityToken(
				  JwtIssuer,
				   JwtIssuer,

					claims,
					expires: expiry,
					signingCredentials: creds
				);

				Mytoken = new JwtSecurityTokenHandler().WriteToken(token).ToString();
				return Mytoken;
			}

			return "";
		}
	}
}
