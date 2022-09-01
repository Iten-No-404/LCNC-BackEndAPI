﻿using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]

        public IActionResult getWidget(int id)
        {
            var widget = _WidgetService.Get(id);
            widget.WidgetCodeSnippet = _widgetCodeSnippetService.GetSnippet(id);
            if (widget != null)
                return Ok(widget);
            return BadRequest("widget not found");
        }

        [HttpPost("Add")]

        public IActionResult addWidget(Widget widget)
        {
            if (widget != null && widget.text.Length != 0 && widget.description.Length !=0)
            {

                widget.IsOnlyNested = widget.IsOnlyNested? widget.IsOnlyNested : false;
                widget.RelatedAppType = _AppTypeService.Get(widget.AppTypeID);
                _WidgetService.Insert(widget);
                return Ok("Inserted Successfully");
            }
            return BadRequest("Make sure you have entered everything correctly");
        }

        [HttpGet("All")]

        public IActionResult GetAllWidgets()
        {
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


        [HttpGet]

        public IActionResult GetWidgetbyName(string title)
        {
            if(title.Length != 0)
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
