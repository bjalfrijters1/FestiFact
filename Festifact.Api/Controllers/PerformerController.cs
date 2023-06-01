using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        private readonly IPerformerRepository performerRepository;

        public PerformerController(IPerformerRepository performerRepository)
        {
            this.performerRepository = performerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformerDto>>> GetPerformers()
        {
            try
            {
                var result = await this.performerRepository.GetPerformers();
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
        public async Task<ActionResult<PerformerDto>> GetPerformer(int id)
        {
            try
            {
                var result = await this.performerRepository.GetPerformer(id);
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
