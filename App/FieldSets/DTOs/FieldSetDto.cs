using App.Applications.DTOs;
using App.InputFields.DTOs;
using App.InputFields.DTOs.InputFields;
using App.SelectFields.DTOs;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FieldSets.DTOs
{
    public class FieldSetDto : FieldDto, IRegister
    {
        public List<InputTextFieldDto> InputTextFields { get; set; }
        public List<InputDateFieldDto> InputDateFields { get; set; }
        public List<InputNumberFieldDto> InputNumberFields { get; set; }
        public List<InputNumberPhoneFieldDto> InputNumberPhoneFields { get; set; }
        public List<SelectFieldDto> SelectFields { get; set; }

        public void Register(TypeAdapterConfig config)
        {
           /* config.NewConfig<FieldSetDto, FieldSet>()
               .Map(dest => dest.InputDateFields, src => new InputDateFields()
               {
                   
                   Description = src.Description,
                   Label = src.Label,
                   IsRequired = src.IsRequired,
               });*/
        }
    }
}
