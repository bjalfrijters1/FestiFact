using Festifact.Api.Entities;
using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FPController : ControllerBase
    {
        private readonly IFestivalPerformanceRepository fpRepo;
        private readonly IFestivalRepository festivalRepo;
        private readonly IShowRepository showRepo;
        private readonly ITicketRepository ticketRepo;

        public FPController(IFestivalPerformanceRepository fpRepo, IFestivalRepository festivalRepo, IShowRepository showRepo, ITicketRepository ticketRepo)
        {
            this.fpRepo = fpRepo;
            this.festivalRepo = festivalRepo;
            this.showRepo = showRepo;
            this.ticketRepo = ticketRepo;
        }

        [HttpGet("statistics")]
        public async Task<ActionResult<StatisticsDto>> GetStatistics(int id)
        {
            try
            {
                var festival = await this.festivalRepo.GetFestival(id);
                var festivalDto = festival.ConvertToDto();
                var allTickets = await this.ticketRepo.GetTickets();
                var ticketsAvailable = CalculateTicketsRemaining(festival.Id, festivalDto, allTickets);
                StatisticsDto statDto = new StatisticsDto
                {
                    FestivalId = festival.Id,
                    TicketsAvailable = ticketsAvailable,
                    TicketsSold = (festival.MaxTickets - ticketsAvailable)
                };

                if (statDto == null)
                    return NoContent();

                return Ok(statDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }


        }

        [HttpGet]
        public async Task<ActionResult<FestivalPerformanceDto>> GetFPByFestival(int fId)
        {
            try
            {
                var festival = await this.festivalRepo.GetFestival(fId);
                var shows = await this.showRepo.GetShows();
                var fPerformances = await this.fpRepo.GetAllFestivalPerformances();

                if (fPerformances == null)
                    return NoContent();
                else
                {
                    var fpDto = fPerformances.ConvertToDto(festival, shows);
                    return Ok(fpDto);
                }
                    
                
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FestivalPerformanceDto>> PostFP([FromBody] FestivalPerformanceToAddDto fpToAddDto, int fId, int sId)
        {
            try
            {
                var newFP = await this.fpRepo.Insert(fpToAddDto);
                var festival = await this.festivalRepo.GetFestival(fId);
                var show = await this.showRepo.GetShow(sId);

                
                if(newFP == null)
                {
                    return NoContent();
                }

                //check for date overlap
                if (show.StartDateTime >= festival.StartDate && show.EndDateTime <= festival.EndDate)
                {
                    var newFPDto = newFP.ConvertToDto(festival, show);

                    return CreatedAtAction(nameof(GetFP), new { id = newFPDto.Id }, newFPDto);
                } else
                {
                    return NoContent();
                }
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FestivalPerformanceDto>> GetFP(int id)
        {
            try
            {
                var fp = await this.fpRepo.GetFestivalPerformance(id);
                var festival = await this.festivalRepo.GetFestival(fp.FestivalId);
                var show = await this.showRepo.GetShow(fp.ShowId);

                if(fp == null)
                {
                    return NoContent();
                } else
                {
                    var fpDto = fp.ConvertToDto(festival, show);
                    return Ok(fpDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        private int CalculateTicketsRemaining(int id, FestivalDto festivalDto, IEnumerable<Ticket> allTickets)
        {
            IEnumerable<Ticket> soldTickets =
                    from ticket in allTickets
                    where ticket.FestivalId == id
                    select ticket;

            var amountRemaining = festivalDto.MaxTickets - soldTickets.Count();
            if (amountRemaining > 0)
            {
                return amountRemaining;
            }
            else
            {
                return -1;
            }

        }

    }
}
