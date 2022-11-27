using ClaimUserService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ClaimUserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors ("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UserDbContext _Context;

        public UserController(IConfiguration config, UserDbContext context)
        {
            _config = config;
            _Context = context;
        }

        [HttpGet]
        public List<User> get()
        {
            return _Context.Users.ToList();
        }


        [HttpPost ("CreateUser")]
        public IActionResult Create(User user)
        {
            if (_Context.Users.FirstOrDefault(x => x.Email == user.Email) != null)
            {
                return BadRequest();
            }
            user.Role = 1;
            _Context.Users.Add (user);
            _Context.SaveChanges();
            return Ok(user);
        }




        [HttpPost("LoginUser")]
        public IActionResult login(login userlogin)
        {
            IActionResult response= Unauthorized();
           
            if(userlogin==null)
            {
                return BadRequest();
            }
             else if (_Context.Users.FirstOrDefault(x => x.Email == userlogin.Email && x.Password == userlogin.Password)!= null)
            {
                var obj = _Context.Users.FirstOrDefault(x => x.Email == userlogin.Email);
               
                return Ok(obj);
                //return response;
            }
            else {
                //return Ok("failer");
                return NotFound();
            }
            
        }
    }
}
