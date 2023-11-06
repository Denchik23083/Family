using AutoMapper;
using Family.Db.Entities;
using Family.Logic.WebService.ParentService;
using Family.Web.Models.ParentModels;
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
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await _service.GetAllParents();

            var mapperParents = _mapper.Map<IEnumerable<ParentReadModel>>(parents);

            return Ok(mapperParents);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetParent(int id)
        {
            var parent = await _service.GetParent(id);

            var mapperParent = _mapper.Map<ParentReadModel>(parent);

            return Ok(mapperParent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParent(ParentWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdParent = _mapper.Map<Parent>(model);

            await _service.CreateParent(createdParent);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditParent(ParentWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedParent = _mapper.Map<Parent>(model);

            await _service.EditParent(editedParent, id);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            await _service.DeleteParent(id);

            return NoContent();
        }
    }
}
