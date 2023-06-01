using Festifact.Api.Extensions;
using Festifact.Api.Repositories.Contracts;
using Festifact.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Festifact.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                var user = await this._userRepository.GetUser(id);

                if (user == null)
                    return NotFound();
                else
                {
                    var userDto = user.ConvertToDto();
                    return Ok(userDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Insert([FromBody] UserToAddDto userToAdd)
        {
            try
            {
                var newUser = await this._userRepository.Insert(userToAdd);

                if (newUser == null)
                    return NoContent();
                
                var newUserDto = newUser.ConvertToDto();

                return CreatedAtAction(nameof(GetUser), new { id = newUserDto.Id }, newUserDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving from database");
            }
        }
    }
}
