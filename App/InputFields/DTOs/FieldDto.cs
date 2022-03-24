using Domain.Entities.Base;
using Domain.Entities.Complex;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InputFields.DTOs
{
    public class FieldDto : IRegister
    {
        public int Id { get; set; }
        public Boolean IsRequired { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public FieldStyle Style { get; set; }

        public void Register(TypeAdapterConfig config)
        {
       
        }
    }
}
