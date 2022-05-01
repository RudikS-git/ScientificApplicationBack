using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.UnderTypes;
using Domain.Entities.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldTypes
{
    public class InputField : Field
    {
        public InputUnderTypes InputUnderTypeId { get; set; }

        public List<InputDateField> InputDateField { get; set; }

        public List<InputTextField> InputTextField { get; set; }

        public List<InputNumberPhoneField> InputNumberPhoneField { get; set; }

        public List<InputNumberField> InputNumberField { get; set; }
    }
}
