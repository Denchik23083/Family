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

            var mapperGenus = _mapper.Map<IEnumerable<GenusReadModel>>(genus);

            return Ok(mapperGenus);
        }
    }
}
