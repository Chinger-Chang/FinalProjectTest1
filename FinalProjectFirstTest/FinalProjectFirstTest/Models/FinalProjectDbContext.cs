using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//規劃一個Persistence持久層框架(mapping 實體資料庫)
namespace FinalProjectFirstTest.Models
{
	public class FinalProjectDbContext : DbContext
	{
		public FinalProjectDbContext()
		{
			Console.WriteLine("DbContext物件產生...!"); //確認物件是否共用?
		}

		//自訂建構子 注入 DbContext Option(選項)
		public FinalProjectDbContext(DbContextOptions<FinalProjectDbContext> options) : base(options)
		{

		}
		//定義自動屬性Property
		public DbSet<User> Users { get; set; }

		public DbSet<Service> Services { get; set; }

		public DbSet<Seller>Sellers { get; set; }

		public DbSet<Room_Picture> Room_Pictures { get; set; }

		public DbSet<Room> Rooms { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }

		public DbSet<Camping_Area> Camping_Areas { get; set; }

		public DbSet<Camping_Area_Picture> Camping_Area_Pictures { get; set; }
	}
}
