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

        /// <summary>
        /// Get all Properties unit
        /// </summary>
        /// <returns>Array of Property unit if found and 404 not found if not found </returns>


        [HttpGet("All")]

        public IActionResult GetAllPropertyUnits()
        {
            var obj = _PropertyUnitService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        /// <summary> get property unit by id </summary>
        /// <param name="id"> property unit id that you are searching about</param>
        /// <returns> property unit that has the same id if ok ; else bad request if there are any error </returns>

        [HttpGet("{id}")]

        public IActionResult GetPropertyUnit(int id)
        {
            var obj = _PropertyUnitService.Get(id);
            if (obj == null)
                return BadRequest("not found");
            return Ok(obj);
        }

        /// <summary>
        /// Add new property unit and link between property and unit
        /// </summary>
        /// <param name="propertyUnit">object of property unit class which must contain all ot its params</param>
        /// <returns> Property unit that has been created </returns>


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
