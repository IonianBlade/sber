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
						return RedirectToAction("Tickets", "Home");
					}					
				}
				// password is incorrect
				TempData["Error"] = "Wrong creditals. please try again";
				return View(loginViewModel);
			}
			// user not found
			TempData["Error"] = "Wrong credentionals";
			return View(loginViewModel);
		}
	}
}
