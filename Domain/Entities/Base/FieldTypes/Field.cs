using Domain.Entities.Common;
using Domain.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public abstract class Field : BaseEntity
    {
        public int ApplicationGroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }

        public bool IsRequired { get; set; }
        public string Label { get; set; }
        public string SystemName { get; set; }
        public string Description { get; set; }

        public FieldStyle Style { get; set; }
    }
}
