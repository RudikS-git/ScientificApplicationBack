using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureResearcher : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int InfrastructureProjectId { get; set; }
        public InfrastructureProject InfrastructureProject { get; set; }
    }
}
