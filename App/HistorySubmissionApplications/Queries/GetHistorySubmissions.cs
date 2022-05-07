using App.Common.Interfaces;
using App.Common.Models;
using App.HistorySubmissionApplications.DTOs;
using Domain.Entities.Base;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.HistorySubmissionApplications.Queries
{
    public class GetHistorySubmissions : IRequestWrapper<PaginatedList<HistorySubmissionDto>>
    {
        public int AplicationSubmissionId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetHistorySubmissions(int applicationSubmissionId, int page, int pageSize)
        {
            this.AplicationSubmissionId = applicationSubmissionId;
            this.Page = page;
            this.PageSize = pageSize;
        }
    }

    public class GetHistorySubmissionsHandler : Handler<HistoryApplicationState, HistorySubmissionDto>, IRequestHandlerWrapper<GetHistorySubmissions, PaginatedList<HistorySubmissionDto>>
    {
        public GetHistorySubmissionsHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<PaginatedList<HistorySubmissionDto>>> Handle(GetHistorySubmissions query, CancellationToken cancellationToken)
        {
            var queryable = _context.HistoryApplicationStates
                .Where(it => it.ApplicationSubmissionId == query.AplicationSubmissionId)
                .OrderByDescending(it => it.Id)
                .AsQueryable();


            var paginatedList = await PaginatedList<HistorySubmissionDto>.CreateAsync(queryable.ProjectToType<HistorySubmissionDto>(_mapper.Config), query.Page, query.PageSize, cancellationToken);

            if (paginatedList == null)
            {
                return ServiceResult.Failed<PaginatedList<HistorySubmissionDto>>(ServiceError.NotFound);
            }

            return ServiceResult.Success(paginatedList);
        }
    }
}
