using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldRestrictions
{
    public class InputRestriction : BaseEntity
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
    }
}
