using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IShowcaseUserRepo _userRepo;

        public UserController(IShowcaseUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowcaseUserModel>>> GetUsersAsync()
        {
            var users = await _userRepo.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseUserModel>> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepo.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<ShowcaseUserModel>> CreateUserAsync(ShowcaseUserModel user)
        {
            await _userRepo.CreateUserAsync(user);

            return CreatedAtRoute(nameof(CreateUserAsync), new {id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(Guid id, ShowcaseUserModel user)
        {
            await _userRepo.UpdateUserAsync(id, user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            await _userRepo.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
