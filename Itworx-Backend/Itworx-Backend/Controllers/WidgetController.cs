using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly IServices<Widget> _WidgetService;
        public WidgetController(IServices<Widget> WidgetService)
        {
            _WidgetService = WidgetService;
        }

        [HttpGet]
        public IActionResult GetWidget()
        {
            return Ok("msg recived");
        }
    }
}
