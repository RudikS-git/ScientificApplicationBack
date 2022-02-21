using Domain.Entities.Base.FieldRestrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class InputFieldDto : FieldDto
    {
        public int InputRestrictionId { get; set; }
        public InputRestriction InputRestriction { get; set; }
    }
}
