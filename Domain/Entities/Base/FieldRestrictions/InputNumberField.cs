using Domain.Entities.Base.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base.FieldRestrictions
{
    [Table("InputNumberField")]
    public class InputNumberField : BaseEntity
    {
        public int ApplicationGroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }

        [ForeignKey("InputFieldId")]
        public int InputFieldId { get; set; }
        public InputField InputField { get; set; }
    }
}
