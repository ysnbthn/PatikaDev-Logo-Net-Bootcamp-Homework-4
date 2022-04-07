using First.API.Models;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace First.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService jwtService;

        public UserController(IJwtService jwtService)
        {
            this.jwtService=jwtService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = new List<string>
            {
                "John Doe",
                "Samet Kayıkcı",
                "Bill Gates"
            };
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserModel model)
        {
            var token = jwtService.Authenticate(
                new UserDto 
                { 
                    Name = model.Name, Password = model.Password }
                );

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
