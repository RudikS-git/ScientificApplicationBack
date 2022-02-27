using Domain.Entities.Base.FieldRestrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class InputFieldDto : FieldDto
    {
        public int InputNumberPhoneRestrictionId { get; set; }
        public InputNumberPhoneField InputNumberPhoneRestriction { get; set; }

        public int InputNumberRestrictionId { get; set; }
        public InputNumberField InputNumberRestriction { get; set; }

        public int InputDateRestrictionId { get; set; }
        public InputDateField InputDateRestriction { get; set; }

        public int InputTextRestrictionId { get; set; }
        public InputTextField InputTextRestriction { get; set; }
    }
}
