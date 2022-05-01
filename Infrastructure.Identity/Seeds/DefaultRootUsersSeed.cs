using Domain.Entities.Base;
using Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public class DefaultRootUsersSeed
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            var existingUser = await userManager.FindByEmailAsync("admin@gmail.com");

            if (existingUser != null)
                return;

            var user = new User
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                PersonName = new Domain.Entities.Complex.PersonName
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Patronymic = "Admin"
                },
            };

            var result = await userManager.CreateAsync(user, "admin123");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, RolesEnum.Admin.ToString());
                await userManager.AddToRoleAsync(user, RolesEnum.User.ToString());
                await userManager.AddToRoleAsync(user, RolesEnum.Moderator.ToString());
            }
            else
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}
