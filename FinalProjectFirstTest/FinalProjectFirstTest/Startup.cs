using FinalProjectFirstTest.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest
{
	public class Startup
	{
		// 建構子(Contstructor)注入一個組態物件 IConfiguration
		public Startup(IConfiguration configuration)
		{
			//給自動屬性 Property(沒有實作setter or getter)
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// ConfigureServices 設置組建 用於 連線Db
		public void ConfigureServices(IServiceCollection services)
		{
			
			////注入(DI) 服務
			//services.AddDbContext<FinalProjectDbContext>(opt => {
			//	opt.UseSqlServer(Configuration.GetConnectionString("FinalProjectTest"));
			//});
			////加入 Cookie  (using Microsoft.AspNetCore.Authentication.Cookies;)
			//services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
			//{  //登入路徑 PathString(using Microsoft.AspNetCore.Http;)
			//	opt.LoginPath = new PathString("/Index");
			//	opt.AccessDeniedPath = new PathString("/home/AccessDenied");
			//}) ;

			// 加入一個MVC服務
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// 加入 Authorization
			//app.UseAuthorization();


			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
