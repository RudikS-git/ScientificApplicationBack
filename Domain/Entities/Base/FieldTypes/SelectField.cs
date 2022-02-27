using Domain.Entities.Base.FieldRestrictions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldTypes
{
    [Table("SelectField")]
    public class SelectField : Field
    {
        public bool IsMultiple { get; set; }
        public bool IsAsync { get; set; }
        public List<SelectOption> Options { get; set; }

        public int SelectRestrictionId { get; set; }
        public SelectRestriction SelectRestriction { get; set; }
    }
}
