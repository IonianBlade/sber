using System.ComponentModel.DataAnnotations.Schema;

namespace sber.Models
{
	public class Employee : IdentityUser
	{

		public string Name { get; set; }
		public string Surname { get; set; }
		public string? Patronymic { get; set; }
		public virtual ICollection<Ticket> Tickets { get; set; }
		
	}
}
