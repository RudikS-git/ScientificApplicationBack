using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureServiceProvided : BaseEntity
    {
        public PriorityDirection PriorityDirection { get; set; }

        public string PriorityDirectionNTRRF { get; set; }

        public string ShortDescription { get; set; }
    }
}
