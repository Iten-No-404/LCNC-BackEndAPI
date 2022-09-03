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

        /// <summary>
        /// Get all widget properties
        /// </summary>
        /// <returns>Array of widget properties if found and 404 not found if not found </returns>


        [HttpGet("All")]

        public IActionResult GetAllWidgetProperties()
        {
            var obj = _WidgetPropertyService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        /// <summary> get widget property by id </summary>
        /// <param name="id"> widget property id that you are searching about</param>
        /// <returns> widget property that has the same id if ok ; else bad request if there are any error </returns>


        [HttpGet("{id}")]

        public IActionResult GetWidgetProperty(int id)
        {
            var obj = _WidgetPropertyService.Get(id);
            if (obj == null)
                return BadRequest("not found");
            return Ok(obj);
        }

        /// <summary>
        /// Add new widget property and link it with its widget and its property
        /// </summary>
        /// <param name="widgetProperty">object of widget property class which must contain all ot its params</param>
        /// <returns> widget property that has been created </returns>

        [HttpPost("Add")]

        public IActionResult Createwidgetproperty(WidgetProperty widgetProperty)
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
