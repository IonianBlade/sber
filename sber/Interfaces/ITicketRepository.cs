namespace sber.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket?>> GetAllAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<Ticket> GetByIdAsyncNoTracking(int id);
        bool Add(Ticket ticket);
        bool Update(Ticket ticket);
        bool Delete(Ticket ticket);
        bool Save();
    }
}
