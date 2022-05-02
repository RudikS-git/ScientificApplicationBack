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

namespace App.ApplicationSubmissions.Queries
{
    public class GetApplicationSubmissions : IRequestWrapper<ResponseQuery>
    {
        public int page;
        public int pageSize;
        public ApplicationQueryParamsDto filterParams;

        public GetApplicationSubmissions(int page, int pageSize, ApplicationQueryParamsDto filterParams)
        {
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
                _context.ApplicationSubmissions.Where(it => it.UserId == _userService.UserId),
                u => u.Id,
                c => c.ApplicationId,
                (u, c) => new
                {
                    id = c.Id,
                    ApplicationSubmissionName = c.Name,
                    ApplicationId = u.Id,
                    Created = c.Created,
                    ApplicationState = c.ApplicationState,

                    InputSubmissions = c.InputSubmissions,
                    SelectSubmissions = c.SelectSubmissions

                })
                .OrderByDescending(it => it.id).AsQueryable();


            if (query.filterParams != null)
            {
                if (!string.IsNullOrEmpty(query.filterParams.Name))
                {
                    queryable = queryable.Where(it => it.ApplicationSubmissionName.Contains(query.filterParams.Name));
                }
            }

            // .Where(it => it.Id ==)

            /*       IQueryable<ApplicationSubmission> queryable = _context.ApplicationSubmissions
                       .Where(it => it.UserId == _userService.UserId)
                       .OrderByDescending(it => it.Id).AsQueryable();*/

          /*  if (query.filterParams != null)
            {
                SetFilterQueryable(queryable, query.filterParams);
            }*/

            var paginatedList = await ResponseQuery.CreateAsync(queryable.ProjectToType<ApplicationSubmissionQueryDto>(_mapper.Config), query.page, query.pageSize, cancellationToken);

            if (paginatedList.Items.Count == 0)
            {
                return ServiceResult.Failed<ResponseQuery>(ServiceError.NotFound);
            }

            return ServiceResult.Success<ResponseQuery>(paginatedList);
        }
    }
}
