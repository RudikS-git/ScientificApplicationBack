using Domain.Entities.Base;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Base
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public int ExternalId { get; set; }
        public DateTime FirstActivity { get; set; }
        public DateTime LastActivity { get; set; }

        public List<Application> Applications { get; set; }
        public List<ApplicationSubmission> Submissions { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
