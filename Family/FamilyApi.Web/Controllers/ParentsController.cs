using Family.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Family.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService _service;

        public ParentsController(IParentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllParents()
        {
            var parents = _service.GetAllParents();
            
            return Ok(parents);
        }
    }
}
