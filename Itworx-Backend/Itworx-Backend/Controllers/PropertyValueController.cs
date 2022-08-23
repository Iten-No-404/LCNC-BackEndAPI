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
        private readonly IServices<PropertyValue> _PropertyValueService;
        private readonly IServices<Property> _PropertyService;

        public PropertyValueController(IServices<PropertyValue> PropertyValueService,
            IServices<Property> PropertyService)
        {
            _PropertyValueService = PropertyValueService;
            _PropertyService = PropertyService;
        }

        [HttpGet("All")]

        public IActionResult GetAllPropertyUnits()
        {
            var obj = _PropertyValueService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpGet("{id}")]

        public IActionResult GetPropertyUnit(int id)
        {
            var obj = _PropertyValueService.Get(id);
            if (obj == null)
                return BadRequest("not found");
            return Ok(obj);
        }

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
