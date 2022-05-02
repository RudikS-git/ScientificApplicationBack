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

namespace App.ApplicationSubmissions.Commands
{
    public class DeleteApplicationSubmissionCommand : IRequestWrapper<ApplicationSubmissionDto>
    {
        public int Id { get; set; }
    }

    class DeleteApplicationSubmissionCommandHandler : Handler<ApplicationSubmission, ApplicationSubmissionDto>, IRequestHandlerWrapper<DeleteApplicationSubmissionCommand, ApplicationSubmissionDto>
    {
        private readonly ICurrentUserService _userService;

        public DeleteApplicationSubmissionCommandHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper, ICurrentUserService userService)
            : base(context, localizer, mapper)
        {
            _userService = userService;
        }

        public async Task<ServiceResult<ApplicationSubmissionDto>> Handle(DeleteApplicationSubmissionCommand request, CancellationToken cancellationToken)
        {
            var applicationSubmission = await _context.ApplicationSubmissions.Where(it => it.Id == request.Id).FirstOrDefaultAsync();

            if (applicationSubmission == null)
            {
                return ServiceResult.Failed<ApplicationSubmissionDto>(ServiceError.NotFound);
            }

            _context.ApplicationSubmissions.Remove(applicationSubmission);
            await _context.SaveChangesAsync();

            return GetSuccessResult(applicationSubmission);
        }
    }
}
