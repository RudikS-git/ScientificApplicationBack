using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class ApplicationGroup : BaseEntity
    {
        public string Name { get; set; }
        public List<InputField> InputFields { get; set; }
        public List<SelectField> SelectFields { get; set; }
    }
}
