using AutoMapper;
using Family.Core.Exceptions;
using Family.Core.Utilities;
using Family.Logic.WebService.ParentService;
using Family.Web.Models.ParentModels;
using Family.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _service;
        private readonly IMapper _mapper;

        public ParentController(IParentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [RequirePermission(PermissionType.GetParent)]
        public async Task<IActionResult> GetAllParents()
        {
            try
            {
                var parents = await _service.GetAllParentsAsync();

                var mappedParents = _mapper.Map<IEnumerable<ParentReadModel>>(parents);

                return Ok(mappedParents);
            }
            catch (ParentNotFoundException e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpGet("id")]
        [RequirePermission(PermissionType.GetParent)]
        public async Task<IActionResult> GetParent(int id)
        {
            try
            {
                var parent = await _service.GetParentAsync(id);

                var mappedParent = _mapper.Map<ParentReadModel>(parent);

                return Ok(mappedParent);
            }
            catch (ParentNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
