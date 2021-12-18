using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureSpecialist : BaseEntity
    {
        public string FullName { get; set; }

        public string WorkingConditions { get; set; }

        public string PrimaryFunctions { get; set; }

        public string EducationDescription { get; set; }
    }
}
