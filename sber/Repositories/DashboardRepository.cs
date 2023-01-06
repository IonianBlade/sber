using sber.Interfaces;

namespace sber.Repositories
{
	public class DashboardRepository : IDashboardRepository
	{
		private readonly DataContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public DashboardRepository(DataContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<List<Ticket>> GetAllUserTickets()
		{
			var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
			var userClubs =  _context.Tickets.Where(t => t.Employee.Id == curUser);
			return userClubs.ToList();
		}
	}
}
