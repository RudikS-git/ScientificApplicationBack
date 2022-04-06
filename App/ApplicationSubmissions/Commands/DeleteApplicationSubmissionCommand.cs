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

namespace App.ApplicationSubmissions.Commands
{
    public class DeleteApplicationSubmissionCommand : IRequestWrapper<ApplicationSubmissionDto>
    {
        public int Id { get; set; }
    }

    class DeleteApplicationSubmissionCommandHandler : IRequestHandlerWrapper<DeleteApplicationSubmissionCommand, ApplicationSubmissionDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;
        private readonly ICurrentUserService _userService;

        public DeleteApplicationSubmissionCommandHandler(IApplicationContext applicationContext,
            IStringLocalizer<SharedResource> localizer,
            IMapper mapper,
            ICurrentUserService userService)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
            _userService = userService;
        }

        public async Task<ServiceResult<ApplicationSubmissionDto>> Handle(DeleteApplicationSubmissionCommand request, CancellationToken cancellationToken)
        {
            var applicationSubmission = await applicationContext.ApplicationSubmissions.Where(it => it.Id == request.Id).FirstOrDefaultAsync();

            if (applicationSubmission == null)
            {
                return ServiceResult.Failed<ApplicationSubmissionDto>(ServiceError.NotFound);
            }
            
            applicationContext.ApplicationSubmissions.Remove(applicationSubmission);
            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<ApplicationSubmissionDto>(applicationSubmission));
        }
    }
}
