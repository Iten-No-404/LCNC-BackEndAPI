using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Itworx_Backend.Service.Interfaces;
using Itworx_Backend.Domain.Entities;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetCodeSnippetController : ControllerBase
    {
        private readonly IServices<WidgetCodeSnippet> _widgetCodeSnippetService;
        public WidgetCodeSnippetController(IServices<WidgetCodeSnippet> widgetCodeSnippetService)
        {
            _widgetCodeSnippetService = widgetCodeSnippetService;

        }

        [HttpPost("create")]
        public IActionResult CreateWidgetCodeSnippet(WidgetCodeSnippet widgetCodeSnippet)
        {
            if (widgetCodeSnippet == null || widgetCodeSnippet.TargetFramework == null || widgetCodeSnippet.CodeSnippet == "")
            {
                return BadRequest("Missing or invalid data");
            }

            widgetCodeSnippet.modifiedTime = DateTime.Now;
            widgetCodeSnippet.addedData = DateTime.Now;
            _widgetCodeSnippetService.Insert(widgetCodeSnippet);
            return Ok("Created Successfully");
        }

        [HttpGet("")]
        public IActionResult GetAllWidgetCodeSnippets()
        {
            IEnumerable<WidgetCodeSnippet> widgetCodeSnippets = _widgetCodeSnippetService.GetAll();
            return Ok(widgetCodeSnippets);
        }

        [HttpGet("{id}")]
        public IActionResult GetWidgetCodeSnippetById(int id)
        {
            WidgetCodeSnippet widgetCodeSnippet = _widgetCodeSnippetService.Get(id);
            return Ok(widgetCodeSnippet);
        }
    }
}
