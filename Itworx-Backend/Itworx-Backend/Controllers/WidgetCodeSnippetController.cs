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
        private readonly ICodeSnippet<WidgetCodeSnippet> _widgetCodeSnippetService;
        private readonly ItargetFramework<TargetFramework> _targetFrameworkService;
        private readonly Iwidget<Widget> _widgetService;
        public WidgetCodeSnippetController(ICodeSnippet<WidgetCodeSnippet> widgetCodeSnippetService, 
                ItargetFramework<TargetFramework> targetFrameworkService,
                Iwidget<Widget> widgetService)
        {
            _widgetCodeSnippetService = widgetCodeSnippetService;
            _targetFrameworkService = targetFrameworkService;
            _widgetService = widgetService;
        }

        /// <summary>
        /// Add new widget code snippet and link it with target framework and its widget
        /// </summary>
        /// <param name="widgetCodeSnippet">object of Widget code snippet class which must contain all ot its params</param>
        /// <returns> created succeffully if everything is fine </returns>


        [HttpPost("create")]
        public IActionResult CreateWidgetCodeSnippet(WidgetCodeSnippet widgetCodeSnippet)
        {
            widgetCodeSnippet.TargetFramework = _targetFrameworkService.Get(widgetCodeSnippet.TargetFramworkId);
            widgetCodeSnippet.Widget = _widgetService.Get(widgetCodeSnippet.widgetId);
            if (widgetCodeSnippet == null || widgetCodeSnippet.code1 == "")
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
        /// <summary> get all widgetcodesnippets </summary>
        /// <returns> array of widget code snippet if ok ; else bad request if there are any error </returns>


        [HttpGet("")]
        public IActionResult GetAllWidgetCodeSnippets()
        {
            IEnumerable<WidgetCodeSnippet> widgetCodeSnippets = _widgetCodeSnippetService.GetAll();
            return Ok(widgetCodeSnippets);
        }

        /// <summary> get widget code snippet by id </summary>
        /// <param name="id"> widget code snippet id that you are searching about</param>
        /// <returns> widget code snippet that has the same id if ok ; else bad request if there are any error </returns>

        [HttpGet("{id}")]
        public IActionResult GetWidgetCodeSnippetById(int id)
        {
            WidgetCodeSnippet widgetCodeSnippet = _widgetCodeSnippetService.Get(id);
            return Ok(widgetCodeSnippet);
        }
    }
}
