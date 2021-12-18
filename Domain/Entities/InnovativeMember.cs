using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InnovativeMember : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int InnovativeDevelopmentId { get; set; }
        public InnovativeDevelopment InnovativeDevelopment { get; set; }
    }
}
