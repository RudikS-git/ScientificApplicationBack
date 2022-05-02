using App.Common.Interfaces;
using App.Common.Models;
using Domain.Entities.Base;
using Domain.Entities.Enums;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Response = App.AdminApplications.DTOs.ApplicationDto;

namespace App.AdminApplications.Commands.SetManageApplicationStates
{
    public class SetApplicationStatesCommand : IRequestWrapper<Response>
    {
        public int Id { get; set; }
        public ManageApplicationStates ManageApplicationState { get; set; }

        public SetApplicationStatesCommand(int id, ManageApplicationStates state)
        {
            Id = id;
            ManageApplicationState = state;
        }
    }

    class SetApplicationStatesCommandHandler : Handler<Application, Response>, IRequestHandlerWrapper<SetApplicationStatesCommand, Response>
    {
        public SetApplicationStatesCommandHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<Response>> Handle(SetApplicationStatesCommand command, CancellationToken cancellationToken)
        {
            var application = _context.Applications.Where(it => it.Id == command.Id).FirstOrDefault();

            if (application == null)
            {
                return ServiceResult.Failed<Response>(new ServiceError());
            }

            application.ManageApplicationState = command.ManageApplicationState;

            _context.Applications.Update(application);
            await _context.SaveChangesAsync();

            return GetSuccessResult(application);
        }
    }
}
