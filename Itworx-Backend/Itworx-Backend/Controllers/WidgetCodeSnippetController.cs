using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Itworx_Backend.Service.Interfaces;
using Itworx_Backend.Domain.Entities;
using Newtonsoft.Json;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetCodeSnippetController : ControllerBase
    {
        private readonly IServices<WidgetCodeSnippet> _widgetCodeSnippetService;
        private readonly ItargetFramework<TargetFramework> _targetFrameworkService;
        private readonly Iwidget<Widget> _widgetService;
        public WidgetCodeSnippetController(IServices<WidgetCodeSnippet> widgetCodeSnippetService, 
                ItargetFramework<TargetFramework> targetFrameworkService,
                Iwidget<Widget> widgetService)
        {
            _widgetCodeSnippetService = widgetCodeSnippetService;
            _targetFrameworkService = targetFrameworkService;
            _widgetService = widgetService;
        }

        [HttpPost("create")]
        public IActionResult CreateWidgetCodeSnippet(WidgetCodeSnippet widgetCodeSnippet)
        {
            widgetCodeSnippet.TargetFramework = _targetFrameworkService.Get(widgetCodeSnippet.TargetFramworkId);
            widgetCodeSnippet.Widget = _widgetService.Get(widgetCodeSnippet.widgetId);
            if (widgetCodeSnippet == null || widgetCodeSnippet.CodeSnippet == "")
            {
                return BadRequest("Missing or invalid data");
            }
            Random r = new Random();
            WidgetCodeSnippet Sameid;
            do
            {
                widgetCodeSnippet.Id = r.Next(10000000, 99999999);
                Sameid = _widgetCodeSnippetService.Get((int)widgetCodeSnippet.Id);
            }
            while (Sameid != null);
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
