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
using App.Applications.DTOs;
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

    class CreateUpdateApplicationSubmissionCommandHandler : IRequestHandlerWrapper<CreateUpdateApplicationSubmissionCommand, ApplicationSubmissionDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;
        private readonly ICurrentUserService _userService;

        public CreateUpdateApplicationSubmissionCommandHandler(IApplicationContext applicationContext, 
            IStringLocalizer<SharedResource> localizer, 
            IMapper mapper,
            ICurrentUserService userService)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
            _userService = userService;
        }

        public async Task<ServiceResult<ApplicationSubmissionDto>> Handle(CreateUpdateApplicationSubmissionCommand request, CancellationToken cancellationToken)
        {
            var applicationSubmission = mapper.Map<ApplicationSubmission>(request.ApplicationSubmission);

            applicationSubmission.SelectSubmissions = request.ApplicationSubmission.SelectSubmissions.Select(it =>
                new SelectSubmission()
                {
                    SelectFieldId = it.SelectFieldId,
                    Values = it.ValuesId.Select(value => new SelectSubmissonOptions() { SelectOptionId = value }).ToList()
                }
            ).ToList();

            applicationSubmission.UserId = _userService.UserId;

            if (applicationSubmission.Id != 0)
            {
                applicationContext.ApplicationSubmissions.Update(applicationSubmission);
            }
            else
            {
                await applicationContext.ApplicationSubmissions.AddAsync(applicationSubmission);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<ApplicationSubmissionDto>(applicationSubmission));
        }
    }
}
