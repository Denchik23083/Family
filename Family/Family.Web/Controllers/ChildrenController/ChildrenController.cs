using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Family.Db.Entities;
using Family.Logic.ChildrenService;
using Family.Web.Models.ChildrenModels;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers.ChildrenController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChildrenService _service;

        public ChildrenController(IMapper mapper, IChildrenService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChildren()
        {
            var children = await _service.GetAllChildren();

            var mapperChildren = _mapper.Map<IEnumerable<ChildrenReadModel>>(children);

            return Ok(mapperChildren);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetChild(int id)
        {
            var child = await _service.GetChild(id);

            var mapperChild = _mapper.Map<ChildrenReadModel>(child);

            return Ok(mapperChild);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChild(ChildrenWriteModel model)
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
        public async Task<IActionResult> EditChild(ChildrenWriteModel model, int id)
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
