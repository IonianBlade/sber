using Microsoft.AspNetCore.Mvc;
using sber.Interfaces;

namespace sber.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {       
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Ticket> tickets = await _ticketRepository.GetAllAsync();
            return View(tickets);
        }

       
        public async Task<IActionResult> Detail(int id)
        {
            Ticket ticket = await _ticketRepository.GetByIdAsync(id);
            return View(ticket);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
   //         if(!ModelState.IsValid)
   //         {
			//	return View(ticket);
			//}
            _ticketRepository.Add(ticket);
            return RedirectToAction("Index");
        }
    }
}
