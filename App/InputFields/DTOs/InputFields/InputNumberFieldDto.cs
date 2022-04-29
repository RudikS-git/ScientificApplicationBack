using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InputFields.DTOs.InputFields
{
    public class InputNumberFieldDto : InputFieldDto, IRegister
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public void Register(TypeAdapterConfig config)
        {
       /*     config.NewConfig<InputNumberFieldDto, InputNumberField>()
                .Map(dest => dest.InputField, src => new InputField()
                {
                    Description = src.Description,
                    Label = src.Label,
                    IsRequired = src.IsRequired,
                });*/
        }
    }
}
