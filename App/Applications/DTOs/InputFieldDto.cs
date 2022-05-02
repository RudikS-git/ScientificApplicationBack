using Domain.Entities.Base.FieldTypes;
using Domain.Enums;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class InputFieldDto : FieldDto, IRegister
    {
        public int InputFieldId { get; set; }
        public int GroupId { get; set; }
        public InputUnderTypes InputUnderTypeId { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InputField, InputFieldDto>()
               .Map(it => it.Label, poco => poco.Label)
               .Map(it => it.IsRequired, poco => poco.IsRequired)
               .Map(it => it.Description, poco => poco.Description)
               .Map(it => it.InputUnderTypeId, poco => poco.InputUnderTypeId)
               .Map(it => it.InputFieldId, poco => poco.Id)
               .Map(it => it.GroupId, poco => poco.ApplicationGroupId)
               .TwoWays();
        }
    }
}
