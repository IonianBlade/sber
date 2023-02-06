using sber.Interfaces;

namespace sber.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _context;

        public TicketRepository(DataContext context)
        {
            _context = context;
        }
        public bool Add(Ticket ticket)
        {
            _context.Add(ticket);
            return Save();
        }

        public bool Delete(Ticket ticket)
        {
            _context.Remove(ticket);
            return Save();
        }

        public async Task<List<Ticket?>> GetAllAsync()
        {
            return await _context.Tickets.Include(p => p.Performer).ToListAsync();            
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.Include(e => e.Employee).Include(p => p.Performer).FirstOrDefaultAsync(i => i.Id == id);
        }
		public async Task<Ticket> GetByIdAsyncNoTracking(int id)
		{
			return await _context.Tickets.Include(e => e.Employee).Include(e => e.Performer).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
		}

		public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

		public async Task<List<Ticket>> SearchTicketAsync(string searchString)
		{
            return await _context.Tickets.Where(t => t.Title.Contains(searchString)).ToListAsync();            
        }

		public bool Update(Ticket ticket)
        {
            _context.Update(ticket);
            return Save();
        }
    }
}
