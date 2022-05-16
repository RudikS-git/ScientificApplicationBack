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
    public class InputDateFieldDto : InputFieldDto, IRegister
    {
        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }

        public void Register(TypeAdapterConfig config)
        {
           /* config.NewConfig<InputDateFieldDto, InputDateField>()
                .Map(dest => dest.InputField, src => new InputField()
                {
                    Description = src.Description,
                    Label = src.Label,
                    IsRequired = src.IsRequired,
                });*/
        }
    }
}
