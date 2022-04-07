using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Users.DTOs
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
