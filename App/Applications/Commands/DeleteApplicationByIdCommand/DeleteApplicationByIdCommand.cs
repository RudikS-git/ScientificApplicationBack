using App.Common.Models;
using App.Common.Interfaces;
using Domain.Entities.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using MapsterMapper;
using App.Applications.DTOs;

using Response = App.Applications.DTOs.ApplicationDto;

namespace App.Applications.Commands
{
    public class DeleteApplicationByIdCommand : IRequestWrapper<Response>
    {
       public int Id { get; set; }
    }

    class DeleteApplicationByIdCommandHandler : Handler<Application, Response>, IRequestHandlerWrapper<DeleteApplicationByIdCommand, Response>
    {
        public DeleteApplicationByIdCommandHandler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(context, localizer, mapper)
        {
        }

        public async Task<ServiceResult<Response>> Handle(DeleteApplicationByIdCommand command, CancellationToken cancellationToken)
        {
            var application = _context.Applications.Where(it => it.Id == command.Id).FirstOrDefault();

            if (application == null)
            {
                return ServiceResult.Failed<Response>(new ServiceError());
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return GetSuccessResult(application);
        }
    }
}
