using Family.Users.Utilities;
using Family.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using Family.Core.Exceptions;
using Family.Logic.UsersService.UserService;
using Family.Web.Models.UserModels;
using Family.Users.Models.UserModels;
using Family.Users.Models.PasswordModels;
using Family.Db.Entities.Users;

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

        [HttpGet]
        [RequirePermission(PermissionType.UserToAdmin)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _service.GetUsersAsync();

                var mappedUsers = _mapper.Map<IEnumerable<UserReadNameModel>>(users);

                return Ok(mappedUsers);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
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

        [HttpGet("all")]
        [RequirePermission(PermissionType.DeleteUser)]
        public async Task<IActionResult> GetParentsChildrenUsersAsync()
        {
            try
            {
                var users = await _service.GetParentsChildrenUsersAsync();

                var mappedUsers = _mapper.Map<IEnumerable<UserReadNameModel>>(users);

                return Ok(mappedUsers);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("maleadults")]
        [RequirePermission(PermissionType.CreateGenus)]
        public async Task<IActionResult> GetMaleAdults()
        {
            try
            {
                var maleAdults = await _service.GetMaleAdultsAsync();

                var mappedMaleAdults = _mapper.Map<IEnumerable<UserReadNameModel>>(maleAdults);

                return Ok(mappedMaleAdults);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("femaleadults")]
        [RequirePermission(PermissionType.CreateGenus)]
        public async Task<IActionResult> GetFemaleAdults()
        {
            try
            {
                var femaleAdults = await _service.GetFemaleAdultsAsync();

                var mappedFemaleAdults = _mapper.Map<IEnumerable<UserReadNameModel>>(femaleAdults);

                return Ok(mappedFemaleAdults);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("youths")]
        [RequirePermission(PermissionType.CreateGenus)]
        public async Task<IActionResult> GetYouths()
        {
            try
            {
                var youths = await _service.GetYouthsAsync();

                var mappedYouths = _mapper.Map<IEnumerable<UserReadNameModel>>(youths);

                return Ok(mappedYouths);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> UpdateUser(UserWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userId = GetUserId();

                var mappedUser = _mapper.Map<User>(model);

                await _service.UpdateUserAsync(mappedUser, userId);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("password")]
        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> UpdatePassword(PasswordWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                return BadRequest("Your password must match confirmPassword");
            }

            try
            {
                var userId = GetUserId();

                var mappedPassword = _mapper.Map<Password>(model);

                await _service.UpdatePasswordAsync(mappedPassword, userId);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("leave")]
        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> LeaveGenus()
        {
            try
            {
                var userId = GetUserId();

                await _service.LeaveGenusAsync(userId);

                return NoContent();
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
