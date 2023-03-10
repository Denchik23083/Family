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
    public class GenusChildrenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenusService _service;

        public GenusChildrenController(IMapper mapper, IGenusService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetChildrenGenus(int id)
        {
            var genusChildren = await _service.GetGenusChildren(id);

            var mapperGenus = _mapper.Map<IEnumerable<GenusChildrenReadModel>>(genusChildren);

            return Ok(mapperGenus);
        }
    }
}
