﻿using sber.Interfaces;

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

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(i => i.TicketId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}