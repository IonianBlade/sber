namespace sber.Models
{
	public class Ticket
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Status { get; set; }
		public string Priority { get; set; }
		public DateTime PublishingDate { get; set; }
		public Employee Emloyee { get; set; }
		public int EmployeeId { get; set; }
	}
}
