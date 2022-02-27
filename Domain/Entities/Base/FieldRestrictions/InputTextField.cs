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
    [Table("InputTextField")]
    public class InputTextField : InputField
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public int InputFieldId { get; set; }
        public InputField InputField { get; set; }
    }
}
