using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
