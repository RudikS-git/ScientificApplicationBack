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

using ResponseQuery = App.ApplicationSubmissions.Queries.ApplicationSubmissionQueryDetailsDto;
using Microsoft.Extensions.Localization;

namespace App.ApplicationSubmissions.Queries
{
    public class GetApplicationSubmissionById : IRequestWrapper<ResponseQuery>
    {
        public int Id { get; set; }

        public GetApplicationSubmissionById(int id)
        {
            this.Id = id;
        }
    }

    public class GetApplicationSubmissionByIdQueryHandler : Handler<ApplicationSubmission, ApplicationSubmissionQueryDetailsDto>, IRequestHandlerWrapper<GetApplicationSubmissionById, ResponseQuery>
    {
        private readonly ICurrentUserService _userService;

        public GetApplicationSubmissionByIdQueryHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetApplicationSubmissionById query, CancellationToken cancellationToken)
        {
            var applicationSubmission = await _context.ApplicationSubmissions
                .Where(it => it.UserId == _userService.UserId && query.Id == it.Id)
                .Include(it => it.ApplicationState)
                .Include(it => it.InputSubmissions)
                .Include(it => it.SelectSubmissions)
                .OrderByDescending(it => it.Id)
                .AsSplitQuery()
                .FirstOrDefaultAsync();

            if(applicationSubmission == null)
            {
                return ServiceResult.Failed<ResponseQuery>(ServiceError.NotFound);
            }

            return GetSuccessResult(applicationSubmission);
        }
    }
}
