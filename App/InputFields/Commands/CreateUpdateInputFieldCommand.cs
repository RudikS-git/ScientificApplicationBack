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
    public class CreateUpdateInputFieldCommand : IRequestWrapper<InputTextFieldDto>
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

    class CreateUpdateInputFieldCommandHandler : Handler<InputField, InputTextFieldDto>, IRequestHandlerWrapper<CreateUpdateInputFieldCommand, InputTextFieldDto>
    {
        public CreateUpdateInputFieldCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base(applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<InputTextFieldDto>> Handle(CreateUpdateInputFieldCommand request, CancellationToken cancellationToken)
        {
            InputField savedInputField = null;
            InputField inputField = new InputField()
            {
                Id = request.Id,
                ApplicationGroupId = request.GroupId,
                Description = request.Description,
                IsRequired = request.IsRequired,
                Label = request.Label,
                InputUnderTypeId = request.InputUnderTypeId
            };

            switch (request.InputUnderTypeId)
            {
                case InputUnderTypes.Date:
                    var inputDateField = _mapper.Map<InputDateField>(request.DateField);
                    inputDateField.InputField = inputField;
                    savedInputField = inputDateField;
                    break;

                case InputUnderTypes.Text:
                    var textField = _mapper.Map<InputTextField>(request.TextField);
                    textField.InputField = inputField;
                    savedInputField = textField;
                    break;

                case InputUnderTypes.Number:
                    var numberField = _mapper.Map<InputNumberField>(request.DateField);
                    numberField.InputField = inputField;
                    savedInputField = numberField;
                    break;

                case InputUnderTypes.NumberPhone:
                    var numberPhoneField = _mapper.Map<InputNumberPhoneField>(request.DateField);
                    numberPhoneField.InputField = inputField;
                    savedInputField = numberPhoneField;
                    break;
            }

            if (savedInputField.Id != 0)
            {
                _context.InputFields.Update(savedInputField);
            }
            else
            {
                await _context.InputFields.AddAsync(savedInputField, cancellationToken);
            }

            await _context.SaveChangesAsync();

            return GetSuccessResult(inputField);
        }
    }
}