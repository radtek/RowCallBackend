using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; 

        public UsersController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager; 
        }


        /// <summary>
        /// Returns all users ever created
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<object> GetAll()
        {
            return _dbContext.Users;
        }

        /// <summary>
        /// Returns a single user by string id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id); 
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Creates a user with a random email and username. The password is always password123
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var random = new Random(); 
            var randomNumber = random.Next(0, 1000000);
            var user = new ApplicationUser() { UserName = "username" + randomNumber, Email = "useremail@user" + randomNumber + ".dk" };
            var result = await _userManager.CreateAsync(user, "password123");
            if (result.Succeeded)
                return Ok(user);
            else
                return NotFound(); 
        }
    }
}
