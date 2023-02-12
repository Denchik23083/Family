using System.Threading.Tasks;
using Family.Logic.ParentsService;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsChildrenController : ControllerBase
    {
        private readonly IParentsService _service;

        public ParentsChildrenController(IParentsService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetParentsChildren(int id)
        {
            var children = await _service.GetParentsChildren(id);

            return Ok(children);
        }
    }
}
