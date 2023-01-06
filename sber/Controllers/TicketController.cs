using Microsoft.AspNetCore.Mvc;
using sber.Interfaces;
using sber.ViewModels;

namespace sber.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
		private readonly IPhotoService _photoService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public TicketController(ITicketRepository ticketRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {       
            _ticketRepository = ticketRepository;
			_photoService = photoService;
			_httpContextAccessor = httpContextAccessor;
		}

        public async Task<IActionResult> Index()
        {
            List<Ticket?> tickets = await _ticketRepository.GetAllAsync();
            return View(tickets);
        }

       
        public async Task<IActionResult> Detail(int id)
        {
            Ticket ticket = await _ticketRepository.GetByIdAsync(id);
            return View(ticket);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createTicketViewModel = new CreateTicketViewModel
            {
                EmployeeId = curUserId,
            };
            return View(createTicketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketViewModel ticketVM)
        {
            if (!ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(ticketVM.Image);

                var ticket = new Ticket
                {
                    Title = ticketVM.Title,
                    Description = ticketVM.Description,
                    Image = result.Url.ToString(),
                    EmployeeId = ticketVM.EmployeeId,
                    Status = ticketVM.Status,
                    Priority = ticketVM.Priority,
                    PublishingDate = ticketVM.PublishingDate,
                    Address = new Address
                    {
                        Name = ticketVM.Address.Name,
                    }
                };
                _ticketRepository.Add(ticket);
                return RedirectToAction("Index");
            }
            //else
            //{
            //    ModelState.AddModelError("", "Photo upload failed");
            //}
           return View(ticketVM);
      
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null) return View("Error");
            var ticketVM = new EditTicketViewModel
            {
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status,
                Priority = ticket.Priority,
                PublishingDate = ticket.PublishingDate,
                URL = ticket.Image,
                Address = ticket.Address,
                AdressId = ticket.AdressId,

            };
			return View(ticketVM);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTicketViewModel ticketVM)
        {
            if (!ModelState.IsValid)
            {
				//ModelState.AddModelError("", "Failed to edit ticket");
				//return View("Edit");
				var userTicket = await _ticketRepository.GetByIdAsyncNoTracking(id);
				if (userTicket != null)
				{
					try
					{
						await _photoService.DeletePhotoAsync(userTicket.Image);
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("", "Could not delete photo");
						return View(ticketVM);
					}
					var photoResult = await _photoService.AddPhotoAsync(ticketVM.Image);

					var ticket = new Ticket
					{
						Id = id,
						Title = ticketVM.Title,
						Description = ticketVM.Description,
						Image = photoResult.Url.ToString(),
						AdressId = ticketVM.AdressId,
						Address = ticketVM.Address,
					};
					_ticketRepository.Update(ticket);
					return RedirectToAction("Index");
				}
				//else
				//{
				//	return View(ticketVM);
				//}
			}
			return View(ticketVM);

		}
    }
}
