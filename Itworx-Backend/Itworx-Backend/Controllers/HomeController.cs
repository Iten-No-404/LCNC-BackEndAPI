using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello and welcom to LCNC Design Tool Web API!");
        }
    }
}
