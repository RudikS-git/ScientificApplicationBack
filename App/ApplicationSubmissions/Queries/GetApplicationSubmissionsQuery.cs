﻿using MediatR;
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
using Mapster;
using MapsterMapper;

using ResponseQuery = App.Common.Models.PaginatedList<App.ApplicationSubmissions.Queries.ApplicationSubmissionQueryDto>;

namespace App.ApplicationSubmissions.Queries
{
    public class GetApplicationSubmissionsQuery : IRequestWrapper<ResponseQuery>
    {
        public int page;
        public int pageSize;
        public ApplicationQueryParamsDto filterParams;

        public GetApplicationSubmissionsQuery(int page, int pageSize, ApplicationQueryParamsDto filterParams)
        {
            this.page = page;
            this.pageSize = pageSize;
            this.filterParams = filterParams;
        }
    }

    public class GetApplicationSubmissionsQueryHandler : IRequestHandlerWrapper<GetApplicationSubmissionsQuery, ResponseQuery>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetApplicationSubmissionsQueryHandler(IApplicationContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetApplicationSubmissionsQuery query, CancellationToken cancellationToken)
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