using Domain.Entities.Complex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AdminApplications.DTOs
{
    public class FieldDto
    {
        public int Id { get; set; }
        public Boolean IsRequired { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public FieldStyle Style { get; set; }
    }
}
