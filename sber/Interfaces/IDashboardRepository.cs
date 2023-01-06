namespace sber.Interfaces
{
	public interface IDashboardRepository
	{
		Task<List<Ticket>> GetAllUserTickets();
		
	}
}
