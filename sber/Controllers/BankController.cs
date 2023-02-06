using Microsoft.AspNetCore.Mvc;

namespace sber.Controllers
{
	public class BankController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
