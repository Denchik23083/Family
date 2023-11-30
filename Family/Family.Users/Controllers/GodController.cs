using AutoMapper;
using Family.Core.Exceptions;
using Family.Core.Utilities;
using Family.Logic.UsersService.GodService;
using Family.Users.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Family.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GodController : ControllerBase
    {
        private readonly IGodService _service;
        private readonly IMapper _mapper;

        public GodController(IGodService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPut("usertoadmin/id")]
        [RequirePermission(PermissionType.DeleteUser)]
        public async Task<IActionResult> UserToAdmin(int id)
        {
            try
            {
                await _service.UserToAdminAsync(id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("admintouser/id")]
        [RequirePermission(PermissionType.DeleteUser)]
        public async Task<IActionResult> AdminToUser(int id)
        {
            try
            {
                await _service.AdminToUserAsync(id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
