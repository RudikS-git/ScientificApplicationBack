using App.InputFields.DTOs.InputFields;
using Domain.Entities.Base.FieldRestrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Base.UnderTypes;
using Domain.Enums;

namespace App.InputFields.DTOs
{
    public class InputFieldDto : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InputFieldDto, InputField>()
                .TwoWays()
                .Include<InputTextFieldDto, InputTextField>()
                .Include<InputDateFieldDto, InputDateField>()
                .Include<InputNumberFieldDto, InputNumberField>()
                .Include<InputNumberPhoneFieldDto, InputNumberPhoneField>();
        }
    }
}
