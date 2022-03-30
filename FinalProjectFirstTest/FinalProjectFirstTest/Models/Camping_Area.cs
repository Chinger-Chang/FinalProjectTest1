using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class Camping_Area
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Seller")]
		public int SellerId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Phone]
		public string Phone { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		public Region Region { get; set; }

		[Required]
		[MaxLength]
		public string Description { get; set; }

		[Required]
		public bool IsAudit  { get; set; }

		[MaxLength]
		#nullable enable
		public string? AuditDescription { get; set; }
		#nullable disable

		[Required]
		public DateTime UpdateTime { get; set; }

		public virtual Seller Seller { get; set; }

		public virtual ICollection<Camping_Area_Picture> Camping_Area_Pictures { get; set; }
			= new List<Camping_Area_Picture>();
		public virtual ICollection<Room> Rooms { get; set; }

		public virtual ICollection<Service> Services { get; set; }
	}
}
