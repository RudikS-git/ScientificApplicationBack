using App.Common.Interfaces;
using App.Common.Models;
using MapsterMapper;
using Microsoft.Extensions.Localization;
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

    class DeleteInputFieldCommanddHandler : Handler, IRequestHandlerWrapper<DeleteInputFieldCommand, int>
    {
        public DeleteInputFieldCommanddHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<int>> Handle(DeleteInputFieldCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            var application = _context.Applications.Where(it => it.Id == command.Id).FirstOrDefault();

            if (application == null)
            {
                return ServiceResult.Failed<int>(new ServiceError());
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return ServiceResult.Success(0);
        }
    }
}
