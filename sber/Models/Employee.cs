using System.ComponentModel.DataAnnotations.Schema;

namespace sber.Models
{
	public class Employee : IdentityUser
	{
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string? Patronymic { get; set; } = string.Empty;

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
		

	}
}
