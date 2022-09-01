using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IuserServices<User> _UserService;
        private readonly IappType<AppType> _AppTypeService;
        private readonly ItargetFramework<TargetFramework> _TargetFrameworkService;
        private readonly Iproject<Project> _ProjectService;


        public ProjectController(IuserServices<User> UserService, IappType<AppType> AppTypeService,
            ItargetFramework<TargetFramework> TargetFrameworkService, Iproject<Project> ProjectService)
        {
            _ProjectService = ProjectService;
            _UserService = UserService;
            _AppTypeService = AppTypeService;
            _TargetFrameworkService = TargetFrameworkService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetProject(int id)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            var obj = _ProjectService.Get(id);
            if (obj != null)
                return Ok(obj);
            return BadRequest("project not found");
        }

        [HttpGet("user/{userID}")]
        [Authorize]
        public IActionResult GetProjectbyUser(int userID)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? id = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

            if (id == null)
            {
                return BadRequest("Invalid token");
            }

            var obj = _ProjectService.GetbyUserID(Convert.ToInt32(id));
            if (obj != null)
                return Ok(obj);
            return BadRequest("project not found");
        }


        [HttpPost("Add")]
        [Authorize]
        public IActionResult AddProject(Project project)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            if (project != null && project.Title.Length != 0 && project.Description.Length != 0)
            {
                project.AppType = _AppTypeService.Get(project.AppTypeId);
                project.User = _UserService.Get(userEmail);
                project.TargetFramework = _TargetFrameworkService.Get(project.targetFramework_Id);
                _ProjectService.Insert(project);
                return Ok(project);
                // return Ok("Inserted Successfully");
            }
            return BadRequest("Make sure you have entered everything correctly");
        }

        [HttpPut("Update")]
        [Authorize]
        public IActionResult UpdateProject(Project project)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userEmail = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;

            if (userEmail == null)
            {
                return BadRequest("Invalid token");
            }

            if (project != null && project.Title.Length != 0 && project.Description.Length != 0)
            {
                _ProjectService.Update(project);
                return Ok(project);
            }
            return BadRequest("Make sure you have entered everything correctly");
        }
    }
}
