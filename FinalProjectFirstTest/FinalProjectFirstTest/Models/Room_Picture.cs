using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class Room_Picture
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Room")]
		public int RoomId { get; set; }

		[Required]
		public string Path { get; set; }

		[Required]
		public DateTime UpdateTime { get; set; }

		public virtual Room Room { get; set; }
	}
}
