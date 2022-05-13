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
using App.AdminApplications.DTOs;
using Mapster;
using MapsterMapper;

using ResponseQuery = App.Common.Models.PaginatedList<App.ApplicationSubmissions.Queries.ApplicationSubmissionQueryDto>;
using Microsoft.Extensions.Localization;
using App.ApplicationSubmissions.DTOs.Request;

namespace App.ApplicationSubmissions.Queries
{
    public class GetApplicationSubmissions : IRequestWrapper<ResponseQuery>
    {
        public int applicationId;
        public int page;
        public int pageSize;
        public ApplicationSubmissionQueryParams filterParams;

        public GetApplicationSubmissions(int applicationId, int page, int pageSize, ApplicationSubmissionQueryParams filterParams)
        {
            this.applicationId = applicationId;
            this.page = page;
            this.pageSize = pageSize;
            this.filterParams = filterParams;
        }
    }

    public class GetApplicationSubmissionsQueryHandler : Handler, IRequestHandlerWrapper<GetApplicationSubmissions, ResponseQuery>
    {
        private readonly ICurrentUserService _userService;

        public GetApplicationSubmissionsQueryHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetApplicationSubmissions query, CancellationToken cancellationToken)
        {
            var queryable = _context.Applications.Join(
                _context.ApplicationSubmissions.Where(it => it.UserId == _userService.UserId && it.ApplicationId == query.applicationId),
                u => u.Id,
                c => c.ApplicationId,
                (u, c) => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    ApplicationId = u.Id,
                    Created = c.Created,
                    ApplicationState = c.ApplicationState,

                    InputSubmissions = c.InputSubmissions,
                    SelectSubmissions = c.SelectSubmissions

                })
                .OrderByDescending(it => it.Id).AsQueryable();


            if (query.filterParams != null)
            {
                if (query.filterParams.Id != null)
                {
                    queryable = queryable.Where(it => it.Id == query.filterParams.Id);
                }

                if (!string.IsNullOrEmpty(query.filterParams.Name))
                {
                    queryable = queryable.Where(it => it.Name.Contains(query.filterParams.Name));
                }

                if(query.filterParams.StartDate != null)
                {
                    queryable = queryable.Where(it => it.Created >= query.filterParams.StartDate);
                }

                if(query.filterParams.EndDate != null)
                {
                    queryable = queryable.Where(it => it.Created <= query.filterParams.EndDate);
                }

                if(query.filterParams.applicationState != null)
                {
                    queryable = queryable.Where(it => it.ApplicationState.Id != query.filterParams.applicationState);
                } 
            }

            var paginatedList = await ResponseQuery.CreateAsync(queryable.ProjectToType<ApplicationSubmissionQueryDto>(_mapper.Config), query.page, query.pageSize, cancellationToken);

            if (paginatedList.Items.Count == 0)
            {
                return ServiceResult.Failed<ResponseQuery>(ServiceError.NotFound);
            }

            return ServiceResult.Success<ResponseQuery>(paginatedList);
        }
    }
}
