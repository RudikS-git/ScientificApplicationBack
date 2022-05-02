using App.Applications.DTOs;
using App.Common.Interfaces;
using App.Common.Models;
using Domain.Entities.Base;
using Domain.Entities.Enums;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

                .Where(it => it.ManageApplicationState != ManageApplicationStates.Draft)
                .Include(it => it.ApplicationGroups)
                .ThenInclude(it => it.InputDataFields)
                .ThenInclude(it => it.InputField)

                .Include(it => it.ApplicationGroups)
                .ThenInclude(it => it.InputTextFields)
                .ThenInclude(it => it.InputField)

                .Include(it => it.ApplicationGroups)
                .ThenInclude(it => it.InputNumberFields)
                .ThenInclude(it => it.InputField)

                .Include(it => it.ApplicationGroups)
                .ThenInclude(it => it.InputNumberPhoneFields)
                .ThenInclude(it => it.InputField)

                .Where(it => it.Id == query.id)
                .FirstOrDefaultAsync(cancellationToken);

            if (application?.ApplicationGroups == null)
            {
                return ServiceResult.Failed<ApplicationDetailsDto>(ServiceError.NotFound);
            }

            var appDto = MapToDTO(application);

            appDto.ApplicationGroups.ForEach(it =>
            {
                it.InputFields = new List<InputFieldDto>(it.InputTextFields);
                it.InputFields.AddRange(it.InputNumberFields);
                it.InputFields.AddRange(it.InputNumberPhoneFields);
                it.InputFields.AddRange(it.InputDataFields);
                it.InputFields = it.InputFields.OrderBy(it => it.Style).ToList();
            });

            return ServiceResult.Success(appDto);
        }
    }
}
