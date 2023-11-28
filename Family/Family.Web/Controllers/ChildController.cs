using AutoMapper;
using Family.Core.Exceptions;
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
        private readonly IChildService _service;
        private readonly IMapper _mapper;

        public ChildController(IChildService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChildren()
        {
            try
            {
                var children = await _service.GetAllChildren();

                var mappedChildren = _mapper.Map<IEnumerable<ChildReadModel>>(children);

                return Ok(mappedChildren);
            }
            catch (ChildNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetChild(int id)
        {
            try
            {
                var child = await _service.GetChild(id);

                var mappedChild = _mapper.Map<ChildReadModel>(child);

                return Ok(mappedChild);
            }
            catch (ChildNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("id")]
        public async Task<IActionResult> CreateChild(ChildWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedChild = _mapper.Map<Child>(model);

            await _service.CreateChild(mappedChild);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditChild(ChildWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedChild = _mapper.Map<Child>(model);

                await _service.EditChild(mappedChild, id);

                return NoContent();
            }
            catch (ChildNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteChild(int id)
        {
            try
            {
                await _service.DeleteChild(id);

                return NoContent();
            }
            catch (ChildNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
