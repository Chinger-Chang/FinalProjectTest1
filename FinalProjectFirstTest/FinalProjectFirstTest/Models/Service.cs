using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class Service
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[ForeignKey("Camping_Area")]
		public int Camping_AreaId { get; set; }

		[Required]
		public string ServiceName { get; set; }

		[Required]
		public bool IsHas { get; set; }

		public virtual Camping_Area Camping_Area { get; set; }
	}
}
