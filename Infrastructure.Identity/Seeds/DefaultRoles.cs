using Domain.Entities.Base;
using Domain.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role(RolesEnum.Admin.ToString()));
            await roleManager.CreateAsync(new Role(RolesEnum.Moderator.ToString()));
            await roleManager.CreateAsync(new Role(RolesEnum.User.ToString()));
        }
    }
}
