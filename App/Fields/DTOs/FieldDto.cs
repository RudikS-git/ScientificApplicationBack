using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Fields.DTOs
{
    public class FieldDto
    {
        public int Id { get; set; }
        public Boolean IsRequired { get; set; }
        public string Label { get; set; }
        public int FieldTypeId { get; set; }
        public string Description { get; set; }
    }
}
