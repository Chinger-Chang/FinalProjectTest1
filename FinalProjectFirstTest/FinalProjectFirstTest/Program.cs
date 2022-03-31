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
		//Entry Point (���ε{���i�J�I) Or Main Program(�D�{��)
		public static void Main(string[] args)
		{
			//static method �u��I�sstatic ����(�@��)
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					// �����t�Φ��A��������t�αҰ�...�������A���n�Ψ��ǥ\�� ???
					 //�ϥΤ�k�M�Ϊx��Generic(����)���w�A��(Serivce)���J
					 //�P�����n��(Middleware)�ҥ�
					 webBuilder.UseStartup<Startup>();
				});
	}
}
