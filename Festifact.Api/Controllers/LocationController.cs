using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locRepo;

        public LocationController(ILocationRepository _locRepo)
        {
            this._locRepo = _locRepo;
        }

        [HttpPost]
        public async Task<ActionResult<LocationDto>> PostLocation([FromBody] LocationToAddDto locationToAddDto)
        {
            try
            {
                var newLocation = await this._locRepo.Insert(locationToAddDto);

                if (newLocation == null)
                    return NoContent();

                var newLocationDto = newLocation.ConvertToDto();

                return CreatedAtAction(nameof(GetLocation), new { id = newLocationDto.Id }, newLocationDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LocationDto>> GetLocation(int id)
        {
            try
            {
                var location = await this._locRepo.GetLocation(id);

                if (location == null)
                    return NoContent();
                
                var locationDto = location.ConvertToDto();
                return Ok(locationDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocations()
        {
            try
            {
                var locations = await this._locRepo.GetLocations();

                if (locations == null)
                    return NoContent();

                var locationDtos = locations.ConvertToDto();
                return Ok(locationDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }
    }
}
