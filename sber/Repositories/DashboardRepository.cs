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

		public async Task<Employee> GetUserById(string id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<Employee> GetUserByIdNoTracking(string id)
		{
			return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Employee user)
		{
			_context.Users.Update(user);
			return Save();
		}
	}
}
