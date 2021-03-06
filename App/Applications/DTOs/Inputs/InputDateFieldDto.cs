using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs.Inputs
{
    public class InputDateFieldDto : InputFieldDto, IRegister
    {
        public DateTime? MinDateTime { get; set; }
        public DateTime? MaxDateTime { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InputDateField, InputDateFieldDto>()
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
