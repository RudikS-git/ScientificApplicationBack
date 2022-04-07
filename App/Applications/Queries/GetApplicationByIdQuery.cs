using App.Common.Interfaces;
using App.Common.Models;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;
using Mapster;
using App.Applications.DTOs;
using App.InputFields.DTOs;
using Microsoft.Extensions.Localization;

namespace App.Applications.Queries
{
    public class GetApplicationByIdQuery : IRequestWrapper<ApplicationDetailsDto>
    {
        public int id { get; set; }

        public GetApplicationByIdQuery()
        {
        }

        public GetApplicationByIdQuery(int id)
        {
            this.id = id;
        }
    }

    public class GetApplicationByIdHandler : Handler<Application, ApplicationDetailsDto>, IRequestHandlerWrapper<GetApplicationByIdQuery, ApplicationDetailsDto>
    {
        public GetApplicationByIdHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper) 
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<ApplicationDetailsDto>> Handle(GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
            var application = await _context.Applications
                .Include(it => it.FieldGroups)
                .ThenInclude(it => it.SelectFields)

                .Include(it => it.FieldGroups)
                .ThenInclude(it => it.InputTextFields)

                .Include(it => it.FieldGroups)
                .ThenInclude(it => it.InputNumberFields)

                .Include(it => it.FieldGroups)
                .ThenInclude(it => it.InputNumberPhoneFields)

                .Include(it => it.FieldGroups)
                .ThenInclude(it => it.InputDataFields)

                .Include(it => it.FieldGroups)
                .ThenInclude(it => it.FieldSets)

                .Where(it => it.Id == query.id)
               /* .ProjectToType<ApplicationDetailsDto>()*/
                .FirstOrDefaultAsync(cancellationToken);

            if (application == null)
            {
                return ServiceResult.Failed<ApplicationDetailsDto>(ServiceError.NotFound);
            }

            var appDto = MapToDTO(application);

            appDto.ApplicationGroups.ForEach(it =>
            {
                it.Fields = new List<InputFieldDto>(it.InputTextFields);
                it.Fields.AddRange(it.InputNumberFields);
                it.Fields.AddRange(it.InputNumberPhoneFields);
                it.Fields.AddRange(it.InputNumberPhoneFields);
                it.Fields = it.Fields.OrderBy(it => it.Id).ToList();
            });

            return ServiceResult.Success(appDto);
        }
    }
}
