using Domain.Entities.Base;
using Domain.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.Queries
{
    public class UserInfoResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public PersonName PersonName { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<Role> Roles { get; set; }
    }
}
