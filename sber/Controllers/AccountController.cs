using Microsoft.AspNetCore.Mvc;
using sber.ViewModels;

namespace sber.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<Employee> _userManager;
		private readonly SignInManager<Employee> _signInManager;
		private readonly DataContext _context;

		public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, DataContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}

		public IActionResult Login()
		{
			var response = new LoginViewModel();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if(!ModelState.IsValid) return View(loginViewModel);

			var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

			if (user != null)
			{
				// user is found, check is password
				var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
				if (passwordCheck)
				{
					// password correct
					var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index", "Ticket");
					}					
				}
				// password is incorrect
				TempData["Error"] = "Неверные данные. Попробуйте еще раз";
				return View(loginViewModel);
			}
			// user not found
			TempData["Error"] = "Неверные данные";
			return View(loginViewModel);
		}

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid) return View(registerViewModel);
			var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);

			if (user != null)
			{
				TempData["Error"] = "Этот адрес электронной почты уже используется";
				return View(registerViewModel);
			}

			var newUser = new Employee()
			{
				Name = registerViewModel.Name,
				Surname = registerViewModel.Surname,
				Patronymic = registerViewModel.Patronymic,
				Email = registerViewModel.EmailAddress,
				UserName = registerViewModel.EmailAddress
			};

			var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

			if (newUserResponse.Succeeded)
			{
				await _userManager.AddToRoleAsync(newUser, EmployeeRoles.Client);
			}
			return RedirectToAction("Index", "Ticket");
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Ticket");
		}
    }
}
