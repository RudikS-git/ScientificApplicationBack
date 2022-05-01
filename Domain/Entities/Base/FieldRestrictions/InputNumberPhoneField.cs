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
    [Table("InputNumberPhoneField")]
    public class InputNumberPhoneField : BaseEntity
    {
        public int ApplicationGroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }

        public string Type { get; set; }

        [ForeignKey("InputFieldId")]
        public int InputFieldId { get; set; }
        public InputField InputField { get; set; }
    }
}
