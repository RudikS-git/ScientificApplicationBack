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
using Infrastructure.Persistence;

namespace App.Applications.Commands
{
    public class DeleteApplicationByIdCommand : IRequestWrapper<Application>
    {
       public int Id { get; set; }
    }

    class DeleteApplicationByIdCommandHandler : IRequestHandlerWrapper<DeleteApplicationByIdCommand, Application>
    {
        private readonly IApplicationContext applicationContext;

        public DeleteApplicationByIdCommandHandler(IApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<ServiceResult<Application>> Handle(DeleteApplicationByIdCommand command, CancellationToken cancellationToken)
        {
            var application = applicationContext.Applications.Where(it => it.Id == command.Id).FirstOrDefault();

            if (application == null)
            {
                return ServiceResult.Failed<Application>(new ServiceError());
            }

            applicationContext.Applications.Remove(application);
            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(application);
        }
    }
}
