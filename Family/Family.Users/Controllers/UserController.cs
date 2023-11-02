using Family.Users.Utilities;
using Family.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using Family.Core.Exceptions;
using Family.Logic.UsersService.UserService;
using Family.Users.Models;

namespace Family.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("profile")]
        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userId = GetUserId();

                var user = await _service.GetUserAsync(userId);

                var mappedUser = _mapper.Map<UserReadModel>(user);

                return Ok(mappedUser);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _service.GetUsersAsync();

                var mappedUsers = _mapper.Map<IEnumerable<UserReadModel>>(users);

                return Ok(mappedUsers);
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
