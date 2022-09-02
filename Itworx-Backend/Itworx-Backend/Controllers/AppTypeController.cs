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
        /// Get all Types of App
        /// </summary>
        /// <returns>Array of App type if found and 404 not found if not found </returns>

        [HttpGet("All")]

        public IActionResult GetAllappTypes()
        {
            var obj = _AppTypeService.GetAll();
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        /// <summary>
        /// to get special app type based on its id
        /// </summary>
        /// <param name="id"> id of the app tybe </param>
        /// <returns> app type based on the id or 404 not found </returns>

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

        /// <summary>
        /// add app type by sending json contain type
        /// </summary>
        /// <param name="app"> class app whuch contain type field </param>
        /// <returns> bad request if any error happen else ok with message apptype added successfully </returns>

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

        /// <summary>
        /// Get app type of certien type
        /// </summary>
        /// <param name="type"> type to search for an apptype with </param>
        /// <returns> ok with the obj if found else bad request </returns>

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
