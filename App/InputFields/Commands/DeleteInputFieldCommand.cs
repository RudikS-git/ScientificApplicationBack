using App.Common.Interfaces;
using App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.InputFields.Commands
{
    public class DeleteInputFieldCommand : IRequestWrapper<int>
    {
        public int Id { get; set; }
    }

    class DeleteInputFieldCommanddHandler : IRequestHandlerWrapper<DeleteInputFieldCommand, int>
    {
        private readonly IApplicationContext applicationContext;

        public DeleteInputFieldCommanddHandler(IApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<ServiceResult<int>> Handle(DeleteInputFieldCommand command, CancellationToken cancellationToken)
        {
            var application = applicationContext.Applications.Where(it => it.Id == command.Id).FirstOrDefault();

            if (application == null)
            {
                return ServiceResult.Failed<int>(new ServiceError());
            }

            applicationContext.Applications.Remove(application);
            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(0);
        }
    }
}
