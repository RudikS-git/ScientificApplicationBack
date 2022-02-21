using App.Common.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace App.Common.Mapping
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);
        }

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, TypeAdapterConfig configuration, CancellationToken cancellationToken)
        {
            return queryable.ProjectToType<TDestination>(configuration).ToListAsync(cancellationToken);
        }
    }
}
