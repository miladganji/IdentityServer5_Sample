using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminPanelIdentityServer.Shared.Dtos
{
	public class ClientDto
	{
		[Required(ErrorMessage ="clientId را وارد نمایید")]
		public string ClientId { get; set; }
		[Required(ErrorMessage = "ClientSecrets را وارد نمایید")]

		public string ClientSecrets { get; set; }
		[Required(ErrorMessage = "ClientName را وارد نمایید")]

		public string ClientName { get; set; }
		[Required(ErrorMessage = "RedirectUris را وارد نمایید")]

		public string RedirectUris { get; set; }

		[Required(ErrorMessage = "PostLogoutRedirectUris را وارد نمایید")]

		public string PostLogoutRedirectUris { get; set; }

		[Required(ErrorMessage = "AllowedCorsOrigins را وارد نمایید")]

		public string AllowedCorsOrigins { get; set; }
		



	}
}
