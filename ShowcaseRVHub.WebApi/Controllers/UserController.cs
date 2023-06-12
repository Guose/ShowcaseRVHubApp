using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
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
        public async Task<ActionResult<IEnumerable<ShowcaseUser>>> GetUsersAsync()
        {
            var users = await _userRepo.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseUser>> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<ShowcaseUser>> CreateUserAsync(ShowcaseUser user)
        {
            if (user == null)
                return BadRequest();

            user.Id = Guid.NewGuid();
            await _userRepo.CreateUserAsync(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(ShowcaseUser user)
        {
            await _userRepo.UpdateUserAsync(user);

            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUserPasswordAsync(Guid id, JsonPatchDocument<ShowcaseUser> updateUser)
        {
            ShowcaseUser showcaseUser = await _userRepo.GetUserByIdAsync(id);
            if (showcaseUser == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            updateUser.ApplyTo(showcaseUser);
            await _userRepo.UpdateUsersPasswordAsync(id, showcaseUser);

            return Ok(showcaseUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await _userRepo.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
