using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyValueController : ControllerBase
    {
        private readonly IPropertyValue<PropertyValue> _PropertyValueService;
        private readonly IServices<Property> _PropertyService;

        public PropertyValueController(IPropertyValue<PropertyValue> PropertyValueService,
            IServices<Property> PropertyService)
        {
            _PropertyValueService = PropertyValueService;
            _PropertyService = PropertyService;
        }

        /// <summary>
        /// Get all Properties value
        /// </summary>
        /// <returns>Array of Property value if found and 404 not found if not found </returns>

        [HttpGet("All")]

        public IActionResult GetAllPropertyUnits()
        {
            var obj = _PropertyValueService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        /// <summary> get property value by id </summary>
        /// <param name="id"> property value id that you are searching about</param>
        /// <returns> property that has the same id if ok ; else bad request if there are any error </returns>

        [HttpGet("{id}")]

        public IActionResult GetPropertyUnit(int id)
        {
            var obj = _PropertyValueService.Get(id);
            if (obj == null)
                return BadRequest("not found");
            return Ok(obj);
        }

        /// <summary>
        /// Add new property value and link with its property
        /// </summary>
        /// <param name="propertyValue">object of property value class which must contain all ot its params</param>
        /// <returns> Property value that has been created </returns>


        [HttpPost("Add")]

        public IActionResult CreatePropertyUnit(PropertyValue propertyValue)
        {
            if (propertyValue == null || propertyValue.Value.Length ==0)
                return BadRequest("Make sure you have entered everything correct");
            propertyValue.Property = _PropertyService.Get(propertyValue.propertyID);
            _PropertyValueService.Insert(propertyValue);
            return Ok(propertyValue);
        }

    }
}
