using App.Applications.DTOs;
using App.Common.Interfaces;
using App.Common.Models;
using Domain.Entities.Base.FieldTypes;
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
    public class DeleteInputFieldCommand : IRequestWrapper<InputFieldDto>
    {
        public int Id { get; set; }

        public DeleteInputFieldCommand(int id)
        {
            Id = id;
        }
    }

    class DeleteInputFieldCommanddHandler : Handler<InputField, InputFieldDto>, IRequestHandlerWrapper<DeleteInputFieldCommand, InputFieldDto>
    {
        public DeleteInputFieldCommanddHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<InputFieldDto>> Handle(DeleteInputFieldCommand command, CancellationToken cancellationToken)
        {
            var inputField = _context.InputFields.FirstOrDefault(it => it.Id == command.Id);

            if (inputField == null)
            {
                return ServiceResult.Failed<InputFieldDto>(ServiceError.NotFound);
            }

            _context.InputFields.Remove(inputField);
            await _context.SaveChangesAsync();

            return GetSuccessResult(inputField);
        }
    }
}
