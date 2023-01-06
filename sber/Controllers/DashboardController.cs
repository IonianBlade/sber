using Microsoft.AspNetCore.Mvc;
using sber.Interfaces;
using sber.ViewModels;

namespace sber.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IDashboardRepository _dashboardRepository;

		public DashboardController(IDashboardRepository dashboardRepository)
		{
			_dashboardRepository = dashboardRepository;
		}
		public async Task<IActionResult> Index()
		{
			var userTickets = await _dashboardRepository.GetAllUserTickets();
			var dashboardViewModel = new DashboardViewModel()
			{
				Tickets = userTickets,
			};
			return View(dashboardViewModel);
		}
	}
}
