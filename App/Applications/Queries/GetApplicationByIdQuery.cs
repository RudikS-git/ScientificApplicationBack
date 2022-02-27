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

    public class GetApplicationByIdHandler : IRequestHandlerWrapper<GetApplicationByIdQuery, ApplicationDetailsDto>
    {
        private readonly IApplicationContext _context;

        public GetApplicationByIdHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<ApplicationDetailsDto>> Handle(GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
            ApplicationDetailsDto application = await _context.Applications
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
                .ProjectToType<ApplicationDetailsDto>()
                .FirstOrDefaultAsync(cancellationToken);

            
            
            if (application == null)
            {
                return ServiceResult.Failed<ApplicationDetailsDto>(ServiceError.NotFound);
            }

            return ServiceResult.Success(application);
        }
    }
}
