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
    public class CreateUpdateInputNumberPhoneFieldCommand : IRequestWrapper<InputNumberPhoneFieldDto>
    {
        public int GroupId { get; set; }
        public InputNumberPhoneFieldDto InputField { get; set; }
    }

    class CreateUpdateInputNumberPhoneFieldCommandHandler : IRequestHandlerWrapper<CreateUpdateInputNumberPhoneFieldCommand, InputNumberPhoneFieldDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public CreateUpdateInputNumberPhoneFieldCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<InputNumberPhoneFieldDto>> Handle(CreateUpdateInputNumberPhoneFieldCommand request, CancellationToken cancellationToken)
        {
            var inputField = mapper.Map<InputField>(request.InputField);
            inputField.ApplicationGroupId = request.GroupId;

            if (inputField.Id != 0)
            {
                applicationContext.InputFields.Update(inputField);
            }
            else
            {
                await applicationContext.InputFields.AddAsync(inputField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            var inputNumberField = mapper.Map<InputNumberPhoneField>(request.InputField);
            inputNumberField.ApplicationGroupId = request.GroupId;
            inputNumberField.InputFieldId = inputField.Id;

            if (inputField.Id != 0)
            {
                applicationContext.InputFields.Update(inputNumberField);
            }
            else
            {
                await applicationContext.InputFields.AddAsync(inputNumberField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<InputNumberPhoneFieldDto>(inputNumberField));
        }
    }
}
