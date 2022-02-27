using App.Common.Interfaces;
using App.Common.Models;
using App.InputFields.DTOs;
using App.InputFields.DTOs.InputFields;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldRestrictions;
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
    public class CreateUpdateInputDateFieldCommand : IRequestWrapper<InputDateFieldDto>
    {
        public int GroupId { get; set; }
        public InputDateFieldDto InputField { get; set; }
    }

    class CreateUpdateInputDateFieldCommandHandler : IRequestHandlerWrapper<CreateUpdateInputDateFieldCommand, InputDateFieldDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public CreateUpdateInputDateFieldCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<InputDateFieldDto>> Handle(CreateUpdateInputDateFieldCommand request, CancellationToken cancellationToken)
        {
            var inputDateField = mapper.Map<InputDateField>(request.InputField);
            inputDateField.InputField = new InputField()
            {
                Id = request.InputField.Id,
                ApplicationGroupId = request.GroupId,
                Description = request.InputField.Description,
                IsRequired = request.InputField.IsRequired,
                Label = request.InputField.Label,
            };

            if (inputDateField.Id != 0)
            {
                applicationContext.InputFields.Update(inputDateField);
            }
            else
            {
                await applicationContext.InputFields.AddAsync(inputDateField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<InputDateFieldDto>(inputDateField));
        }
    }
}
