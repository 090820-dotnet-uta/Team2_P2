using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.ViewModels;

namespace p2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<LoginInfo> _userManager;
        private readonly SignInManager<LoginInfo> _singInManager;

        public ApplicationUserController(UserManager<LoginInfo> userManager, SignInManager<LoginInfo> signInManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(LoginInfoVM model)
        {
            var applicationUser = new LoginInfo()
            {
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
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName
            };
        }


        [HttpGet("{email}")]
        [Route("Profile{email}")]
        //GET : /api/ApplicationUser/Profile/{email}
        public async Task<Object> GetUserProfile(string email)
        {
            
            var user = await _userManager.FindByEmailAsync(email);
            return new
            {
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName
            };
        }

    }
}


