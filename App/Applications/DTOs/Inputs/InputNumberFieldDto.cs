using Domain.Entities.Base.FieldRestrictions;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs.Inputs
{
    public class InputNumberFieldDto : InputFieldDto, IRegister
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InputNumberField, InputNumberFieldDto>()
               .Map(it => it.Label, poco => poco.InputField.Label)
               .Map(it => it.IsRequired, poco => poco.InputField.IsRequired)
               .Map(it => it.Description, poco => poco.InputField.Description)
               .Map(it => it.InputUnderTypeId, poco => poco.InputField.InputUnderTypeId)
               .Map(it => it.InputFieldId, poco => poco.InputField.Id)
               .Map(it => it.GroupId, poco => poco.InputField.ApplicationGroupId)
               .TwoWays();
        }
    }
}
