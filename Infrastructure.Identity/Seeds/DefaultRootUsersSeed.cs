using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public class DefaultRootUsersSeed
    {
        public static async Task SeedAsync()
        {
            var user = new User
            {
                Email = "test123@gmail.com",
                PersonName = new Domain.Entities.Complex.PersonName
                {
                    FirstName = "Test",
                    LastName =  "Test",
                    Patronymic = "Test"
                }
            };
        }
    }
}
