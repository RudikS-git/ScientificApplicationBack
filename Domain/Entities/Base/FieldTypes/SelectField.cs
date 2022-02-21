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
    [Table("SelectField")]
    public class SelectField : Field
    {
        public List<WorkEntityField> Options { get; set;}
        public int SelectRestrictionId { get; set; }
        public SelectRestriction SelectRestriction { get; set; }
    }
}
