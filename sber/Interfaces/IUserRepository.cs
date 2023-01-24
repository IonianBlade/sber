using System.Threading.Tasks;

namespace sber.Interfaces
{
	public interface IUserRepository
	{
		Task<IEnumerable<Employee>> GetAllEmployeesAsync();
		Task <Employee> GetUserByIdAsync(string id);
		Task<List<Ticket>> GetAllEmployeeTickets(string id);
		Task<List<Ticket>> GetAllPerformerTickets(string id);
		Task<Employee> GetUserRoleAsync(string id);
		bool Add(Employee employee);
		bool Update(Employee employee);
		bool Delete(Employee employee);
		bool Save();
	}
}
