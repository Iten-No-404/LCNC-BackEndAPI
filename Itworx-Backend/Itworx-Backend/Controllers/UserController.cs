using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository;
using Itworx_Backend.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserServices<User> _UserService;
        private readonly ApplicationDbContext _applicationDbContext;
        public UserController(IuserServices<User> UserService, ApplicationDbContext applicationDbContext)
        {
            _UserService = UserService;
            _applicationDbContext = applicationDbContext;
        }

        

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var obj = _UserService.Get(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("Signup")]
        public IActionResult Signup(User User)
        {
            if (User != null && User.FullName.Length != 0 && User.Email.Length != 0 && 
                User.PhoneNo.ToString().Length != 0 && User.Password.Length != 0)
            {
                User? old = _UserService.Get(User.Email);
                if(old == null)
                {
                    Random r = new Random();
                    User Sameid;
                    do
                    {
                        User.Id = r.Next(10000000, 99999999);
                        Sameid = _UserService.Get((int)User.Id);
                    }
                    while (Sameid != null);

                    User.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);
                    User.SubscriptionDate = DateTime.Now;
                    User.modifiedTime = DateTime.Now;
                    User.addedData = DateTime.Now;
                    _UserService.Insert(User);
                    return Ok("Created Successfully");
                }
                else
                {
                    return Ok("Please change email as it is already found");
                }
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("Login")]
        public IActionResult Login([FromBody] dynamic body)
        {

            var obj = JsonConvert.DeserializeObject<User>(body.ToString());

            if (obj.Email.Length != 0 && obj.Password.Length != 0)
            {
                User? old = _UserService.Get(obj.Email);
                if (old != null)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(obj.Password, old.Password);
                    if (verified)
                    {
                        return new OkObjectResult(old);
                    }
                    return BadRequest("Password Doesn't match");
                }
                else
                {
                    return Ok("email can't be found");
                }
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser(User User)
        {
            if (User != null)
            {
                User? old = _UserService.Get((int)User.Id);
                if(old != null)
                {
                    User.modifiedTime = DateTime.Now;
                    _UserService.Update(User);
                    return Ok("Updated SuccessFully");
                }
                else
                {
                    return BadRequest("User is not found");
                }
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
                User? old = _UserService.Get(User.FullName);
                if(old != null)
                {
                    _UserService.Delete(User);
                    return Ok("Deleted Successfully");
                }
                return BadRequest("User not found");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
