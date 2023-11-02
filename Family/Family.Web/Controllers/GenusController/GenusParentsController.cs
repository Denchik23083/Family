using AutoMapper;
using Family.Logic.WebService.GenusService;
using Family.Web.Models.ParentsModels;
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
        public async Task<IActionResult> GetAllGenusParents()
        {
            var parents = new List<string>();
            //var parents = await _service.GetAllGenusParents();

            var mapperParents = _mapper.Map<IEnumerable<ParentsReadModel>>(parents);

            return Ok(mapperParents);
        }
    }
}
