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
    public class GenusParentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenusService _service;

        public GenusParentsController(IMapper mapper, IGenusService service)
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
        public async Task<IActionResult> GetGenusParents(int id)
        {
            var genus = await _service.GetGenusParents(id);

            var mapperGenus = _mapper.Map<GenusParentsReadModel>(genus);

            return Ok(mapperGenus);
        }
    }
}
