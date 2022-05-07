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
    public class SendApplicationForVerification : IRequestWrapper<ApplicationSubmissionDto>
    {
        public int Id { get; set; }

        public SendApplicationForVerification(int id)
        {
            Id = id;
        }
    }

    // Переводит "Черновик", "На доработке" в "Отправлено на проверку"
    class SendApplicationForVerificationHandler : Handler<ApplicationSubmission, ApplicationSubmissionDto>, IRequestHandlerWrapper<SendApplicationForVerification, ApplicationSubmissionDto>
    {
        private readonly ICurrentUserService _userService;

        public SendApplicationForVerificationHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ApplicationSubmissionDto>> Handle(SendApplicationForVerification request, CancellationToken cancellationToken)
        {
            var app = await _context.ApplicationSubmissions.Where(it => it.Id == request.Id)
                .Include(it => it.ApplicationState)
                .FirstOrDefaultAsync();

            if (app == null)
            {
                return ServiceResult.Failed<ApplicationSubmissionDto>(ServiceError.NotFound);
            }

            if (app.ApplicationStateId == ApplicationStatesEnum.Draft || app.ApplicationStateId == ApplicationStatesEnum.Modification)
            {
                var appState = await _context.ApplicationStates.Where(it => it.Id == ApplicationStatesEnum.Checked)
                    .FirstOrDefaultAsync();

                app.ApplicationState = appState;
                _context.ApplicationSubmissions.Update(app);

                var historyApplicationState = new HistoryApplicationState()
                {
                    ApplicationSubmissionId = request.Id,
                    ChangedUserId = _userService.UserId,
                    NewApplicationStateId = ApplicationStatesEnum.Checked,
                    LastApplicationStateId = app.ApplicationState.Id
                };

                _context.HistoryApplicationStates.Add(historyApplicationState);
            }
            else
            {
                return ServiceResult.Failed<ApplicationSubmissionDto>(new ServiceError("Заявка уже находится на проверке, согласована или отклонена", 400));
            }

            await _context.SaveChangesAsync();

            return GetSuccessResult(app);
        }
    }
}
