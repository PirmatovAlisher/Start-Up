using NLog.Web;
using NToastNotify;
using RepositoryLayer.Extensions;
using ServiceLayer.Extensions;
using ServiceLayer.MiddleWares.Identity;

namespace StartUp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions
			{
				ProgressBar = false,
				PositionClass = ToastPositions.TopCenter
			});
			builder.Services.LoadRepositoryLayerExtensions(builder.Configuration);
			builder.Services.LoadServiceLayerExtensions(builder.Configuration);


			// NLog: Setup NLog for Dependency injection
			builder.Logging.ClearProviders();
			builder.Host.UseNLog();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseExceptionHandler("/Error/GeneralExceptions");
			//app.UseStatusCodePagesWithRedirects("/Error/PageNotFound");
			app.UseStatusCodePagesWithReExecute("/Error/PageNotFound");

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseMiddleware<SecurityStampCheck>();

#pragma warning disable ASP0014
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
					);

				endpoints.MapAreaControllerRoute(
					name: "User",
					areaName: "User",
					pattern: "User/{controller=Dashboard}/{action=Index}/{id?}"
					);

				endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			app.Run();
		}
	}
}
