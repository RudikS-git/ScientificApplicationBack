using App.FieldSets.DTOs;
using App.InputFields.DTOs;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.SelectFields.DTOs
{
    public class SelectFieldDto : FieldDto
    {
        public List<SelectOptionDto> Options { get; set; }
        public int SelectRestrictionId { get; set; }
        public SelectRestriction SelectRestriction { get; set; }
    }
}
