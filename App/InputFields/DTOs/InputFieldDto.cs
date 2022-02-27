using App.InputFields.DTOs.InputFields;
using Domain.Entities.Base.FieldRestrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Domain.Entities.Base.FieldTypes;

namespace App.InputFields.DTOs
{
    public class InputFieldDto : FieldDto, IRegister
    {
        public int InputFieldId { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InputFieldDto, InputField>()
               .Map(dest => dest, src => new InputField()
               {
                   Description = src.Description,
                   Label = src.Label,
                   IsRequired = src.IsRequired,
               });
        }
    }
}
