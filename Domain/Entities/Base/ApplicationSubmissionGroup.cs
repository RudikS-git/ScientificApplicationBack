using Domain.Entities.Base.FieldSubmissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class ApplicationSubmissionGroup
    {
        public int ApplicationGroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }

        public List<InputSubmission> InputSubmissions { get; set; }
        public List<SelectSubmission> SelectSubmissions { get; set; }
        public List<FieldSubmission> FieldSets { get; set; }
    }
}
