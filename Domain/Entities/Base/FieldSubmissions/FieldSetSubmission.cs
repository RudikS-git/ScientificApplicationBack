using Domain.Entities.Base.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldSubmissions
{
    public class FieldSetSubmission : FieldSubmission
    {
        public int FieldSetId { get; set; }
        public FieldSet FieldSet { get; set; }

        public List<InputSubmission> InputTextFields { get; set; }
        public List<SelectSubmission> InputDateFields { get; set; }
    }
}
