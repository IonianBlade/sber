using CloudinaryDotNet.Actions;
using sber.Interfaces;
using sber.ViewModels;
using System.Linq.Expressions;

namespace sber.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IDashboardRepository _dashboardRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IPhotoService _photoService;

		public DashboardController(IDashboardRepository dashboardRepository, IHttpContextAccessor httpContextAccessor, IPhotoService photoService)
		{
			_dashboardRepository = dashboardRepository;
			_httpContextAccessor = httpContextAccessor;
			_photoService = photoService;
		}

		private void MapUserEdit(Employee user, EditUserDashboardViewModel editUserDashboardViewModel, ImageUploadResult imageUploadResult)
		{
			user.Id = editUserDashboardViewModel.Id;
			user.Name = editUserDashboardViewModel.Name;
			user.Surname = editUserDashboardViewModel.Surname;
			user.Patronymic = editUserDashboardViewModel.Patronymic;
			user.ProfileImageUrl= imageUploadResult.Url.ToString();

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

		public async Task<IActionResult> EditUserProfile()
		{
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			var user = await _dashboardRepository.GetUserById(curUserId);
			if (user == null) return View("Error");
			var editUserViewModel = new EditUserDashboardViewModel()
			{
				Id = curUserId,
				Name = user.Name,
				Surname = user.Surname,
				Patronymic = user.Patronymic,
				ProfileImageUrl = user.ProfileImageUrl

			};
			return View(editUserViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editUserDashboardViewModel)
		{
			if(!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Не удалось отредактировать профиль");
				return View("EditUserProfile", editUserDashboardViewModel);
			}
			Employee user = await _dashboardRepository.GetUserByIdNoTracking(editUserDashboardViewModel.Id);

			if(user.ProfileImageUrl == "" || user.ProfileImageUrl == null)
			{
				var photoResult = await _photoService.AddPhotoAsync(editUserDashboardViewModel.Image);

				MapUserEdit(user,editUserDashboardViewModel, photoResult);
				_dashboardRepository.Update(user);
				return RedirectToAction("Index");
			}
			else
			{
				try
				{
					await _photoService.DeletePhotoAsync(user.ProfileImageUrl);
				}
				catch (Exception)
				{

					ModelState.AddModelError("", "Не удалось удалить фото");
					return View(editUserDashboardViewModel);
				}
				var photoResult = await _photoService.AddPhotoAsync(editUserDashboardViewModel.Image);

				MapUserEdit(user, editUserDashboardViewModel, photoResult);
				_dashboardRepository.Update(user);	
				return RedirectToAction("Index");

			}
			
			}
	}
}
