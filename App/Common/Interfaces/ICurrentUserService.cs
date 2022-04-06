using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; set; }
        public string IpAddress { get; set; }
    }
}
