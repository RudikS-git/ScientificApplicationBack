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

using ResponseQuery = App.Users.Queries.UserInfoResponse;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Identity;

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
        private readonly UserManager<User> _userManager;

        public GetUserInfoQueryHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService, UserManager<User> userManager)
            : base(applicationContext, localizer, mapper)

        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetUserInfoQuery query, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(it => it.Id == query.id)
                .FirstOrDefaultAsync();

            var userDto = _mapper.Map<ResponseQuery>(user);
            userDto.Roles = await _userManager.GetRolesAsync(user);

            return ServiceResult.Success(userDto);
        }
    }
}
