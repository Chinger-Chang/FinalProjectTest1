using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class FinalProjectDbContext : DbContext
	{
		public FinalProjectDbContext(DbContextOptions<FinalProjectDbContext> options) : base(options)
		{

		}

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
