using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository;
using Itworx_Backend.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServices<User> _UserService;
        private readonly ApplicationDbContext _applicationDbContext;
        public UserController(IServices<User> UserService, ApplicationDbContext applicationDbContext)
        {
            _UserService = UserService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetUserById))]
        public IActionResult GetUserById(int Id)
        {
            var obj = _UserService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllUser))]
        public IActionResult GetAllUser()
        {
            var obj = _UserService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateUser))]
        public IActionResult CreateUser(User User)
        {
            if (User != null)
            {
                _UserService.Insert(User);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser(User User)
        {
            if (User != null)
            {
                _UserService.Update(User);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(User User)
        {
            if (User != null)
            {
                _UserService.Delete(User);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
