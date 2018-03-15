using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public static class SeedUser
    {
        public static void InitDb(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var userArray = new ApplicationUser[50];
                for (int i = 0; i < 50; i++)
                {
                    userArray[i] = new ApplicationUser()
                    {
                        Id = i.ToString(),
                        Email = "user" + i + "@user.com",
                        NormalizedEmail = "USER" + i + "@USER.COM",
                        UserName = "user" + i,
                        NormalizedUserName = "USER" + i,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString("D"),
                    };
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(userArray[i], "test123");
                    userArray[i].PasswordHash = hashed;
                    dbContext.Users.Add(userArray[i]);
                    dbContext.SaveChanges();
                }

                
            }
        }
    }
}
