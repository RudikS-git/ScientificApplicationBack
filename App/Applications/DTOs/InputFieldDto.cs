using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    [DisplayName("Applications_InputFieldDto")]
    public class InputFieldDto : FieldDto
    {
        public InputUnderTypes InputUnderTypeId { get; set; }
    }
}
