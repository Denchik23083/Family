using AutoMapper;
using Family.Core.Exceptions;
using Family.Core.Utilities;
using Family.Logic.UsersService.AdminService;
using Family.Users.Models;
using Family.Users.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Family.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public AdminController(IAdminService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetInfo)]
        public async Task<IActionResult> GetAdmins()
        {
            try
            {
                var admins = await _service.GetAdminsAsync();

                var mappedAdmins = _mapper.Map<IEnumerable<UserReadModel>>(admins);

                return Ok(mappedAdmins);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("deleteuser/id")]
        [RequirePermission(PermissionType.DeleteUser)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _service.DeleteUserAsync(id);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
