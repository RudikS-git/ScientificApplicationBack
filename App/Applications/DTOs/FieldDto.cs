using Domain.Entities.Base;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class FieldDto : IRegister
    {
        public int Id { get; set; }
        public int FieldTypeId { get; set; }
        public bool IsRequired { get; set; }
        public string Label { get; set; }
        public string SystemName { get; set; }
        public string Description { get; set; }

        public void Register(TypeAdapterConfig config)
        {
        }
    }
}
