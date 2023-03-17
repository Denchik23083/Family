using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Family.Logic.GenusService;
using Family.Web.Models.GenusModels;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers.GenusController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenusService _service;

        public GenusController(IMapper mapper, IGenusService service)
        {
            _mapper = mapper;
            _service = service;
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
            var genus = await _service.GetAllGenus();

            var mapperGenus = _mapper.Map<IEnumerable<GenusReadNameModel>>(genus);

            return Ok(mapperGenus);
        }
    }
}
