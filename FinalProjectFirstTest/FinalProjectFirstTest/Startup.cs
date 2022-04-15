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
		// �غc�l(Contstructor)�`�J�@�ӲպA���� IConfiguration
		public Startup(IConfiguration configuration)
		{
			//���۰��ݩ� Property(�S����@setter or getter)
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// ConfigureServices �]�m�ի� �Ω� �s�uDb
		public void ConfigureServices(IServiceCollection services)
		{

			// *** Cookie config*/

			//�[�J Cookie(using Microsoft.AspNetCore.Authentication.Cookies;)
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(opt =>
			{  //�n�J���| PathString(using Microsoft.AspNetCore.Http;)
				opt.LoginPath = new PathString("/Index");//���n�J�ɷ|�ɤJ�o����
				opt.AccessDeniedPath = new PathString("/home/AccessDenied"); //����L�{��Cookie
				opt.ExpireTimeSpan = TimeSpan.FromDays(14);  //�n�J���Įɶ��]�m
			})
				//�[�J�ϥ�google�{��
				.AddGoogle(opt=>  
				{
					opt.ClientId = "";
					opt.ClientSecret = "";
				})
				//�[�J �ϥ� FaceBook �{��
				.AddFacebook(opt=> 
				{
					opt.AppId = "";
					opt.AppSecret = "";
				});

		// *** �s�uSQL config*/
			//���X�s���r�� �ާ@�w�q��Property Configuration
			//String connectionString = Configuration.GetConnectionString("FinalProjectTest");
			//�`�J(DI) �A��
			services.AddDbContext<FinalProjectDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("FinalProjectTest"));
            });
			
 

			//�[�J�ۭq��Class�ܦ��@�ӪA�Ȫ���Singleton()�W�@(���Ψt�Τ��u���@�Ӧ@�Ϊ�����)-0216
			services.AddSingleton<Models.DBUtility>();  //Method 1 -
			//�[�JSession���A�A�� (�t�X�s�����i�ӲĤ@�Ӻ��I ��ݷǳƤ@��ISession���󵹧A �P�ɰe�X�e��Cookie(SessionID))
			services.AddSession();

			// �[�J�@��MVC�A��
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
			// �[�J CookiePolicy
			app.UseCookiePolicy();
			// �[�J Authentication
			app.UseAuthentication();
			// �ҥα��v�ѧO
			app.UseAuthorization();
			// Cookie, Authentication, Authoriz �e�ᶶ�Ǥ�����
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
