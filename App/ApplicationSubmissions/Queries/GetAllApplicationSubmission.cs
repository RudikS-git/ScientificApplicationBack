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
using Domain.Enums;

namespace App.ApplicationSubmissions.Queries
{
    public class GetAllApplicationSubmission : IRequestWrapper<ResponseQuery>
    {
        public int applicationId;
        public int page;
        public int pageSize;
        public ApplicationQueryParamsDto filterParams;

        public GetAllApplicationSubmission(int applicationId, int page, int pageSize, ApplicationQueryParamsDto filterParams)
        {
            this.applicationId = applicationId;
            this.page = page;
            this.pageSize = pageSize;
            this.filterParams = filterParams;
        }
    }

    public class GetAllApplicationSubmissionHandler : Handler, IRequestHandlerWrapper<GetAllApplicationSubmission, ResponseQuery>
    {
        private readonly ICurrentUserService _userService;

        public GetAllApplicationSubmissionHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetAllApplicationSubmission query, CancellationToken cancellationToken)
        {
            var queryable = _context.Applications.Join(
                _context.ApplicationSubmissions.Where(it => it.ApplicationId == query.applicationId  && 
                    it.ApplicationStateId != ApplicationStatesEnum.Draft &&
                    it.ApplicationStateId != ApplicationStatesEnum.Modification),
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
                if (!string.IsNullOrEmpty(query.filterParams.Name))
                {
                    queryable = queryable.Where(it => it.Name.Contains(query.filterParams.Name));
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
