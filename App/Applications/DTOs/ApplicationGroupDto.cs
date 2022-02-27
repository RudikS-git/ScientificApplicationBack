using App.FieldSets.DTOs;
using App.InputFields.DTOs.InputFields;
using App.SelectFields.DTOs;
using Domain.Entities.Base;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class ApplicationGroupDto : IRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<InputTextFieldDto> InputTextFields { get; set; }
        public List<InputDateFieldDto> InputDataFields { get; set; }
        public List<InputNumberFieldDto> InputNumberFields { get; set; }
        public List<InputNumberPhoneFieldDto> InputNumberPhoneFields { get; set; }

        public List<SelectFieldDto> SelectFields { get; set; }
        public List<FieldSetDto> FieldSets { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ApplicationGroup, ApplicationGroupDto>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
