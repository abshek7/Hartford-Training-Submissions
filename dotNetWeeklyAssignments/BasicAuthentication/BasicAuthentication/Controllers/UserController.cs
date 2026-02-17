using BasicAuthentication.DTOs;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        // construction injection
        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }
         

        // method for user registration
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var curr = _userContext.Users
                .FirstOrDefault(u => u.Email == user.Email);

            if (curr != null)
            {
                return BadRequest("User already exists");
            }

            var currUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                CreatedOn = DateTime.Now,
                isActive = true
            };

            _userContext.Users.Add(currUser);
            _userContext.SaveChanges();

            return Ok("User reg successful");
        }



        // method for user login 
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validUser = _userContext.Users.FirstOrDefault(u =>
                u.Email == user.Email &&
                u.Password == user.Password &&
                u.isActive == true);

            if (validUser == null)
            {
                return Unauthorized("Invalid Email or Password");
            }

            return Ok(validUser);
        }
    }
}
