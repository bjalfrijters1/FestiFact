using Festifact.Api.Entities;
using Festifact.Api.Extensions;
using Festifact.Api.Migrations;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
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
                    return Ok(ticketDto);
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
                var newTicket = await this.ticketRepository.Insert(ticketToAdd);
                //add fId to parameters when checking for capactiy.
                //var festival = await this.festivalRepository.GetFestival(fId);

                if (newTicket == null)
                    return NoContent();

                var newTicketDto = newTicket.ConvertToDto();

                return CreatedAtAction(nameof(GetTicketById), new { id = newTicketDto.Id }, newTicketDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }
    }
}
