﻿using sber.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sber.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
		public DateTime PublishingDate { get; set; }
		[ForeignKey("Employee")]
        public string EmployeeId { get; set; }
		//[ForeignKey("Employee")]
		//public string ExecutorId { get; set; }
        [ForeignKey("Address")]
        public int AdressId { get; set; }
        public Address Address { get; set; }
		public Employee Employee { get; set; }
	}
}
