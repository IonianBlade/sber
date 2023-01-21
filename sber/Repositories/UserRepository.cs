using sber.Interfaces;
using sber.Models;

namespace sber.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;
		

		public UserRepository(DataContext context)
		{
			_context = context;
			
		}
		public bool Add(Employee employee)
		{
			_context.Add(employee);
			return Save();
		}

		public bool Delete(Employee employee)
		{
			_context.Remove(employee);
			return Save();
		}

		public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<List<Ticket>> GetAllEmployeeTickets(string id)
		{
			return await _context.Tickets.Where(t => t.EmployeeId.Contains(id)).ToListAsync();
		}

		public async Task<List<Ticket>> GetAllPerformerTickets(string id)
		{
			return await _context.Tickets.Where(t => t.PerformerId.Contains(id)).ToListAsync();
		}

		public async Task<Employee> GetUserByIdAsync(string id)
		{
			return await _context.Users.FindAsync(id);
		}
	
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		} 

		public bool Update(Employee employee)
		{
			_context.Update(employee);
			return Save();
		}
	}
}
