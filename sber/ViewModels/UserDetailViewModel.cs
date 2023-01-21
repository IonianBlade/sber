namespace sber.ViewModels
{
	public class UserDetailViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string Role { get; set; }
		public string ProfileImageUrl { get; set; }
		public ICollection<Ticket> EmployeeTickets { get; set; }
		public ICollection<Ticket> PerformerTickets { get; set; }
	}
}
