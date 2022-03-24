using Domain.Entities.Base;
using Domain.Entities.Common;
using Domain.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base
{
    public class User : IdentityUser<int>
    {
        public PersonName PersonName { get; set; }

        public DateOnly BirthDate { get; set; }

        public IList<Application> Applications { get; set; }

        public IList<ApplicationSubmission> Submissions { get; set; }

        public IList<Permission> Permissions { get; set; }

        public IList<RefreshToken> RefreshTokens { get; set; }
    }
}
