using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs.Inputs
{
    public class InputNumberFieldDto : InputFieldDto
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
