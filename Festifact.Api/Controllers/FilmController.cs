using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository filmRepository;

        public FilmController(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilms()
        {
            try
            {
                var result = await this.filmRepository.GetFilms();
                if (result != null)
                    return Ok(result.ConvertToDto());
                else
                    return NotFound();
            } 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FilmDto>> GetFilm(int id)
        {
            try
            {
                var result = await this.filmRepository.GetFilm(id);
                if (result != null)
                    return Ok(result.ConvertToDto());
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving from database");
            }
        }
    }
}
