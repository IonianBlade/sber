using sber.Data.Enum;

namespace sber.ViewModels
{
	public class EditTicketViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PublishingDate { get; set; }
		public DateTime PlannedDate { get; set; }
		public DateTime? SolvedDate { get; set; }
		public string? EmployeeId { get; set; }
		public Employee Employee { get; set; }
		public int? AdressId { get; set; }
		public Address Address { get; set; }
		public IFormFile Image { get; set; }
		public string? URL { get; set; }
		public TicketStatus Status { get; set; }
		public TicketPriority Priority { get; set; }
	}
}
