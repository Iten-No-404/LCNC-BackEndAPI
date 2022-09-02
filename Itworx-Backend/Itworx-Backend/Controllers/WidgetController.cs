using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetController : ControllerBase
    {
        private readonly Iwidget<Widget> _WidgetService;
        private readonly IappType<AppType> _AppTypeService;
        private readonly ICodeSnippet<WidgetCodeSnippet> _widgetCodeSnippetService;

        public WidgetController(Iwidget<Widget> WidgetService, IappType<AppType> AppTypeService,
                     ICodeSnippet<WidgetCodeSnippet> widgetCodeSnippetService)
        {
            _WidgetService = WidgetService;
            _AppTypeService = AppTypeService;
            _widgetCodeSnippetService = widgetCodeSnippetService;
        }

        /// <summary> get widget by id </summary>
        /// <param name="id"> widget id that you are searching about but you must be authorized first </param>
        /// <returns> widget that has the same id if ok ; else bad request if there are any error </returns>

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetWidget(int id)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            var widget = _WidgetService.Get(id);
            widget.WidgetCodeSnippet = _widgetCodeSnippetService.GetSnippet(id);
            if (widget != null)
                return Ok(widget);
            return BadRequest("widget not found");
        }

        /// <summary>
        /// Add new widget
        /// </summary>
        /// <param name="widget">object of widget class which must contain all ot its params</param>
        /// <returns> inserted successfully if everything is fine</returns>

        [HttpPost("Add")]
        [Authorize]
        public IActionResult AddWidget(Widget widget)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            if (widget != null && widget.text.Length != 0 && widget.description.Length !=0)
            {
                widget.IsOnlyNested = widget.IsOnlyNested? widget.IsOnlyNested : false;
                widget.RelatedAppType = _AppTypeService.Get(widget.AppTypeID);
                _WidgetService.Insert(widget);
                return Ok("Inserted Successfully");
            }
            return BadRequest("Make sure you have entered everything correctly");
        }

        /// <summary>
        /// Get all widgets
        /// </summary>
        /// <returns>Array of widgets if found and 404 not found if not found </returns>

        [HttpGet("All")]
        [Authorize]
        public IActionResult GetAllWidgets()
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            var items = _WidgetService.GetAll();
            if (items != null)
            {
                foreach (var item in items)
                {
                    item.WidgetCodeSnippet = _widgetCodeSnippetService.GetSnippet((int)item.Id);
                }
                return Ok(items);
            }
            return BadRequest(" There are no widget yet");
        }

        /// <summary>
        /// get widget by its title
        /// </summary>
        /// <param name="title"> title of the widget that you are searching </param>
        /// <returns> widget if found and unAuthroized if not logged in and bad request if there is an error </returns>

        [HttpGet]
        [Authorize]
        public IActionResult GetWidgetbyName(string title)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            if (title.Length != 0)
            {
                var obj = _WidgetService.GetWidget(title);
                if (obj != null)
                    return Ok(obj);
                return BadRequest("Not found make sure you have entered title correct");
            }
            return NotFound();
        }
    }
}
