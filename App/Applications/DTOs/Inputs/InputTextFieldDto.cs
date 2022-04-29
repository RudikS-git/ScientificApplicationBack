using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs.Inputs
{
    public class InputTextFieldDto : InputFieldDto
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
    }
}
