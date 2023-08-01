using Family.Logic.ChildrenService;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers.ChildrenController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenParentsController : ControllerBase
    {
        private readonly IChildrenService _service;

        public ChildrenParentsController(IChildrenService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetChildrenParents(int id)
        {
            var children = await _service.GetChildrenParents(id);

            return Ok(children);
        }
    }
}
