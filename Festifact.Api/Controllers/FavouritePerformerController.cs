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
    public class FavouritePerformerController : ControllerBase
    {
        private readonly IPerformerRepository _performerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFavouritePerformerRepository _favouritePerformerRepository;

        public FavouritePerformerController(
            IPerformerRepository performerRepository, IUserRepository userRepository,
            IFavouritePerformerRepository favouritePerformerRepository)
        {
            this._performerRepository = performerRepository;
            this._userRepository = userRepository;
            this._favouritePerformerRepository = favouritePerformerRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<PerformerDto>>> GetFavouritePerformers(int id)
        {
            try
            {
                var user = await this._userRepository.GetUser(id);

                if (user != null)
                {
                    var favourites = await this._favouritePerformerRepository.GetFavouritePerformersAsync(id);
                    if (favourites != null)
                    {
                        List<PerformerDto> performerDtos = new List<PerformerDto>();
                        foreach (var favourite in favourites)
                        {
                            var performer = await this._performerRepository.GetPerformer(favourite.PerformerId);
                            performerDtos.Add(performer.ConvertToDto());
                        }

                        if (performerDtos.Any())
                            return Ok(performerDtos);
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

        [HttpDelete("user/{userId:int}/performer/{performerId:int}")]
        public async Task<ActionResult> Delete(int userId, int performerId)
        {
            try
            {
                var favourites = await this._favouritePerformerRepository.GetFavouritePerformersAsync(userId);
                if (favourites != null)
                {
                    foreach (var favourite in favourites)
                    {
                        if (favourite.PerformerId == performerId)
                        {
                            await this._favouritePerformerRepository.DeleteFavouritePerformerAsync(userId, performerId);
                            return Ok();
                        }
                        else
                        {
                            return NoContent();
                        }
                    }
                }
                else
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
        public async Task<ActionResult<FavouritePerformerDto>> Insert([FromBody] FavouritePerformerToAddDto favouritePerformerToAdd)
        {
            try
            {
                var newFavouritePerformer = await this._favouritePerformerRepository.AddFavouritePerformerAsync(favouritePerformerToAdd);

                if (newFavouritePerformer == null)
                    return NoContent();

                var newFavouritePerformerDto = newFavouritePerformer.ConvertToDto();

                return CreatedAtAction(nameof(GetFavouritePerformer), new { id = newFavouritePerformerDto.Id }, newFavouritePerformerDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpGet("single/{id:int}")]
        public async Task<ActionResult<FavouritePerformerDto>> GetFavouritePerformer(int id)
        {
            try
            {
                var favouritePerformer = await this._favouritePerformerRepository.GetFavouritePerformerAsync(id);

                if (favouritePerformer == null)
                    return NoContent();
                else
                {
                    var favouritePerformerDto = favouritePerformer.ConvertToDto();
                    return Ok(favouritePerformerDto);
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
