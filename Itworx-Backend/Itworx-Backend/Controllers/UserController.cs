using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Repository;
using Itworx_Backend.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Itworx_Backend.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Http.Extensions;

namespace Itworx_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IuserServices<User> _UserService;
        public UserController(IConfiguration config, IuserServices<User> UserService)
        {
            _config = config;
            _UserService = UserService;
        }

        /// <summary> get user by id </summary>
        /// <param name="id"> user id that you are searching about</param>
        /// <returns> user that has the same id if ok ; else bad request if there are any error </returns>

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

        /// <summary> get user using token provided as a header </summary>
        /// <returns> user that has the same email of the token if ok ; else bad request if there are any error </returns>

        [HttpGet("GetLoggedInUser")]
        [Authorize]
        public IActionResult GetLoggedInUser()
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

            User loggedInUser = _UserService.Get(userEmail);
            loggedInUser.Password = "";

            return Ok(loggedInUser);
        }

        /// <summary> Sign up new user and hash his password to provide secuirty to the system </summary>
        /// <param name="User"> object of user class which must contain all ot its params </param>
        /// <returns> user that has been created if ok ; else bad request if there are any error </returns>

        [HttpPost("Signup")]
        public IActionResult Signup(User User)
        {
            if (User != null && User.FullName.Length != 0 && User.Email.Length != 0 &&
                User.PhoneNo.ToString().Length != 0 && User.Password.Length != 0)
            {
                User? old = _UserService.Get(User.Email);
                if (old == null)
                {
                    User.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);
                    User.SubscriptionDate = DateTime.Now;
                    User.modifiedTime = DateTime.Now;
                    User.addedData = DateTime.Now;
                    _UserService.Insert(User);

                    SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                    var obj = _UserService.Get(User.Email);

                    Claim[] claims = new[] {
                    new Claim(ClaimTypes.Email, obj.Email),
                    new Claim(ClaimTypes.NameIdentifier, obj.Id.ToString())
                    };

                    JwtSecurityToken securityToken = new(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddDays(5),
                        signingCredentials: credentials
                    );

                    string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

                    return Ok(token);
                    // var obj = _UserService.Get(User.Email);
                    // return Ok(obj);
                    // return Ok("Created Successfully");
                }
                else
                {
                    return BadRequest("Please change email as it is already found");
                }
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        /// <summary>
        /// get user by email and password to provide Auth
        /// </summary>
        /// <param name="userLogin">object of user login class which contain email and password </param>
        /// <returns> user that found if password is matched with the hashed password else bad request </returns>

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (userLogin.Email.Length == 0 || userLogin.Password.Length == 0)
            {
                return BadRequest("Missing email or password");
            }

            User user = _UserService.Get(userLogin.Email);

            if (user != null)
            {
                bool passwordsMatch = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);

                if (!passwordsMatch)
                {
                    return BadRequest("Wrong password");
                }

                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                Claim[] claims = new[] {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                JwtSecurityToken securityToken = new(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: credentials
                );

                string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

                return Ok(token);
            }

            return NotFound("Cannot find user with the given email");
        }

        /// <summary>
        /// update user information
        /// </summary>
        /// <param name="User">object of user class which must contain all ot its params</param>
        /// <returns> user if update is complete else bad request </returns>

        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser(User User)
        {
            if (User != null)
            {
                User? old = _UserService.Get((int)User.Id);
                if (old != null)
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

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="User">object of user class which must contain all ot its params</param>
        /// <returns> Deleted successfully if everything is fine else bad request with a reason </returns>

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(User User)
        {
            if (User != null)
            {
                User? old = _UserService.Get(User.FullName);
                if (old != null)
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
