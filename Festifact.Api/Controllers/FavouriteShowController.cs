using Festifact.Api.Entities;
using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFavouriteShowRepository _favouriteShowRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IPerformerRepository _performerRepository;

        public FavouriteShowController(
            IShowRepository showRepository, IUserRepository userRepository, IFavouriteShowRepository favouriteShowRepository,
            ILocationRepository locationRepository, IPerformerRepository performerRepository)
        {
            this._showRepository = showRepository;
            this._userRepository = userRepository;
            this._favouriteShowRepository = favouriteShowRepository;
            this._locationRepository = locationRepository;
            this._performerRepository = performerRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetFavouriteShows(int id)
        {
            try
            {
                var user = await this._userRepository.GetUser(id);
                
                if(user != null)
                {
                    var favourites = await this._favouriteShowRepository.GetFavouriteShowsAsync(id);
                    if (favourites != null)
                    {
                        List<ShowDto> showDtos = new List<ShowDto>();
                        foreach (var favourite in favourites)
                        {
                            var show = await this._showRepository.GetShow(favourite.ShowId);
                            var location = await this._locationRepository.GetLocation(show.LocationId);
                            var performer = await this._performerRepository.GetPerformer((int)show.PerformerId!);
                            showDtos.Add(show.ConvertToDto(null, performer, location));
                        }

                        if (showDtos.Any())
                            return Ok(showDtos);
                        else
                            return NoContent();
                    }
                    else
                        return NotFound();
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

        [HttpDelete("user/{userId:int}/show/{showId:int}")]
        public async Task<ActionResult> Delete(int userId, int showId)
        {
            try
            {
                var favourites = await this._favouriteShowRepository.GetFavouriteShowsAsync(userId);
                if (favourites != null)
                {
                    foreach (var favourite in favourites)
                    {
                        if (favourite.ShowId == showId)
                        {
                            await this._favouriteShowRepository.DeleteFavouriteShowAsync(userId, showId);
                            return Ok();
                        }
                        else
                        {
                            return NoContent();
                        }
                    }
                } else
                {
                    return NotFound();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<FavouriteShowDto>> Insert([FromBody]FavouriteShowToAdd favouriteShowToAdd)
        {
            try
            {
                var newFavouriteShow = await this._favouriteShowRepository.AddFavouriteShowAsync(favouriteShowToAdd);

                if (newFavouriteShow == null)
                    return NoContent();

                var newFavouriteShowDto = newFavouriteShow.ConvertToDto();

                return CreatedAtAction(nameof(GetFavouriteShow), new { id = newFavouriteShowDto.Id }, newFavouriteShowDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        } 

        [HttpGet("single/{id:int}")]
        public async Task<ActionResult<FavouriteShowDto>> GetFavouriteShow(int id)
        {
            try
            {
                var favouriteShow = await this._favouriteShowRepository.GetFavouriteShowAsync(id);

                if (favouriteShow == null)
                    return NoContent();
                else
                {
                    var favouriteShowDto = favouriteShow.ConvertToDto();
                    return Ok(favouriteShowDto);
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
