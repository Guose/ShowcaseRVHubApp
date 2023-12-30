using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;


namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers() //<IEnumerable<ShowcaseUserDto>>
        {
            IEnumerable<ShowcaseUserDto>? users = await _userRepo.GetAllUsersAsync();

            if (users == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(users.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseUserDto?>> GetUserById(Guid id)
        {
            ShowcaseUserDto? user = await _userRepo.GetUserByIdAsync(id);

            if (user == null)
                return NotFound(new { Message = $"User with id {id} does not exist." } );

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<ShowcaseUser>> CreateUser(ShowcaseUser user)
        {
            if (await _userRepo.AddAsync(user))
                return Ok(user);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, ShowcaseUserDto updateUser)
        {
            ShowcaseUserDto? user = await _userRepo.GetUserByIdAsync(id);

            if (user == null)
                return NotFound(new { Message = $"User with id {id} does not exist." });                

            return await _userRepo.UpdateUserAsync(updateUser)
            ? Ok(user)
            : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserPassword(Guid id, JsonPatchDocument<ShowcaseUserDto> updateUser)
        {
            ShowcaseUserDto? showcaseUser = await _userRepo.GetUserByIdAsync(id);

            if (showcaseUser == null)
                return NotFound(new { Message = $"User with id {id} does not exist." });

            updateUser.ApplyTo(showcaseUser);

            return await _userRepo.UpdateUsersPasswordAsync(id, showcaseUser)
            ? Ok(showcaseUser)
            : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(ShowcaseUser user)
        {
            if (user != null)
            {
                _userRepo.Remove(user);
                return NoContent();
            }
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
