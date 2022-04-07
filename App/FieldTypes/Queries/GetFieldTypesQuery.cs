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
using Microsoft.Extensions.Localization;
using MapsterMapper;

namespace App.FieldTypes.Queries
{
    public class GetFieldTypesQuery : IRequestWrapper<IEnumerable<FieldType>>
    {
    
    }

    public class GetFieldTypesQueryHandler : Handler, IRequestHandlerWrapper<GetFieldTypesQuery, IEnumerable<FieldType>>
    {
        public GetFieldTypesQueryHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<IEnumerable<FieldType>>> Handle(GetFieldTypesQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<FieldType> fields = await _context.FieldTypes.OrderByDescending(it => it.Id).ToListAsync(cancellationToken);

            if (fields == null)
            {
                return ServiceResult.Failed<IEnumerable<FieldType>>(ServiceError.NotFound);
            }

            return ServiceResult.Success(fields);
        }
    }
}
