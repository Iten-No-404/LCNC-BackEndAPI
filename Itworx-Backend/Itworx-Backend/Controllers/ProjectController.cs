using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult getProject(int id)
        {
            var obj = _ProjectService.Get(id);
            if (obj != null)
                return Ok(obj);
            return BadRequest("project not found");
        }

        [HttpGet("user/{userID}")]

        public IActionResult getProjectbyUser(int userID)
        {
            var obj = _ProjectService.GetbyUserID(userID);
            if (obj != null)
                return Ok(obj);
            return BadRequest("project not found");
        }


        [HttpPost("Add")]

        public IActionResult addProject(Project project)
        {
            if (project != null && project.Title.Length != 0 && project.Description.Length != 0)
            {
                project.AppType = _AppTypeService.Get(project.AppTypeId);
                project.User = _UserService.Get(project.user_Id);
                project.TargetFramework = _TargetFrameworkService.Get(project.targetFramework_Id);
                _ProjectService.Insert(project);
                return Ok("Inserted Successfully");
            }
            return BadRequest("Make sure you have entered everything correctly");
        }
         
    }
}
