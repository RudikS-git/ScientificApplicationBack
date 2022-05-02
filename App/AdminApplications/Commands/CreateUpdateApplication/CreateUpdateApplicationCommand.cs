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
using App.AdminApplications.DTOs;
using MapsterMapper;
using Mapster;
using Microsoft.EntityFrameworkCore;

using Response = App.AdminApplications.DTOs.ApplicationDto;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.AdminApplications.Commands
{
    public class CreateApplicationCommand : IRequestWrapper<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ApplicationGroupRequest> ApplicationGroups { get; set; }
    }

    class CreateApplicationCommandHandler : Handler<Application, Response>, 
                                            IRequestHandlerWrapper<CreateApplicationCommand, Response>
    {
        public CreateApplicationCommandHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<Response>> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            if(request.ApplicationGroups != null) // удаляем группы, которые не пришли, но есть в БД
            {
                var applicationGroups = 
                    await _context.ApplicationGroup
                        .Where(it => it.ApplicationId == request.Id && 
                                    !request.ApplicationGroups.Select(ag => ag.Id).ToArray().Contains(it.Id))
                        .ToListAsync();

                _context.ApplicationGroup.RemoveRange(applicationGroups);
            }

            var application = new Application()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ApplicationGroups = _mapper.Map<List<ApplicationGroup>>(request.ApplicationGroups),
            };

            if (application.Id != 0)
            {
                var appEntity = _context.Entry(application);
                appEntity.State = EntityState.Modified;
                appEntity.Property(x => x.ManageApplicationState).IsModified = false;
            }
            else
            {
                await _context.Applications.AddAsync(application);
            }

            await _context.SaveChangesAsync();

            return GetSuccessResult(application);
        }
    }
}
