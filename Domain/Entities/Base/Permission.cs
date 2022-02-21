using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; } 
        public string SystemName { get; set; }
        public List<User> Users { get; set; }
    }
}
