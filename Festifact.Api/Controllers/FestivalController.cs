using Festifact.Api.Entities;
using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalRepository festivalRepository;
        private readonly IOrganiserRepository organiserRepository;
        private readonly ITicketRepository ticketRepository;

        //used for statistics
        private readonly IShowRepository showRepository;
        private readonly IPerformerRepository performerRepository;

        public FestivalController(IFestivalRepository festivalRepository, IOrganiserRepository organiserRepository, ITicketRepository ticketRepository,
            IShowRepository showRepository, IPerformerRepository performerRepository)
        {
            this.festivalRepository = festivalRepository;
            this.organiserRepository = organiserRepository;
            this.ticketRepository = ticketRepository;
            this.showRepository = showRepository;
            this.performerRepository = performerRepository;
        }


        [HttpPost]
        public async Task<ActionResult<FestivalDto>> PostFestival([FromBody] FestivalToAddDto festivalToAddDto)
        {
            try
            {
                var newFestival = await this.festivalRepository.Insert(festivalToAddDto);

                if (newFestival == null)
                    return NoContent();

                var newFestivalDto = newFestival.ConvertToDto();

                return CreatedAtAction(nameof(GetFestival), new { id = newFestivalDto.Id }, newFestivalDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FestivalDto>> GetFestival(int id)
        {
            try
            {
                var festival = await this.festivalRepository.GetFestival(id);
                var allTickets = await this.ticketRepository.GetTickets();

                if (festival != null)
                {
                    var organiser = await this.organiserRepository.GetOrganiserById(festival.OrganiserId);
                    if (organiser != null)
                    {
                        var festivalDto = festival.ConvertToDto(organiser);
                        festivalDto.TicketsRemaining = CalculateTicketsRemaining(id, festivalDto, allTickets);
                        return Ok(festivalDto);
                    } else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FestivalDto>>> GetFestivals()
        {
            try
            {
                //use dtoconversions if you have to use joined tables
                var festivals = await this.festivalRepository.GetFestivals();
                var organisers = await this.organiserRepository.GetOrganisers();
                var allTickets = await this.ticketRepository.GetTickets();

                if(festivals == null || organisers == null) 
                {
                    return NotFound();
                } 
                else
                {
                    var festivalDtos = festivals.ConvertToDto(organisers);
                    festivalDtos.ToList().ForEach(festivalDto =>
                        festivalDto.TicketsRemaining = CalculateTicketsRemaining(festivalDto.Id, festivalDto, allTickets));
                    return Ok(festivalDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<FestivalDto>> Edit([FromBody] FestivalDto festivalDto)
        {
            try
            {
                var result = await festivalRepository.Update(festivalDto);
                if (result == null)
                    return NoContent();
                else
                    return Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }  
        
        private int CalculateTicketsRemaining(int id, FestivalDto festivalDto, IEnumerable<Ticket> allTickets)
        {
            IEnumerable<Ticket> soldTickets =
                    from ticket in allTickets
                    where ticket.FestivalId == id
                    select ticket;

            var amountRemaining = festivalDto.MaxTickets - soldTickets.Count();
            if(amountRemaining > 0)
            {
                return amountRemaining;
            } else
            {
                return -1;
            }

        }

        [HttpGet("filter/{variable}/{value}")]
        public async Task<ActionResult<IEnumerable<FestivalDto>>> GetFilteredFestivals(string variable, string value)
        {
            try
            {
                var festivals = await this.festivalRepository.GetFestivals();
                var organisers = await this.organiserRepository.GetOrganisers();
                var allTickets = await this.ticketRepository.GetTickets();

                if (festivals == null || organisers == null)
                {
                    return NotFound();
                }
                else {
                    if (variable == "Genre")
                        festivals = festivals.Where(festival => (int)festival.Genre == int.Parse(value));
                    if (variable == "Type")
                        festivals = festivals.Where(festival => (int)festival.Type == int.Parse(value));

                    var festivalDtos = festivals.ConvertToDto(organisers);
                    festivalDtos.ToList().ForEach(festivalDto =>
                        festivalDto.TicketsRemaining = CalculateTicketsRemaining(festivalDto.Id, festivalDto, allTickets));
                    return Ok(festivalDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }
    }
}
