using AutoMapper;
using Family.Db.Entities;
using Family.Logic.WebService.GenusService;
using Family.Web.Models.GenusModels;
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
        public async Task<IActionResult> GetAllGenus()
        {
            var genus = await _service.GetAllGenus();

            var mapperGenus = _mapper.Map<IEnumerable<GenusReadNameModel>>(genus);

            return Ok(mapperGenus);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetGenus(int id)
        {
            var genus = await _service.GetGenus(id);

            var mapperGenus = _mapper.Map<GenusReadModel>(genus);

            return Ok(mapperGenus);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenus(GenusWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdGenus = _mapper.Map<Genus>(model);

            //await _service.CreateGenus(createdGenus);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditGenus(GenusWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editedGenus = _mapper.Map<Genus>(model);

            //await _service.EditGenus(editedGenus, id);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteGenus(int id)
        {
            //await _service.DeleteGenus(id);

            return NoContent();
        }
    }
}
