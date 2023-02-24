using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Family.Logic.ParentsService;
using Family.Web.Models.ChildrenModels;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers.ParentsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsChildrenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IParentsService _service;

        public ParentsChildrenController(IMapper mapper, IParentsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetParentsChildren(int id)
        {
            var children = await _service.GetParentsChildren(id);

            var mapperChildren = _mapper.Map<IEnumerable<ChildrenReadModel>>(children);

            return Ok(mapperChildren);
        }
    }
}
