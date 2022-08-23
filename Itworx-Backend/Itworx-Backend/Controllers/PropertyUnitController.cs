using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyUnitController : ControllerBase
    {
        private readonly IServices<PropertyUnit> _PropertyUnitService;
        private readonly IServices<Property> _PropertyService;
        private readonly Iunit<Unit> _UnitService;

        public PropertyUnitController(IServices<PropertyUnit> PropertyUnitService,
            IServices<Property> PropertyService, Iunit<Unit> UnitService)
        {
            _PropertyUnitService = PropertyUnitService;
            _PropertyService = PropertyService;
            _UnitService = UnitService;
        }

        [HttpGet("All")]

        public IActionResult GetAllPropertyUnits()
        {
            var obj = _PropertyUnitService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpGet("{id}")]

        public IActionResult GetPropertyUnit(int id)
        {
            var obj = _PropertyUnitService.Get(id);
            if (obj == null)
                return BadRequest("not found");
            return Ok(obj);
        }

        [HttpPost("Add")]

        public IActionResult CreatePropertyUnit(PropertyUnit propertyUnit)
        {
            if (propertyUnit == null)
                return BadRequest("Make sure you have entered everything correct");
            propertyUnit.Property = _PropertyService.Get(propertyUnit.propertyID);
            propertyUnit.Unit = _UnitService.Get(propertyUnit.unitID);
            _PropertyUnitService.Insert(propertyUnit);
            return Ok(propertyUnit);
        }
    }
}
