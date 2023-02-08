using System.Threading.Tasks;
using Family.Logic.ChildrenService;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildrenService _service;

        public ChildrenController(IChildrenService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChildren()
        {
            var children = await _service.GetAllChildren();

            return Ok(children);
        }
    }
}
