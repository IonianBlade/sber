using System.ComponentModel.DataAnnotations;

namespace sber.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }


        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Введите электронную почту")]
        public string EmailAddress { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }


    }
}
