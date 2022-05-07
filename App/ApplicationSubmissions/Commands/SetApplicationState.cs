using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Models;
using App.Common.Interfaces;
using Domain.Entities.Base;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Threading;
using App.AdminApplications.DTOs;
using MapsterMapper;
using Mapster;
using Microsoft.EntityFrameworkCore;
using App.ApplicationSubmissions.DTOs;
using Domain.Entities.Base.FieldSubmissions;
using Domain.Enums;

namespace App.ApplicationSubmissions.Commands
{
    public class SetApplicationState : IRequestWrapper<ApplicationSubmissionDto>
    {
        public int Id { get; set; }
        public ApplicationStatesEnum ApplicationState { get; set; }
        public string Comment { get; set; }

        public SetApplicationState(int id, ApplicationStatesEnum applicationState, string comment)
        {
            Id = id;
            ApplicationState = applicationState;
            Comment = comment;
        }
    }

    class SetApplicationStateHandler : Handler<ApplicationSubmission, ApplicationSubmissionDto>, IRequestHandlerWrapper<SetApplicationState, ApplicationSubmissionDto>
    {
        private readonly ICurrentUserService _userService;

        public SetApplicationStateHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ApplicationSubmissionDto>> Handle(SetApplicationState request, CancellationToken cancellationToken)
        {
            var app = await _context.ApplicationSubmissions.Where(it => it.Id == request.Id)
                .Include(it => it.ApplicationState)
                .FirstOrDefaultAsync();

            if (app == null)
            {
                return ServiceResult.Failed<ApplicationSubmissionDto>(ServiceError.NotFound);
            }

            if (app.ApplicationStateId != request.ApplicationState)
            {
                var historyApplicationState = new HistoryApplicationState()
                {
                    ApplicationSubmissionId = request.Id,
                    ChangedUserId = _userService.UserId,
                    Comment = request.Comment,
                    NewApplicationStateId = request.ApplicationState,
                    LastApplicationStateId = app.ApplicationState.Id
                };

                _context.HistoryApplicationStates.Add(historyApplicationState);

                app.ApplicationStateId = request.ApplicationState;
                _context.ApplicationSubmissions.Update(app);
            }
            else
            {
                return ServiceResult.Failed<ApplicationSubmissionDto>(new ServiceError("Заявка уже находится в данном состоянии", 400));
            }

            await _context.SaveChangesAsync();

            return GetSuccessResult(app);
        }
    }
}
