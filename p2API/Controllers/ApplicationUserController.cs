using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using Microsoft.Extensions.Options;
using Models.ViewModels;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace p2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<LoginInfo> _userManager;
        private readonly SignInManager<LoginInfo> _singInManager;
        private readonly IConfiguration _appSettings;

        public ApplicationUserController(UserManager<LoginInfo> userManager, SignInManager<LoginInfo> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = configuration.GetSection("ApplicationSettings");
        }

        [HttpPost]
        [Route("Register")]
        
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(LoginInfoVM model)
        {
            var applicationUser = new LoginInfo()
            {
                AccountType = model.AccountType,
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.Firstname,
                LastName = model.Lastname
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  

        [HttpGet]
        [Route("Profile")]
        //GET : /api/ApplicationUser/Profile
        public async Task<Object> GetCurrentUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.AccountType,
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName
            };
        }




        [HttpGet("{username}")]
       
        //GET : /api/ApplicationUser/{email}
        public async Task<Object> GetUserProfile(string username)
        {
            
            var user = await _userManager.FindByNameAsync(username);
            return new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName,
                user.AccountType
            };
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings["JWT_Secret"])), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }


    }
}


