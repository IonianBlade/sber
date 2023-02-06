using Microsoft.AspNetCore.Identity;
using sber.Interfaces;
using sber.Models;

namespace sber.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;
		private readonly UserManager<Employee> _userManager;

		public UserRepository(DataContext context, UserManager<Employee> userManager)
		{
			_context = context;
			_userManager = userManager;
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

		public async Task<List<string>> GetUserRoleAsync(Employee employee)
		{
			return new List<string>(await _userManager.GetRolesAsync(employee));
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
