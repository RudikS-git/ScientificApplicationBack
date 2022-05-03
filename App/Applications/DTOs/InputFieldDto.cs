using Domain.Entities.Base.FieldTypes;
using Domain.Enums;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class InputFieldDto : FieldDto
    {
        public int InputFieldId { get; set; }
        public int GroupId { get; set; }
        public InputUnderTypes InputUnderTypeId { get; set; }
    }
}
