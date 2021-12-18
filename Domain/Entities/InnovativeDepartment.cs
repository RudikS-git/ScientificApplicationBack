using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InnovativeDepartment : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int InnovativeDevelopmentId { get; set; }
        public InnovativeDevelopment InnovativeDevelopment { get; set; }
    }
}
