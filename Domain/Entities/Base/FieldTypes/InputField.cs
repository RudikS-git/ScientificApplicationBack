using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldTypes
{
    [Table("InputField")]
    public class InputField : Field
    {
        public int InputRestrictionId { get; set; }
        public InputRestriction InputRestriction { get; set; }
    }
}
