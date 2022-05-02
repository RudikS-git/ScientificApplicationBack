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
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using App.Applications.DTOs;
using Domain.Entities.Enums;

namespace App.Applications.Queries
{
    public class GetApplicationsQuery : IRequestWrapper<PaginatedList<ApplicationDto>>
    {
        public int page;
        public int pageSize;
        public ApplicationQueryParamsDto filterParams;

        public GetApplicationsQuery(int page, int pageSize, ApplicationQueryParamsDto filterParams)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.filterParams = filterParams;
        }
    }

    public class GetApplicationsQueryHandler : Handler, IRequestHandlerWrapper<GetApplicationsQuery, PaginatedList<ApplicationDto>>
    {
        public GetApplicationsQueryHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<PaginatedList<ApplicationDto>>> Handle(GetApplicationsQuery query, CancellationToken cancellationToken)
        {
            IQueryable<Application> queryable = _context.Applications
                .Where(it => it.ManageApplicationState != ManageApplicationStates.Draft)
                .OrderByDescending(it => it.Id)
                .AsQueryable();

            if (query.filterParams != null)
            {
                SetFilterQueryable(queryable, query.filterParams);
            }

            PaginatedList<ApplicationDto> paginatedList = await PaginatedList<ApplicationDto>.CreateAsync(queryable.ProjectToType<ApplicationDto>(_mapper.Config), query.page, query.pageSize, cancellationToken);

            if (paginatedList.Items.Count == 0)
            {
                return ServiceResult.Failed<PaginatedList<ApplicationDto>>(ServiceError.NotFound);
            }

            return ServiceResult.Success(paginatedList);
        }

        private void SetFilterQueryable(IQueryable<Application> queryable, ApplicationQueryParamsDto filterParams)
        {
            if (!string.IsNullOrEmpty(filterParams.Name))
            {
                queryable = queryable.Where(it => it.Name.Contains(filterParams.Name));
            }
        }
    }
}
