using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest
{
	public class Program
	{
		//Entry Point (應用程式進入點) Or Main Program(主程式)
		public static void Main(string[] args)
		{
			//static method 只能呼叫static 成員(共用)
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					// 網站系統伺服器跟網站系統啟動...網站伺服器要用那些功能 ???
					 //使用方法套用泛型Generic(插件)指定服務(Serivce)載入
					 //與中介軟體(Middleware)啟用
					 webBuilder.UseStartup<Startup>();
				});
	}
}
