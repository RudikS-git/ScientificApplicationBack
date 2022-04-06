using Domain.Entities.Base;
using Domain.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.DTOs
{
    public class UserDto
    {
        public PersonName PersonName { get; set; }

        public DateOnly BirthDate { get; set; }

        public IList<Permission> Permissions { get; set; }
    }
}
