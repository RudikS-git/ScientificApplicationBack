using App.Users.DTOs;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldSubmissions;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationSubmissions.DTOs
{
    public class ApplicationSubmissionDto : IRegister
    {
        public string Name { get; set; }
        public int ApplicationId { get; set; }
        public int ApplicationGroupId { get; set; }

        public List<InputSubmisionDto> InputSubmissions { get; set; }
        public List<SelectSubmissionDto> SelectSubmissions { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<ApplicationSubmission, ApplicationSubmissionDto>()
              // .MapWith(poco => poco.SelectSubmissions.Select(it => it.Values.Select(value => value.Id))
             /*  .AfterMapping((poco, dto) =>
               {
                   int index = 0;
                   poco.SelectSubmissions.ForEach(pocoSelectSubmission =>
                   {
                       pocoSelectSubmission.Values = dto.SelectSubmissions[index].ValuesId.Select(it => new SelectSubmissonOptions() { SelectOptionId = it }).ToList();
                   });

               });*/
        }
    }
}
