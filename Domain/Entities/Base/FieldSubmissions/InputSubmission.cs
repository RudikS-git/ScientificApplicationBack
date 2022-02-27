using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldSubmissions
{
    public class InputSubmission : FieldSubmission
    {
        public int InputFieldId { get; set; }
        public InputField InputField { get; set; }
        public string Value { get; set; }
    }
}
