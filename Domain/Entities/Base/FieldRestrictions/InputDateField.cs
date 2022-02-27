using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base.FieldRestrictions
{
    [Table("InputDateField")]
    public class InputDateField : InputField
    {
        public DateTime MinDateTime { get; set; }
        public DateTime MaxDateTime { get; set; }

        public int InputFieldId { get; set; }
        public InputField InputField { get; set; }
    }
}
