using Domain.Entities.Base.FieldSubmissions;
using Domain.Entities.Base.FieldTypes;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationSubmissions.DTOs
{
    public class SelectSubmissionDto : IRegister
    {
        public int Id { get; set; }
        public int SelectFieldId { get; set; }
        public int[] ValuesId { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SelectSubmission, SelectSubmissionDto>()
                .Map(poco => poco.ValuesId, dto => dto.Values);

            config.NewConfig<SelectSubmissonOptions, int>()
                 .MapWith(poco => poco.SelectOptionId);
        }
    }
}
