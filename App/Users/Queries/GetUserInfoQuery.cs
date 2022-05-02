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
using App.AdminApplications.DTOs;
using Mapster;
using MapsterMapper;

using ResponseQuery = App.Users.Queries.UserInfoResponse;
using Microsoft.Extensions.Localization;

namespace App.Users.Queries
{
    public class GetUserInfoQuery : IRequestWrapper<ResponseQuery>
    {
        public int id;

        public GetUserInfoQuery(int id)
        {
            this.id = id;
        }
    }

    public class GetUserInfoQueryHandler : Handler, IRequestHandlerWrapper<GetUserInfoQuery, ResponseQuery>
    {
        private readonly ICurrentUserService _userService;

        public GetUserInfoQueryHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(applicationContext, localizer, mapper)

        {
            _userService = userService;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetUserInfoQuery query, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(it => it.Id == query.id).FirstOrDefaultAsync();
            /*    Join(
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
                .OrderByDescending(it => it.id).AsQueryable();*/


            return ServiceResult.Success(_mapper.Map<ResponseQuery>(user));
        }
    }
}
