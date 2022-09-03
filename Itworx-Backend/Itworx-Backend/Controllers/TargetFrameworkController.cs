using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Itworx_Backend.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetFrameworkController : ControllerBase
    {
        private readonly ItargetFramework<TargetFramework> _TargetFrameworkService;
        public TargetFrameworkController(ItargetFramework<TargetFramework> TargetFrameworkService)
        {
            _TargetFrameworkService = TargetFrameworkService;
        }

        /// <summary>
        /// Add new target framework
        /// </summary>
        /// <param name="Framework">object of target framework class which must contain all ot its params</param>
        /// <returns> Ok if everything is fine else bad request which contain the reason </returns>


        [HttpPost("CreateFramework")]
        public IActionResult CreateFramework(TargetFramework Framework)
        {
            if(Framework != null && Framework.FrameworkName.Length > 0)
            {
                var obj = _TargetFrameworkService.Get(Framework.FrameworkName);
                if (obj == null)
                {
                    _TargetFrameworkService.Insert(Framework);
                    return Ok("Target Framework added successfully");
                }
                else
                {
                    return BadRequest("There is a framework with the same name, Please change the name and try again");
                }
            }
            return BadRequest("Please make sure you have entered everything");
        }

        /// <summary> get target framework by its name </summary>
        /// <param name="FrameworkName"> target framework name that you are searching about</param>
        /// <returns> target framework that has the same name if ok ; else bad request if there are any error </returns>


        [HttpGet("GetFramework")]
        public IActionResult GetFramework(string FrameworkName)
        {
            var obj = _TargetFrameworkService.Get(FrameworkName);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        /// <summary> delete target framework by its name </summary>
        /// <param name="FrameworkName"> target framework name that you are searching about</param>
        /// <returns> ok if everything is fine ; else bad request if there are any error </returns>

        [HttpDelete("DeleteFramework")]
        public IActionResult DeleteFramework(string FrameworkName)
        {
            var obj = _TargetFrameworkService.Get(FrameworkName);
            if (obj == null)
            {
                return BadRequest("No Framework with this name found");
            }
            else
            {
                _TargetFrameworkService.Delete(obj);
                return Ok();
            }
        }





    }
}
