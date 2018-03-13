using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.AccountViewModels;

namespace WebApplication2.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Get the Json format for the Create body
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFormat()
        {
            var vm = new CreateViewModel() { Password = "password", Email = "email", Username = "username" }; 
            return Json(vm); 
        }

        /// <summary>
        /// Creates user. The params is read from the request body
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Should return either login-token or cookie which the client should save. 
                    return Ok(user); 
                }
                return Json("Already a user with this username/email"); 
            }
            return StatusCode(500); 
        }



    }
}
