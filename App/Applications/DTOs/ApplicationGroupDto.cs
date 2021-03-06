using App.Applications.DTOs.Inputs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class ApplicationGroupDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<InputFieldDto> InputFields { get; set; }

        [JsonIgnore]
        public List<InputTextFieldDto> InputTextFields { get; set; }

        [JsonIgnore]
        public List<InputDateFieldDto> InputDataFields { get; set; }

        [JsonIgnore]
        public List<InputNumberFieldDto> InputNumberFields { get; set; }

        [JsonIgnore]
        public List<InputNumberPhoneFieldDto> InputNumberPhoneFields { get; set; }
    }
}
