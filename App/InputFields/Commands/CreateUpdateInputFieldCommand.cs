using App.Common.Interfaces;
using App.Common.Models;
using App.InputFields.DTOs;
using App.InputFields.DTOs.InputFields;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Domain.Enums;
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
    public class CreateUpdateInputFieldCommand : IRequestWrapper<InputFieldDto>
    {
        public int GroupId { get; set; }

        public InputUnderTypes InputUnderTypeId { get; set; }
        public int Id { get; set; }
        public bool IsRequired { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public InputTextFieldDto TextField { get; set; }
        public InputNumberFieldDto NumberField { get; set; }
        public InputDateFieldDto DateField { get; set; }
        public InputNumberPhoneFieldDto NumberPhoneField { get; set; }
    }

    class CreateUpdateInputFieldCommandHandler : Handler<InputField, InputFieldDto>, IRequestHandlerWrapper<CreateUpdateInputFieldCommand, InputFieldDto>
    {
        public CreateUpdateInputFieldCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<InputFieldDto>> Handle(CreateUpdateInputFieldCommand request, CancellationToken cancellationToken)
        {
            InputField inputField = new InputField()
            {
                Id = request.Id,
                ApplicationGroupId = request.GroupId,
                Description = request.Description,
                IsRequired = request.IsRequired,
                Label = request.Label,
                InputUnderTypeId = request.InputUnderTypeId,
            };

            switch (request.InputUnderTypeId)
            {
                case InputUnderTypes.Date:
                    var inputDateField = _mapper.Map<InputDateField>(request.DateField);
                    inputDateField.InputField = inputField;
                    await Save(inputDateField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputDateFieldDto>(inputDateField)
                    );

                case InputUnderTypes.Text:
                    var textField = _mapper.Map<InputTextField>(request.TextField);
                    textField.InputField = inputField;
                    await Save(textField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputTextFieldDto>(textField)
                    );

                case InputUnderTypes.Number:
                    var numberField = _mapper.Map<InputNumberField>(request.DateField);
                    numberField.InputField = inputField;
                    await Save(numberField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputNumberFieldDto>(numberField)
                    );

                case InputUnderTypes.NumberPhone:
                    var numberPhoneField = _mapper.Map<InputNumberPhoneField>(request.DateField);
                    numberPhoneField.InputField = inputField;
                    await Save(numberPhoneField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputNumberPhoneFieldDto>(numberPhoneField)
                    );

                default: 
                    return ServiceResult.Failed<InputFieldDto>(ServiceError.NotFound);
            }
        }

        public async Task Save(InputField savedInputField, CancellationToken cancellationToken)
        {
            if (savedInputField.Id != 0)
            {
                _context.InputFields.Update(savedInputField);
            }
            else
            {
                await _context.InputFields.AddAsync(savedInputField, cancellationToken);
            }

            await _context.SaveChangesAsync();
        }
    }
}