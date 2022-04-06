using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateJwtSecurityToken(User user, IList<string> roles);
        RefreshToken CreateJwtRefreshToken(string ip);
    }
}
