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

        /// <summary>
        /// get project by id but you first have to be logged in 
        /// so you are authroized to perform this function
        /// </summary>
        /// <param name="id"> project id that you are searching about</param>
        /// <returns> project that has the same id if ok ; else if not authorized return unauthorized "you have to be logged in" else bad request if there are any error </returns>

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

        /// <summary>
        /// Get all projects that have the same user Id so we can have all the projects done by the same user
        /// </summary>
        /// <param name="userID"> user id that searching </param>
        /// <returns> array of projects that have the same user id else unauthorized if not logged in else bad request </returns>

        [HttpGet("user/{userID}")]
        [Authorize]
        public IActionResult GetProjectbyUser(int userID)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
            {
                return Unauthorized("You have to be logged in");
            }

            string? userId = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest("Invalid token");
            }

            var obj = _ProjectService.GetbyUserID(Convert.ToInt32(userId));
            if (obj != null)
                return Ok(obj);
            return BadRequest("project not found");
        }

        /// <summary>
        /// Add new project to the user and link app type , target framework , user to this project
        /// </summary>
        /// <param name="project">object of project class which must contain title and description and app path </param>
        /// <returns> project that has been created </returns>

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

        /// <summary>
        /// update project for adding widgets or update it
        /// </summary>
        /// <param name="project"> object of project class contain modified project </param>
        /// <returns> project if no error else unauth if not logged in else bad request if any error happened  </returns>

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
