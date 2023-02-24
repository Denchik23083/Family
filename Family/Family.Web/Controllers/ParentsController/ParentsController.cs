using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Family.Db.Entities;
using Family.Logic.ParentsService;
using Family.Web.Models.ParentsModels;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers.ParentsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParentsService _service;

        public ParentsController(IMapper mapper, IParentsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await _service.GetAllParents();

            if (!parents.Any())
            {
                return NoContent();
            }

            var mapperParents = _mapper.Map<IEnumerable<ParentsReadModel>>(parents);

            return Ok(mapperParents);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetParent(int id)
        {
            var parent = await _service.GetParent(id);

            if (parent is null)
            {
                return NoContent();
            }

            var mapperParent = _mapper.Map<ParentsReadModel>(parent);

            return Ok(mapperParent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParent(ParentsWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdParent = _mapper.Map<Parent>(model);

            await _service.CreateParent(createdParent);

            return NoContent();
        }
    }
}
