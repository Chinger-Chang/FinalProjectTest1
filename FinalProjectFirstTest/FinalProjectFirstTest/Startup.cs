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

			// *** Cookie config*/

			//加入 Cookie(using Microsoft.AspNetCore.Authentication.Cookies;)
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(opt =>
			{  //登入路徑 PathString(using Microsoft.AspNetCore.Http;)
				opt.LoginPath = new PathString("/Index");//未登入時會導入這頁面
				opt.AccessDeniedPath = new PathString("/home/AccessDenied"); //限制無認證Cookie
				opt.ExpireTimeSpan = TimeSpan.FromDays(14);  //登入有效時間設置
			})
				//加入使用google認證
				.AddGoogle(opt=>  
				{
					opt.ClientId = "";
					opt.ClientSecret = "";
				})
				//加入 使用 FaceBook 認證
				.AddFacebook(opt=> 
				{
					opt.AppId = "";
					opt.AppSecret = "";
				});

		// *** 連線SQL config*/
			//取出連接字串 操作定義的Property Configuration
			//String connectionString = Configuration.GetConnectionString("FinalProjectTest");
			//注入(DI) 服務
			services.AddDbContext<FinalProjectDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("FinalProjectTest"));
            });
			
 

			//加入自訂的Class變成一個服務物件Singleton()獨一(應用系統中只有一個共用的物件)-0216
			services.AddSingleton<Models.DBUtility>();  //Method 1 -
			//加入Session狀態服務 (配合瀏覽器進來第一個端點 後端準備一個ISession物件給你 同時送出前端Cookie(SessionID))
			services.AddSession();

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
			// 加入 CookiePolicy
			app.UseCookiePolicy();
			// 加入 Authentication
			app.UseAuthentication();
			// 啟用授權識別
			app.UseAuthorization();
			// Cookie, Authentication, Authoriz 前後順序不能對調
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
