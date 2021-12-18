using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureProjectRealization : BaseEntity
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public DateTime Deadline { get; set; }
    }
}
