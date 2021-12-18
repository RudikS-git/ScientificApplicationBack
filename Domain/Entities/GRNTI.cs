using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class GRNTI : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
