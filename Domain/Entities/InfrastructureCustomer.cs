using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureCustomer : BaseEntity
    {
        public string Name { get; set; }
        public string Contract { get; set; }
        public string Subject { get; set; }
        public string Sum { get; set; }
        public DateTime Deadline { get; set; }
    }
}
