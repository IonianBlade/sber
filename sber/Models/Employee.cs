using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace sber.Models
{
	public class Employee : IdentityUser
	{
		public Employee()
		{
			TicketEmployees = new HashSet<Ticket>();
			TicketPerformers = new HashSet<Ticket>();
		}
		
		public string Name { get; set; }
		public string? ProfileImageUrl { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }
		public virtual ICollection<Ticket> TicketEmployees { get; set; }
		public virtual ICollection<Ticket> TicketPerformers { get; set; }
		
	}
}
