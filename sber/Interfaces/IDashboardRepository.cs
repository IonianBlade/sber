namespace sber.Interfaces
{
	public interface IDashboardRepository
	{
		Task<List<Ticket>> GetAllUserTickets();
		Task<Employee> GetUserById(string id);
		Task<Employee> GetUserByIdNoTracking(string id);
		bool Update(Employee employee);
		bool Save();

	}
}
