using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Patent : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
