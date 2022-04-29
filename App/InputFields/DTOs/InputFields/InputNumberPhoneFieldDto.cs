using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;

namespace App.InputFields.DTOs.InputFields
{
    public class InputNumberPhoneFieldDto : InputFieldDto, IRegister
    {
        public string Type { get; set; }

        public void Register(TypeAdapterConfig config)
        {
       /*     config.NewConfig<InputNumberPhoneFieldDto, InputNumberPhoneField>()
                .Map(dest => dest.InputField, src => new InputField()
                {
                    Description = src.Description,
                    Label = src.Label,
                    IsRequired = src.IsRequired,
                });*/
        }
    }
}
