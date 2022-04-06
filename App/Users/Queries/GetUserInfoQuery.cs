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
using App.Applications.DTOs;
using Mapster;
using MapsterMapper;

using ResponseQuery = App.Users.Queries.UserInfoResponse;

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

    public class GetUserInfoQueryHandler : IRequestHandlerWrapper<GetUserInfoQuery, ResponseQuery>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetUserInfoQueryHandler(IApplicationContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
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


            return ServiceResult.Success<ResponseQuery>(_mapper.Map<UserInfoResponse>(user));
        }
    }
}
