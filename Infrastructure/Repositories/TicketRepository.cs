namespace Infrastructure.Repositories
{
    using Application.Interfaces;
    using Domains.Entities;
    using Domains.Enums;
    using Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebAPI.Filter;

    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TicketRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        } 
        public async Task<ICollection<Ticket>> GetAllAsync(FilterPaging filterPaging )
        {
            var tickets = await dbContext.Tickets.OrderByDescending(x => x.ID).Skip((filterPaging.PageIndex - 1) * filterPaging.PageSize).Take(filterPaging.PageSize).ToListAsync();
            return tickets ;
        }
        public Task<Ticket> GetByIdAsync(int id)
        {
            return dbContext.Tickets.FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            if (ticket != null)
            {
                await dbContext.AddAsync(ticket);
                await dbContext.SaveChangesAsync();
                return ticket;
            }
            return null;
        }

        public Task<Ticket> DeleteTicketAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> HandelTicketStatusAsync(int id, TicketStatus status)
        {
            Ticket ticket = new Ticket { ID = id }; 
            dbContext.Attach(ticket);
        
            dbContext.Entry(ticket).Property(t => t.TicketStatus).IsModified = true;
            ticket.TicketStatus = status;
            try
            {
                await dbContext.SaveChangesAsync();
                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception " + ex);
                throw;
            }
        }

    }
}
