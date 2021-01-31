
// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using blankOfDotNet.IdentitySrv;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace IdentityServer
{
	public class Startup
	{

		private void InitializeDatabase(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

				var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
				context.Database.Migrate();
				if (!context.Clients.Any())
				{
					foreach (var client in config.GetClientData())
					{
						var myclient = context.Clients.FirstOrDefault(a => a.ClientId == client.ClientId);
						if (myclient == null)
						{
							context.Clients.Add(client.ToEntity());


						}
					}
					context.SaveChanges();


					if (!context.IdentityResources.Any())
					{
						foreach (var resource in config.GetIdentityResources())
						{
							context.IdentityResources.Add(resource.ToEntity());
						}
						context.SaveChanges();
					}

					if (!context.ApiScopes.Any())
					{
						foreach (var resource in config.GetScopData())
						{
							var myResource = context.ApiScopes.FirstOrDefault(a => a.Name == resource.Name);
							if (myResource == null)
							{
								context.ApiScopes.Add(resource.ToEntity());

							}
						}
						context.SaveChanges();
					}
				}
			}
		}
		public IWebHostEnvironment Environment { get; }

		public Startup(IWebHostEnvironment environment)
		{
			Environment = environment;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// uncomment, if you want to add an MVC-based UI
			services.AddControllersWithViews();
			var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
			const string connectionString = @"Data Source=172.18.71.55;database=DB04;user id=Ganji.M;password=Ganji.M;";

			var builder = services.AddIdentityServer(options =>
			{
				// https://docs.duendesoftware.com/identityserver/v5/fundamentals/resources/
				options.EmitStaticAudienceClaim = true;
			}).AddProfileService<MyProfileService>()

				.AddTestUsers(config.GetUsers())
				.AddConfigurationStore(option =>
				{
					option.ConfigureDbContext = b => b.UseSqlServer(connectionString,
				sql => sql.MigrationsAssembly(migrationsAssembly));

				})
				.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
						sql => sql.MigrationsAssembly(migrationsAssembly));
				});
			//.AddInMemoryIdentityResources(config.GetIdentityResources())
			//.AddInMemoryApiScopes(config.GetScopData())
			//.AddInMemoryClients(config.GetClientData())
			//.AddTestUsers(config.GetUsers()


			//;

		}

		public void Configure(IApplicationBuilder app)
		{
			InitializeDatabase(app);

			if (Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// uncomment if you want to add MVC
			app.UseStaticFiles();
			app.UseCors(option =>
					   option.AllowAnyOrigin()
						   .AllowAnyMethod()
						   .AllowAnyHeader()
						   );

			app.UseRouting();
			app.UseIdentityServer();


			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}