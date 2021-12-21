using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Identity;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(userDto.UserName);
            if (user is null)
            {
                return NotFound(); // if user is not found 
            }
            bool result = await _userManager.CheckPasswordAsync(user, userDto.Password);

            if (!result)
            {
                return Ok(new { result = false });
            }

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Csun590MS#cretKey"));
            SigningCredentials signingCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokenOptions = new(
                "http://localhost:5000",
                "http://localhost:5000",
                new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCred
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });

        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string UserName, string Password)
        {
            ApplicationUser user = new()
            {
                UserName = UserName,
                Email = $"{UserName}@gmail.com",
                EmailConfirmed = true
            };
            //var result = await _userManager.CreateAsync(user, Password); or
            IdentityResult result = await _userManager.CreateAsync(user, Password);
            return Ok(result);
        }


        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout(UserDto userDto)
        {
            string tokenString = "";
            return Ok(new { Token = tokenString });
        }

    }


    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
