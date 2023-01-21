namespace sber.ViewModels
{
	public class EditUserDashboardViewModel
	{
		public string Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Patronymic { get; set; }
		public string? ProfileImageUrl { get; set; }
		public IFormFile? Image { get; set; }

	}
}
