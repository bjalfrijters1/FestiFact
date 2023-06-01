using Festifact.Api.Data;
using Festifact.Api.Entities;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Festifact.Api.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly FestifactDbContext festifactDbContext;

        public TicketRepository(FestifactDbContext festifactDbContext)
        {
            this.festifactDbContext = festifactDbContext;
        }

        public async Task<Ticket> GetTicket(int id)
        {
            var ticket = await festifactDbContext.Tickets.FindAsync(id);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            var tickets = await festifactDbContext.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<Ticket> Insert(TicketToAddDto ticketToAddDto)
        {
            var result = await festifactDbContext.AddAsync(new Ticket
            {
                FestivalId = ticketToAddDto.FestivalId
            });
            await festifactDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
