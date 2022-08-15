using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly Iunit<Unit> _UnitService;
        public UnitController(Iunit<Unit> UnitService)
        {
            _UnitService = UnitService;
        }

        [HttpGet("GetAllUnits")]

        public IActionResult GetAllActions()
        {
            var obj = _UnitService.GetAll();
            if(obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpPost("CreateUnit")]
        public IActionResult CreateUnit(Unit unit)
        {
            if (unit != null && unit.UnitName.Length > 0)
            {
                var obj = _UnitService.Get(unit.UnitName);
                if (obj == null)
                {
                    _UnitService.Insert(unit);
                    return Ok("Unit added successfully");
                }
                else
                {
                    return BadRequest("There is a Unit with the same name, Please change the name and try again");
                }
            }
            return BadRequest("Please make sure you have entered everything");
        }

        [HttpGet("GetUnit")]
        public IActionResult GetFramework(string UnitName)
        {
            var obj = _UnitService.Get(UnitName);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpDelete("DeleteUnit")]
        public IActionResult DeleteFramework(string UnitName)
        {
            var obj = _UnitService.Get(UnitName);
            if (obj == null)
            {
                return BadRequest("No Framework with this name found");
            }
            else
            {
                _UnitService.Delete(obj);
                return Ok();
            }
        }


    }
}
