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

        /// <summary>
        /// Get all unit
        /// </summary>
        /// <returns> Array of units if found and 404 not found if not found </returns>

        [HttpGet("GetAllUnits")]

        public IActionResult GetAllActions()
        {
            var obj = _UnitService.GetAll();
            if(obj == null)
                return NotFound();
            return Ok(obj);
        }

        /// <summary>
        /// Add new unit
        /// </summary>
        /// <param name="unit">object of unit class which must contain all ot its params</param>
        /// <returns> unit that has been created </returns>


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

        /// <summary> get property unit by name </summary>
        /// <param name="UnitName"> unit name that you are searching about</param>
        /// <returns> unit that has the same id if ok ; else bad request if there are any error </returns>

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
        /// <summary> delete unit by name </summary>
        /// <param name="id"> unit name that you are searching about</param>
        /// <returns> ok if no error ; else bad request if there are any error </returns>


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
