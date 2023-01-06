﻿using sber.Data.Enum;

namespace sber.ViewModels
{
	public class CreateTicketViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PublishingDate { get; set; }
		public Address Address { get; set; }
		public string EmployeeId { get; set; }
		public IFormFile Image { get; set; }
		public TicketStatus Status { get; set; }
		public TicketPriority Priority { get; set; }

	}
}