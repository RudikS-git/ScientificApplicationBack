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
using App.Applications.DTOs;
using MapsterMapper;
using Mapster;

namespace App.Queries
{
    public class GetApplicationStatesQuery : IRequestWrapper<IList<ApplicationStatesDto>>
    {
        public GetApplicationStatesQuery()
        {
        }
    }

    public class GetApplicationStatesQueryHandler : IRequestHandlerWrapper<GetApplicationStatesQuery, IList<ApplicationStatesDto>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetApplicationStatesQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
