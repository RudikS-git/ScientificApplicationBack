using Domain.Entities.Base.FieldRestrictions;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AdminApplications.DTOs.Inputs
{
    public class InputTextFieldDto : InputFieldDto, IRegister
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InputTextField, InputTextFieldDto>()
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
