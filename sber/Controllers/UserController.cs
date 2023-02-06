using Microsoft.AspNetCore.Mvc;
using sber.Interfaces;
using sber.Repositories;
using sber.ViewModels;

namespace sber.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly UserManager<Employee> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserController(IUserRepository userRepository, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userRepository = userRepository;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		[HttpGet("Users")]
		public async Task <IActionResult> Index()
		{
			var users = await _userRepository.GetAllEmployeesAsync();
			List<UserViewModel> result = new List<UserViewModel>();
			
			foreach(var user in users)
			{
				var userViewModel = new UserViewModel()
				{
					Id = user.Id,
					Name = user.Name,
					Surname = user.Surname,
					Patronymic = user.Patronymic,
					ProfileImageUrl = user.ProfileImageUrl,
					Roles = await _userRepository.GetUserRoleAsync(user),
				};
				result.Add(userViewModel);
			}
			return View(result);
		}

		public async Task<IActionResult> Detail(string id)
		{
			var user = await _userRepository.GetUserByIdAsync(id);
			var employeeTickets = await _userRepository.GetAllEmployeeTickets(id);
			var performerTickets = await _userRepository.GetAllPerformerTickets(id);

			var userDetailViewModel = new UserDetailViewModel()
			{
				Id = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				Patronymic = user.Patronymic,
				EmployeeTickets = employeeTickets,
				PerformerTickets = performerTickets, 
				
			
			};
			return View(userDetailViewModel);
		}

		public async Task<IActionResult> Delete(string id)
		{
			var employeeDetails = await _userRepository.GetUserByIdAsync(id);
			if (employeeDetails == null) return View("Error");
			return View(employeeDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			var employeeDetails = await _userRepository.GetUserByIdAsync(id);
			if (employeeDetails == null) return View("Error");
			_userRepository.Delete(employeeDetails);
			return RedirectToAction("Index");
		}
	}
}
