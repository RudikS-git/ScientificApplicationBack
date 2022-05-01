using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class ApplicationGroup : BaseEntity
    {
        public string Name { get; set; }
        public List<InputTextField> InputTextFields { get; set; }
        public List<InputDateField> InputDataFields { get; set; }
        public List<InputNumberField> InputNumberFields { get; set; }
        public List<InputNumberPhoneField> InputNumberPhoneFields { get; set; }

        public List<FieldSet> FieldSets { get; set; }
        public List<SelectField> SelectFields { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
