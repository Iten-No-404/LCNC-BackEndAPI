using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetPropertyController : ControllerBase
    {
        private readonly IServices<WidgetProperty> _WidgetPropertyService;
        private readonly IServices<Property> _PropertyService;
        private readonly Iwidget<Widget> _WidgetService;

        public WidgetPropertyController(IServices<WidgetProperty> WidgetPropertyService,
            IServices<Property> PropertyService, Iwidget<Widget> WidgetService)
        {
            _WidgetPropertyService = WidgetPropertyService;
            _PropertyService = PropertyService;
            _WidgetService = WidgetService;
        }

        [HttpGet("All")]

        public IActionResult GetAllPropertyUnits()
        {
            var obj = _WidgetPropertyService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpGet("{id}")]

        public IActionResult GetPropertyUnit(int id)
        {
            var obj = _WidgetPropertyService.Get(id);
            if (obj == null)
                return BadRequest("not found");
            return Ok(obj);
        }

        [HttpPost("Add")]

        public IActionResult CreatePropertyUnit(WidgetProperty widgetProperty)
        {
            if (widgetProperty == null)
                return BadRequest("Make sure you have entered everything correct");
            widgetProperty.property = _PropertyService.Get(widgetProperty.propertyID);
            widgetProperty.widget = _WidgetService.Get(widgetProperty.widgetId);
            _WidgetPropertyService.Insert(widgetProperty);
            return Ok(widgetProperty);
        }
    }
}
