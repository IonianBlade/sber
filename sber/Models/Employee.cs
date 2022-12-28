using System.ComponentModel.DataAnnotations.Schema;

namespace sber.Models
{
	public class Employee : IdentityUser
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string? Patronymic { get; set; } = string.Empty;
        public ICollection<Ticket> Ticket { get; set; }
    }
}
