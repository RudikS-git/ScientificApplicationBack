using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ScientificSchoolDepartment : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int ScientificSchoolId { get; set; }
        public ScientificSchool ScientificSchool { get; set; }
    }
}
