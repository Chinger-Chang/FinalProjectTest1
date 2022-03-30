using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectFirstTest.Models
{
	public class Seller
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Phone]
		public string Phone { get; set; }

		[Required]
		public DateTime CreateDate { get; set; }

		[Required]
		public bool IsMailConfirm { get; set; }

		public virtual ICollection<Camping_Area> Camping_Areas { get; set; }
	}
}
