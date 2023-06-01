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

        public FPController(IFestivalPerformanceRepository fpRepo, IFestivalRepository festivalRepo, IShowRepository showRepo)
        {
            this.fpRepo = fpRepo;
            this.festivalRepo = festivalRepo;
            this.showRepo = showRepo;
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

                var newFPDto = newFP.ConvertToDto(festival, show);

                return CreatedAtAction(nameof(GetFP), new { id = newFPDto.Id }, newFPDto);
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

    }
}
