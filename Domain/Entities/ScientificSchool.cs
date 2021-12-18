using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ScientificSchool : BaseEntity
    {
        public ApplicationState ApplicationState { get; set; }

        public string Name { get; set; }

        public List<ScientificSchoolDepartment> Departments { get; set; }

        public List<ScientificSchoolBranch> Branches { get; set; }

        public DateTime YearOfFoundation { get; set; }

        public string AnnotatedDescription { get; set; }

        public string Story { get; set; }

        public List<ScientificSchoolLeader> Leaders { get; set; }

        public List<ScientificSchoolFounder> Founders { get; set; }

        public List<ScientificSchoolGraduateStudent> GraduateStudents { get; set; }

        public List<ScientificSchoolMember> Members { get; set; }

        public List<Publication> Publications { get; set; }
    
        public List<Grant> Grants { get; set; }
        
    }
}
