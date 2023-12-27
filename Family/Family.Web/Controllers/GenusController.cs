using AutoMapper;
using Family.Core.Exceptions;
using Family.Core.Utilities;
using Family.Db.Entities.Users;
using Family.Db.Entities.Web;
using Family.Logic.WebService.GenusService;
using Family.Web.Models.ChildModels;
using Family.Web.Models.GenusModels;
using Family.Web.Models.ParentModels;
using Family.Web.Models.UserModels;
using Family.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenusController : ControllerBase
    {
        private readonly IGenusService _service;
        private readonly IMapper _mapper;

        public GenusController(IGenusService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetGenus)]
        public async Task<IActionResult> GetAllGenus()
        {
            try
            {
                var genus = await _service.GetAllGenusAsync();

                var mappedGenus = _mapper.Map<IEnumerable<GenusReadNameModel>>(genus);

                return Ok(mappedGenus);
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [RequirePermission(PermissionType.GetGenus)]
        public async Task<IActionResult> GetGenus(int id)
        {
            try
            {
                var genus = await _service.GetGenusAsync(id);

                var mappedGenus = _mapper.Map<GenusReadModel>(genus);

                return Ok(mappedGenus);
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [RequirePermission(PermissionType.CreateGenus)]
        public async Task<IActionResult> CreateGenus(GenusWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedGenus = _mapper.Map<Genus>(model);

            await _service.CreateGenusAsync(mappedGenus);

            return NoContent();
        }

        [HttpPut("{id}")]
        [RequirePermission(PermissionType.UpdateDeleteGenus)]
        public async Task<IActionResult> UpdateGenus(GenusWriteNameModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedGenus = _mapper.Map<Genus>(model);

                await _service.UpdateGenusAsync(mappedGenus, id);

                return NoContent();
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("parent/{id}")]
        [RequirePermission(PermissionType.UpdateDeleteGenus)]
        public async Task<IActionResult> AddParent(ParentWriteModel model, int id)
        {
            try
            {
                var mappedParent = _mapper.Map<Parent>(model);

                await _service.AddParentAsync(mappedParent, id);

                return NoContent();
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("child/{id}")]
        [RequirePermission(PermissionType.UpdateDeleteGenus)]
        public async Task<IActionResult> AddChild(ChildWriteModel model, int id)
        {
            try
            {
                var mappedChild = _mapper.Map<Child>(model);

                await _service.AddChildAsync(mappedChild, id);

                return NoContent();
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [RequirePermission(PermissionType.UpdateDeleteGenus)]
        public async Task<IActionResult> DeleteGenus(int id)
        {
            try
            {
                await _service.DeleteGenusAsync(id);

                return NoContent();
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
