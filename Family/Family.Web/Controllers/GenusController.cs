using AutoMapper;
using Family.Core.Exceptions;
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
            try
            {
                var genus = await _service.GetAllGenus();

                var mappedGenus = _mapper.Map<IEnumerable<GenusReadNameModel>>(genus);

                return Ok(mappedGenus);
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetGenus(int id)
        {
            try
            {
                var genus = await _service.GetGenus(id);

                var mappedGenus = _mapper.Map<GenusReadModel>(genus);

                return Ok(mappedGenus);
            }
            catch (GenusNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateGenus(GenusWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedGenus = _mapper.Map<Genus>(model);

            await _service.CreateGenus(mappedGenus);

            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> EditGenus(GenusWriteModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedGenus = _mapper.Map<Genus>(model);

            await _service.EditGenus(mappedGenus, id);

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteGenus(int id)
        {
            await _service.DeleteGenus(id);

            return NoContent();
        }*/
    }
}
