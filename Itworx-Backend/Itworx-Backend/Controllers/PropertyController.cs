using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IServices<Property> _PropertyService;
        private readonly IPropertyValue<PropertyValue> _PropertyValueService;

        public PropertyController(IServices<Property> PropertyService,
            IPropertyValue<PropertyValue> PropertyValueService)
        {
            _PropertyService = PropertyService;
            _PropertyValueService = PropertyValueService;
        }

        [HttpGet("All")]

        public IActionResult GetAllProperty()
        {
            var obj = _PropertyService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpGet("{id}")]

        public IActionResult GetProperty(int id)
        {
            var obj = _PropertyService.Get(id);
            obj.PropertyValue = _PropertyValueService.GetProperty(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpPost("Add")]

        public IActionResult AddProperty(Property prop)
        {
            if (prop == null || prop.Description.Length == 0)
            {
                return BadRequest("make sure you have entered everything correct");
            }

            prop.ParentProperty =  prop.parentID.ToString().Length == 0 ?  null : _PropertyService.Get(prop.parentID);
            _PropertyService.Insert(prop);
            return Ok("Created Successfully");

        }


    }
}
