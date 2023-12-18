using AutoMapper;
using Family.Core.Exceptions;
using Family.Core.Utilities;
using Family.Logic.WebService.ChildService;
using Family.Web.Models.ChildModels;
using Family.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _service;
        private readonly IMapper _mapper;

        public ChildController(IChildService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetChild)]
        public async Task<IActionResult> GetAllChildren()
        {
            try
            {
                var children = await _service.GetAllChildrenAsync();

                var mappedChildren = _mapper.Map<IEnumerable<ChildReadModel>>(children);

                return Ok(mappedChildren);
            }
            catch (ChildNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        [RequirePermission(PermissionType.GetChild)]
        public async Task<IActionResult> GetChild(int id)
        {
            try
            {
                var child = await _service.GetChildAsync(id);

                var mappedChild = _mapper.Map<ChildReadModel>(child);

                return Ok(mappedChild);
            }
            catch (ChildNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
