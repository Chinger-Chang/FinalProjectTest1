using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class OrderDetail
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		[ForeignKey("Room")]
		public int RoomId { get; set; }

		[Required]
		public DateTime CreateDate { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		public DateTime? CancelDate { get;set; }

		[Required]
		public Status Status { get; set; }

		public DateTime? RefundDate { get; set; }

		public virtual User User { get; set; }

		public virtual Room Room { get; set; }
	}
}
