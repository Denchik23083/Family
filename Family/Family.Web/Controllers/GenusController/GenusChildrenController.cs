using AutoMapper;
using Family.Logic.WebService.GenusService;
using Family.Web.Models.ChildrenModels;
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

        [HttpGet]
        public async Task<IActionResult> GetAllGenusChildren()
        {
            var children = new List<string>();
            //var children = await _service.GetAllGenusChildren();

            var mapperChildren = _mapper.Map<IEnumerable<ChildrenReadModel>>(children);

            return Ok(mapperChildren);
        }
    }
}
