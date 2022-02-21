using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldRestrictions
{
    public class SelectRestriction : BaseEntity
    {
        public int MaxCount { get; set; }
        public int MinCount { get; set; }
    }
}
