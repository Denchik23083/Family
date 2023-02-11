using System.Threading.Tasks;
using Family.Logic.ChildrenService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsChildrenController : ControllerBase
    {
        private readonly IChildrenService _service;

        public ParentsChildrenController(IChildrenService service)
        {
            _service = service;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetChildren(int id)
        {
            var children = await _service.GetChildren(id);

            return Ok(children);
        }
    }
}
