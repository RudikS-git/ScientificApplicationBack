using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Base.FieldRestrictions;

namespace Domain.Entities.Base.FieldTypes
{
    [Table("FieldSet")]
    public class FieldSet : Field
    {
        public List<InputTextField> InputTextFields { get; set; }
        public List<InputDateField> InputDateFields { get; set; }
        public List<InputNumberField> InputNumberFields { get; set; }
        public List<InputNumberPhoneField> InputNumberPhoneFields { get; set; }
        public List<SelectField> SelectFields { get; set; }
    }
}
