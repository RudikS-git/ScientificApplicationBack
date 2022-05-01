using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldRestrictions
{
    [Table("InputFileField")]
    public class InputFileField : BaseEntity
    {
        public int ApplicationGroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }

        public int InputFieldId { get; set; }
        public InputField InputField { get; set; }
    }
}
