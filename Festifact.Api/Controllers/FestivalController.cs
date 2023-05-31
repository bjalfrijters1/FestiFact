using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalController : ControllerBase
    {
        private readonly IFestivalRepository festivalRepository;
        private readonly IOrganiserRepository organiserRepository;

        public FestivalController(IFestivalRepository festivalRepository, IOrganiserRepository organiserRepository)
        {
            this.festivalRepository = festivalRepository;
            this.organiserRepository = organiserRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FestivalDto>> GetFestival(int id)
        {
            try
            {
                var festival = await this.festivalRepository.GetFestival(id);


                if (festival != null)
                {
                    var organiser = await this.organiserRepository.GetOrganiserById(festival.OrganiserId);
                    if (organiser != null)
                    {
                        var festivalDto = festival.ConvertToDto(organiser);
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

                if(festivals == null || organisers == null) 
                {
                    return NotFound();
                } 
                else
                {
                    var festivalDtos = festivals.ConvertToDto(organisers);
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
