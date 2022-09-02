using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppTypeController : ControllerBase
    {
        private readonly IappType<AppType> _AppTypeService;
        public AppTypeController(IappType<AppType> AppTypeService)
        {
            _AppTypeService = AppTypeService;
        }

        /// <summary>
        /// Get all actions of Apptype
        /// </summary>
        /// <returns>Array of Apptype if found and 404 not found if not found </returns>

        [HttpGet("All")]

        public IActionResult GetAllActions()
        {
            var obj = _AppTypeService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        [HttpGet("{id}")]

        public IActionResult GetbyID(int id)
        {
            if(id == 0)
                return NotFound();
            var obj = _AppTypeService.Get(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }



        [HttpPost("Add")]
        public IActionResult AddAppType(AppType app) 
        {
            if (app == null || app.type.Length <1)
                return BadRequest("Please enter valid data");
            var old = _AppTypeService.Get(app.type);
            if(old == null)
            {
                _AppTypeService.Insert(app);
                return Ok("Apptype added successfully");
            }
            return BadRequest("The type is already found");
        }


        [HttpGet("GetType")]
        public IActionResult GetType (string type)
        {
            if (type == null)
                return BadRequest("please enter type");
            var old = _AppTypeService.Get(type);
            if (old != null)
            {
                return Ok(old);
            }
            return BadRequest("The type is not found");


        }

    }
}
