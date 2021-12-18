using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ScientificSchoolMember : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int ScientificSchoolId { get; set; }
        public ScientificSchool ScientificSchool { get; set; }
    }
}
