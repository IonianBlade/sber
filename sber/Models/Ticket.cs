using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sber.Models
{
	public class Ticket
	{
		[Key]
		public int TicketId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public string Priority { get; set; }
		public DateTime PublishingDate { get; set; }

		[ForeignKey("Employee")]
		public Employee? Emloyee { get; set; }
	}
}
