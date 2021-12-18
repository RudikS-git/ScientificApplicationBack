using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InnovativeBranch : BaseEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int InnovativeDevelopmentId { get; set; }
        public InnovativeDevelopment InnovativeDevelopment { get; set; }
    }
}
