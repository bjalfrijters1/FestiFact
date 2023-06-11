using Festifact.Api.Entities;
using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository showRepository;
        private readonly IFilmRepository filmRepository;
        private readonly ILocationRepository locationRepository;
        private readonly IPerformerRepository performerRepository;

        public ShowController(IShowRepository showRepository, IFilmRepository filmRepository, ILocationRepository locationRepository, IPerformerRepository performerRepository)
        {
            this.showRepository = showRepository;
            this.filmRepository = filmRepository;
            this.locationRepository = locationRepository;
            this.performerRepository = performerRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShowDto>> GetShow(int id)
        {
            try
            {
                var show = await this.showRepository.GetShow(id);

                if(show != null)
                {
                    var location = await this.locationRepository.GetLocation(show.LocationId);
                    
                    if (location != null && show.FilmId != null)
                    {
                        var film = await this.filmRepository.GetFilm((int)show.FilmId);
                        var showDto = show.ConvertToDto(film, null, location);
                        return Ok(showDto);
                    } else if(location != null && show.PerformerId != null)
                    {
                        var performer = await this.performerRepository.GetPerformer((int)show.PerformerId);
                        var showDto = show.ConvertToDto(null, performer, location);
                        return Ok(showDto);
                    } else
                    {
                        return NotFound();
                    }
                } else
                {
                    return NotFound();
                }
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetShows()
        {
            try
            {
                var shows = await this.showRepository.GetShows();
                var locations = await this.locationRepository.GetLocations();
                var performers = await this.performerRepository.GetPerformers();
                var films = await this.filmRepository.GetFilms();

                if(shows == null || locations == null || performers == null || films == null)
                {
                    return NotFound();
                } else
                {
                    var showDtos = shows.ConvertToDto(locations, performers, films);
                    return Ok(showDtos);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShowDto>> PostShow([FromBody] ShowToAddDto showToAddDto)
        {
            try 
            {
                var shows = await this.showRepository.GetShows();
                var availability = true;
                var showsWithPerformer = shows.Where(s => s.PerformerId == showToAddDto.PerformerId);
                foreach (var p in showsWithPerformer)
                {
                    if (p.StartDateTime < showToAddDto.EndDateTime)
                        availability = false;

                    if (p.EndDateTime < showToAddDto.StartDateTime)
                        availability = false;

                }

                var showsWithLocation = shows.Where(s => s.LocationId == showToAddDto.LocationId);
                foreach (var l in showsWithLocation)
                {
                    if (l.StartDateTime < showToAddDto.EndDateTime)
                        availability = false;

                    if (l.EndDateTime < showToAddDto.StartDateTime)
                        availability = false;
                }

                if (availability)
                {
                    var newShow = await this.showRepository.Insert(showToAddDto);
                    if (newShow != null)
                    {
                        var location = await this.locationRepository.GetLocation(newShow.LocationId);

                        if (location != null && newShow.FilmId != null)
                        {
                            var film = await this.filmRepository.GetFilm((int)newShow.FilmId);
                            var showDto = newShow.ConvertToDto(film, null, location);
                            return CreatedAtAction(nameof(GetShow), new { id = showDto.Id }, showDto);
                        }
                        else if (location != null && newShow.PerformerId != null)
                        {
                            var performer = await this.performerRepository.GetPerformer((int)newShow.PerformerId);
                            var showDto = newShow.ConvertToDto(null, performer, location);
                            return CreatedAtAction(nameof(GetShow), new { id = showDto.Id }, showDto);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        "Location and/or Performer not available at timeslot.");
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
