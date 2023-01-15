using sber.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sber.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Title { get; set; }

		[Column(TypeName = "NVARCHAR")]
		[StringLength(200)]
		public string Description { get; set; }
        public string? Image { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }
		public DateTime PublishingDate { get; set; }
		public DateTime PlannedDate { get; set; }
		public DateTime? SolvedDate { get; set; }
        public string? EmployeeId { get; set; }
		public Employee? Employee { get; set; }
        public string? PerformerId { get; set; }
		public Employee? Performer { get; set; }

		[Column(TypeName = "NVARCHAR")]
		[StringLength(100)]
		public string Address { get; set; }
	}
}
