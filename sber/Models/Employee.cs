namespace sber.Models
{
	public class Employee : IdentityUser
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
		public string? Patronymic { get; set; } = string.Empty;

	}
}
