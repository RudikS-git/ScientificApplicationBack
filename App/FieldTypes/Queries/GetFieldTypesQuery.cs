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

namespace App.FieldTypes.Queries
{
    public class GetFieldTypesQuery : IRequestWrapper<IEnumerable<FieldType>>
    {
    
    }

    public class GetFieldTypesQueryHandler : IRequestHandlerWrapper<GetFieldTypesQuery, IEnumerable<FieldType>>
    {
        private readonly IApplicationContext _context;

        public GetFieldTypesQueryHandler(IApplicationContext context)
        {
            _context = context;
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
