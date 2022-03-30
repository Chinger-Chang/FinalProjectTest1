using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class Room
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Camping_Area")]
		public int Camping_AreaId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int Count { get; set; }

		[Required]
		[MaxLength]
		public string Description { get; set; }

		[Required]
		public RoomType RoomType { get; set; }

		[Required]
		[Column(TypeName ="decimal(18,2)")]
		public decimal Price_Of_Weekdays { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price_Of_Weekends { get; set; }

		public virtual ICollection<OrderDetail> OrderDetails { get; set; }

		public virtual ICollection<Room_Picture> Room_Pictures { get; set; } 
			= new List<Room_Picture>();

		public virtual Camping_Area Camping_Area { get; set; }
	}
}
