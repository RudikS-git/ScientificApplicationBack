using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;
using System.Threading;
using App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using App.Common.Models;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using App.Applications.DTOs;
using Domain.Entities.Enums;
using System.Collections.Generic;

namespace App.Applications.Queries
{
    public class GetApplicationStatesQuery : IRequestWrapper<IList<ApplicationState>>
    {

    }

    public class GetApplicationStatesQueryHandler : Handler, IRequestHandlerWrapper<GetApplicationStatesQuery, IList<ApplicationState>>
    {
        public GetApplicationStatesQueryHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<IList<ApplicationState>>> Handle(GetApplicationStatesQuery query, CancellationToken cancellationToken)
        {
            var applicationStates = await _context.ApplicationStates
                .OrderByDescending(it => it.Id)
                .ToListAsync(cancellationToken);

            if (applicationStates.Count == 0)
            {
                return ServiceResult.Failed<IList<ApplicationState>>(ServiceError.NotFound);
            }

            return ServiceResult.Success<IList<ApplicationState>>(applicationStates);
        }
    }
}
