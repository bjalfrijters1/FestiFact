using Festifact.Api.Entities;
using Festifact.Api.Extensions;
using Festifact.Api.Migrations;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IFestivalRepository festivalRepository;

        public TicketController(ITicketRepository ticketRepository, IFestivalRepository festivalRepository)
        {
            this.ticketRepository = ticketRepository;
            this.festivalRepository = festivalRepository;

        }

        [HttpGet("alltickets/{fId:int}")]
        public async Task<ActionResult<TicketDto>> GetTicketsByFestival(int fId)
        {
            try
            {
                var festival = await this.festivalRepository.GetFestival(fId);
                var tickets = await this.ticketRepository.GetTickets();

                if (tickets == null)
                    return NoContent();
                else
                {
                    var ticketDto = tickets.ConvertToDto(festival);
                    if (ticketDto != null)
                        return Ok(ticketDto);
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TicketDto>> GetTicketById(int id)
        {
            try
            {
                var ticket = await this.ticketRepository.GetTicket(id);

                if (ticket == null)
                    return NoContent();
                else
                {
                    var ticketDto = ticket.ConvertToDto();
                    return Ok(ticketDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> Insert([FromBody] TicketToAddDto ticketToAdd)
        {
            try
            {
                var festival = await this.festivalRepository.GetFestival(ticketToAdd.FestivalId);
                if(festival.TicketsRemaining > 0)
                {
                    var newTicket = await this.ticketRepository.Insert(ticketToAdd);
                    var newTicketDto = newTicket.ConvertToDto();
                    if (newTicket == null)
                        return NoContent();

                    return CreatedAtAction(nameof(GetTicketById), new { id = newTicketDto.Id }, newTicketDto);
                } else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        "There are no tickets remaining!!!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet]
        [Route("/remaining/{id:int}")]
        public async Task<ActionResult<int>> TicketsRemaining(int fId)
        {
            try
            {
                var allTickets = await this.ticketRepository.GetTickets();
                IEnumerable<Ticket> soldTickets =
                    from ticket in allTickets
                    where ticket.FestivalId == fId
                    select ticket;

                var festival = await this.festivalRepository.GetFestival(fId);
                var amountRemaining = festival.MaxTickets - soldTickets.Count();
                // > 0 means there's more tickets left then sold, any other situation SHOULD NOT OCCUR
                if (amountRemaining > 0)
                {
                    return Ok(amountRemaining);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }
    }
}
