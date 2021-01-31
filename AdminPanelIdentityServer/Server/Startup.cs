using AdminPanelIdentityServer.Server.Contract;
using AdminPanelIdentityServer.Server.Repository;
using BlazorSignalR.Server.Services;
using blazorSource.Server.Ado;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace AdminPanelIdentityServer.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<AdoSettings, AdoSettings>();
			services.AddScoped<IClient, ClientRepository>();
			services.AddControllersWithViews();
			services.AddMvc();
			services.AddGrpc();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();


			app.UseRouting();
			app.UseGrpcWeb();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<DataServices>().EnableGrpcWeb();

				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
