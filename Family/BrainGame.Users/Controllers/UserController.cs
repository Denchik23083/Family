using BrainGame.Users.Utilities;
using Family.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Family.Core.Exceptions;
using Family.Logic.UserService;

namespace BrainGame.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userId = GetUserId();

                var user = await _service.GetUserAsync(userId);

                return Ok(user);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        private int GetUserId()
        {
            var id = HttpContext.User.Claims
                .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)!.Value;

            var result = int.TryParse(id, out var userId);

            if (!result)
            {
                throw new UserNotFoundException("User not found");
            }

            return userId;
        }
    }
}
