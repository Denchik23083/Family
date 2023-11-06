using AutoMapper;
using Family.Db.Entities;
using Family.Logic.WebService.ChildService;
using Family.Web.Models.ChildModels;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChildService _service;

        public ChildController(IMapper mapper, IChildService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChildren()
        {
            var children = await _service.GetAllChildren();

            var mapperChildren = _mapper.Map<IEnumerable<ChildReadModel>>(children);

            return Ok(mapperChildren);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetChild(int id)
        {
            var child = await _service.GetChild(id);

            var mapperChild = _mapper.Map<ChildReadModel>(child);

            return Ok(mapperChild);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChild(ChildWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdChild = _mapper.Map<Child>(model);

            await _service.CreateChild(createdChild);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditChild(ChildWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedChild = _mapper.Map<Child>(model);

            await _service.EditChild(editedChild, id);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteChild(int id)
        {
            await _service.DeleteChild(id);

            return NoContent();
        }
    }
}
