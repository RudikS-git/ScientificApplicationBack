using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureResearch : BaseEntity
    {
        public InfrastructureResearcher Researcher { get; set; }

        public string Contract { get; set; }

        public string Subject { get; set; }

        public ResearchDirection ResearchDirection { get; set; }

        public string Name { get; set; }
    }
}
