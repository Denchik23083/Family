using System.Threading.Tasks;
using Family.Logic.ChildrenService;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers.ChildrenController
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

        [HttpGet("id")]
        public async Task<IActionResult> GetChild(int id)
        {
            var parent = await _service.GetChild(id);

            return Ok(parent);
        }
    }
}
