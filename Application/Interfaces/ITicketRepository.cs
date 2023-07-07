namespace Application.Interfaces
{
    using Domains.Entities;
    using Domains.Enums;
    using WebAPI.Filter;

    public interface ITicketRepository
    {
        Task<ICollection<Ticket>> GetAllAsync(FilterPaging filterPaging);
        Task<Ticket> GetByIdAsync(int id);

        Task<Ticket> AddTicketAsync (Ticket ticket);
        Task<Ticket> DeleteTicketAsync (int id);
        Task<Ticket> HandelTicketStatusAsync(int id, TicketStatus stutus);


    }
}
