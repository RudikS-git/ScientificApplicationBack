using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ScientificSchoolBranch : BaseEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int ScientificSchoolId { get; set; }
        public ScientificSchool ScientificSchool { get; set; }
    }
}
