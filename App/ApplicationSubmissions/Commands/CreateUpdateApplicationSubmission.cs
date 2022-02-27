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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Applications.DTOs;
using MapsterMapper;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace App.ApplicationSubmissions.Commands
{
    public class CreateUpdateApplicationSubmissionCommand : IRequestWrapper<Application>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ApplicationGroupRequest> Groups { get; set; }
    }

    class CreateUpdateApplicationSubmissionCommandHandler : IRequestHandlerWrapper<CreateUpdateApplicationSubmissionCommand, Application>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public CreateUpdateApplicationSubmissionCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<Application>> Handle(CreateUpdateApplicationSubmissionCommand request, CancellationToken cancellationToken)
        {
            var application = new Application()
            {
                Id = request.Id,
                Name = request.Name,
                Created = DateTime.Now.ToUniversalTime(),
                Updated = DateTime.Now.ToUniversalTime(),
                Description = request.Description,
                FieldGroups = mapper.Map<List<ApplicationGroup>>(request.Groups)
            };

            if (application.Id != 0) // update
            {
                applicationContext.Applications.Update(application);
            }
            else // create
            {
                application.Created = DateTime.Now.ToUniversalTime();
                await applicationContext.Applications.AddAsync(application);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(application);
        }
    }
}
