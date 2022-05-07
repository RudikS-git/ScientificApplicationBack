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
    public class CreateUpdateApplicationSubmissionCommand : IRequestWrapper<ApplicationSubmissionDto>
    {
        public ApplicationSubmissionDto ApplicationSubmission { get; set; }
    }

    class CreateUpdateApplicationSubmissionCommandHandler : Handler<ApplicationSubmission, ApplicationSubmissionDto>, IRequestHandlerWrapper<CreateUpdateApplicationSubmissionCommand, ApplicationSubmissionDto>
    {
        private readonly ICurrentUserService _userService;

        public CreateUpdateApplicationSubmissionCommandHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ApplicationSubmissionDto>> Handle(CreateUpdateApplicationSubmissionCommand request, CancellationToken cancellationToken)
        {
            var applicationSubmission = _mapper.Map<ApplicationSubmission>(request.ApplicationSubmission);
            applicationSubmission.UserId = _userService.UserId;

            if (applicationSubmission.Id != 0)
            {
                var existingAppSubmission = await _context.ApplicationSubmissions.Where(it => it.Id == applicationSubmission.Id)
                    .Include(it => it.ApplicationState)
                    .FirstOrDefaultAsync();

                if(existingAppSubmission.ApplicationState.Id == ApplicationStatesEnum.Rejected ||
                    existingAppSubmission.ApplicationState.Id == ApplicationStatesEnum.Checked ||
                    existingAppSubmission.ApplicationState.Id == ApplicationStatesEnum.Accepted)
                {
                    return ServiceResult.Failed<ApplicationSubmissionDto>(new ServiceError("Невозможно изменить заявку, так как она уже находится на проверке, отклонена или согласована", 400));
                }

                if (request.ApplicationSubmission?.SelectSubmissions?.Count != 0)
                {
                    applicationSubmission.SelectSubmissions = request.ApplicationSubmission?.SelectSubmissions?.Select(it =>
                         new SelectSubmission()
                         {
                             SelectFieldId = it.SelectFieldId,
                             Values = it.ValuesId.Select(value => new SelectSubmissonOptions() { SelectOptionId = value }).ToList()
                         }
                     ).ToList();
                }
                else
                {
                    applicationSubmission.SelectSubmissions = null;
                }

                var entityAppSub = _context.ApplicationSubmissions.Update(applicationSubmission);
                entityAppSub.Property(it => it.ApplicationStateId).IsModified = false;
                entityAppSub.Property(it => it.ApplicationId).IsModified = false;
            }
            else
            {
                applicationSubmission.ApplicationStateId = ApplicationStatesEnum.Draft;
                _context.ApplicationSubmissions.Add(applicationSubmission);
            }

            await _context.SaveChangesAsync();

            return GetSuccessResult(applicationSubmission);
        }
    }
}
