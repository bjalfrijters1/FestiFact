using Festifact.Api.Entities;
using Festifact.Models.Dtos;

namespace Festifact.Api.Repositories.Contracts
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket> GetTicket(int id);
        Task<Ticket> Insert(TicketToAddDto ticketToAddDto);
    }
}
