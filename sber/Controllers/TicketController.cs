using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sber.Data.Enum;
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
		
		public async Task<IActionResult> Index(string searchString)
        {
            if(searchString != null)
            {
				var searchTickets = await _ticketRepository.SearchTicketAsync(searchString);
				return View(searchTickets.ToList());
			}
            else
            {
				List<Ticket?> tickets = await _ticketRepository.GetAllAsync();
				return View(tickets);
			}          		
		}
       
        public async Task<IActionResult> Detail(int id)
        {
            Ticket ticket = await _ticketRepository.GetByIdAsync(id);
            return View(ticket);
        }

        public async Task<IActionResult> Create()
        {
			var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			var curDatePublishingDate = DateTime.Now;
            var defaultStatus = TicketStatus.Открыт;

		    var createTicketViewModel = new CreateTicketViewModel
            {               
                PublishingDate = curDatePublishingDate,
                EmployeeId = curUserId,
                Status = defaultStatus,
            };
            return View(createTicketViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketViewModel ticketVM)
        {
            
            if (ModelState.IsValid)
            {                				
                var ticket = new Ticket
                {
                    Title = ticketVM.Title,
                    Description = ticketVM.Description,                   
                    EmployeeId = ticketVM.EmployeeId,                
                    Status = ticketVM.Status,
                    Priority = ticketVM.Priority,
                    PublishingDate = ticketVM.PublishingDate,
                    PlannedDate = ticketVM.PlannedDate,
                    SolvedDate = ticketVM.SolvedDate,
                   
                };
                _ticketRepository.Add(ticket);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Не удалось загрузить фото");

			}
            return View(ticketVM);      
        }

        public async Task<IActionResult> Edit(int id)
        {
			var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			var defaultStatus = TicketStatus.Выполняется;
			var curSolvedDate = DateTime.Now;
			var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null) return View("Error");
            var ticketVM = new EditTicketViewModel
            {
                Title = ticket.Title,
                Description = ticket.Description,
                Status = defaultStatus,
                Priority = ticket.Priority,
                PublishingDate = ticket.PublishingDate,
				EmployeeId = ticket.EmployeeId,
				Employee = ticket.Employee,
				PerformerId = curUserId,
				Performer = ticket.Performer,
                PlannedDate = ticket.PlannedDate,
                SolvedDate = curSolvedDate,
                URL = ticket.Image,
                        
            };
			return View(ticketVM);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditTicketViewModel ticketVM)
        {
            if (ModelState.IsValid)
            {
				var userTicket = await _ticketRepository.GetByIdAsyncNoTracking(id);
				if (userTicket != null)
				{
					
					var photoResult = await _photoService.AddPhotoAsync(ticketVM.Image);

					var ticket = new Ticket
					{
						Id = id,
						Title = ticketVM.Title,
						Description = ticketVM.Description,
                        Priority= ticketVM.Priority,
                        Status = ticketVM.Status,
						EmployeeId = ticketVM.EmployeeId,					
						PerformerId = ticketVM.PerformerId,
                        PublishingDate= ticketVM.PublishingDate,
						Image = photoResult.Url.ToString(),
                        PlannedDate = ticketVM.PlannedDate,
                        SolvedDate = ticketVM.SolvedDate,
		
					};
					_ticketRepository.Update(ticket);
					return RedirectToAction("Index");
				}
                else
                {
                    return View(ticketVM);
                }
            }
			return View(ticketVM);

		}
        public async Task<IActionResult> Delete(int id)
        {
            var ticketDetails = await _ticketRepository.GetByIdAsync(id);
            if (ticketDetails == null) return View("Error");
            return View(ticketDetails);
        }

        [HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteTicket(int id)
		{
			var ticketDetails = await _ticketRepository.GetByIdAsync(id);
			if (ticketDetails == null) return View("Error");
	        _ticketRepository.Delete(ticketDetails);
            return RedirectToAction("Index");
		}           
	}
}
