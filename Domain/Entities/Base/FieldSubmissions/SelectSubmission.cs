using Domain.Entities.Base.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldSubmissions
{
    public class SelectSubmission : FieldSubmission
    {
        public int SelectFieldId { get; set; }
        public SelectField SelectField { get; set; }

        public List<SelectSubmissonOptions> Values { get; set; }
    }
}
