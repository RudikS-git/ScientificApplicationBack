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
    public class CreateUpdateInputTextFieldCommand : IRequestWrapper<InputTextFieldDto>
    {
        public int GroupId { get; set; }
        public InputTextFieldDto InputField { get; set; }
    }

    class CreateUpdateInputTextFieldCommandHandler : IRequestHandlerWrapper<CreateUpdateInputTextFieldCommand, InputTextFieldDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public CreateUpdateInputTextFieldCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<InputTextFieldDto>> Handle(CreateUpdateInputTextFieldCommand request, CancellationToken cancellationToken)
        {
            var inputField = new InputField()
            {
                Id = request.InputField.Id,
                ApplicationGroupId = request.GroupId,
            //    FieldTypeId = request.InputField.FieldTypeId,
                Description = request.InputField.Description,
                IsRequired = request.InputField.IsRequired,
                Label = request.InputField.Label,
            //    InputUnderTypeId = request.InputField.InputUnderTypeId,
            };

            if (inputField.Id != 0)
            {
                applicationContext.InputFields.Update(inputField);
            }
            else
            {
                await applicationContext.InputFields.AddAsync(inputField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            var inputTextField = mapper.Map<InputTextField>(request.InputField);
            inputTextField.ApplicationGroupId = request.GroupId;
            inputTextField.InputFieldId = inputField.Id;

            if (inputField.Id != 0)
            {
                applicationContext.InputFields.Update(inputTextField);
            }
            else
            {
                await applicationContext.InputFields.AddAsync(inputTextField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<InputTextFieldDto>(inputTextField));
        }
    }
}