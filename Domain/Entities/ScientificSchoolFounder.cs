using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ScientificSchoolFounder : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int ScientificSchoolId { get; set; }
        public ScientificSchool ScientificSchool { get; set; }
    }
}
