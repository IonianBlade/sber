using System.ComponentModel.DataAnnotations;

namespace sber.ViewModels
{
	public class LoginViewModel
	{
		[Display(Name = "Электронная почта")]
		[Required(ErrorMessage = "Введите электронную почту")]
		public string EmailAddress { get; set; }

        [Display(Name = "Пароль")]
        [Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
