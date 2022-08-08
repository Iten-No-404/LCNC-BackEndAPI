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

        [HttpPost("CreateFramework")]
        public IActionResult CreateFramework(TargetFramework Framework)
        {
            if(Framework != null && Framework.FrameworkName.Length > 0)
            {
                var obj = _TargetFrameworkService.Get(Framework.FrameworkName);
                if (obj == null)
                {
                    Random r = new Random();
                    TargetFramework Sameid;
                    do
                    {
                        Framework.Id = r.Next(10000000, 99999999);
                        Sameid = _TargetFrameworkService.Get((int)Framework.Id);
                    }
                    while (Sameid != null);

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
