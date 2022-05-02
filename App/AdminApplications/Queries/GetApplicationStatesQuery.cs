using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;
using System.Threading;
using App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using App.Common.Models;
using MapsterMapper;
using Mapster;
using Microsoft.Extensions.Localization;
using App.AdminApplications.DTOs;

namespace App.AdminApplications.Queries
{
    public class GetApplicationStatesQuery : IRequestWrapper<IList<ApplicationStatesDto>>
    {
        public GetApplicationStatesQuery()
        {
        }
    }

    public class GetApplicationStatesQueryHandler : Handler, IRequestHandlerWrapper<GetApplicationStatesQuery, IList<ApplicationStatesDto>>
    {
        public GetApplicationStatesQueryHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper) 
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<IList<ApplicationStatesDto>>> Handle(GetApplicationStatesQuery query, CancellationToken cancellationToken)
        {
            var list = _mapper.Map<IList<ApplicationStatesDto>>(await _context.ApplicationStates.ToListAsync(cancellationToken));

            if (list.Count == 0)
            {
                return ServiceResult.Failed<IList<ApplicationStatesDto>>(ServiceError.NotFound);
            }

            return ServiceResult.Success(list);
        }
    }
}
