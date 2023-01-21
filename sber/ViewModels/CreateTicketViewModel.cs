using sber.Data.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sber.ViewModels
{
	public class CreateTicketViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Введите наименование")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Введите описание")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Введите дату публикации")]
		public DateTime? PublishingDate { get; set; }

		[Required(ErrorMessage = "Введите плановую дату")]

		public DateTime? PlannedDate  { get; set; }
		public DateTime? SolvedDate { get; set; }

		[Required(ErrorMessage = "Введите адрес")]
		public string Address { get; set; }
		public string EmployeeId { get; set; }
	

		[Required(ErrorMessage = "Выберите статус")]
		public TicketStatus Status { get; set; }

		[Required(ErrorMessage = "Выберите приоритет")]
		public TicketPriority Priority { get; set; }

	}
}
