using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AdminApplications.DTOs
{
    [DisplayName("Applications_InputFieldDto")]
    public class InputFieldDto : FieldDto
    {
        public int InputFieldId { get; set; }
        public int GroupId { get; set; }
        public InputUnderTypes InputUnderTypeId { get; set; }
    }
}
