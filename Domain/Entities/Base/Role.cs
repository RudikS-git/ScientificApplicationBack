using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class Role : IdentityRole<int>
    {
        public IList<UserRoles> UserRoles { get; set; }

        public Role() { }

        public Role(string name) : base(name)
        {

        }
    }
}
