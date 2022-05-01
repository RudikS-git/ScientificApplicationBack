using App.Common.Interfaces;
using App.Common.Models;
using App.InputFields.DTOs;
using App.InputFields.DTOs.InputFields;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using Domain.Enums;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
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

        public int InputFieldId { get; set; }
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
            if (request.Id == 0 && request.InputFieldId != 0) // создание нового подтипа input (update для input field)
            {
                var existingInputField = await _context.InputFields.SingleOrDefaultAsync(it => it.Id == request.InputFieldId);
                _context.InputFields.Remove(existingInputField);
                await _context.SaveChangesAsync();
            }

            InputField inputField = new InputField()
            {
                Id = request.InputFieldId,
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
                    inputDateField.ApplicationGroupId = request.GroupId;
                    inputDateField.Id = request.Id;
                    inputDateField.InputField = inputField;
                    inputDateField.InputField.InputUnderTypeId = InputUnderTypes.Date;
                    await Save(_context.InputDateFields, inputDateField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputDateFieldDto>(inputDateField)
                    );

                case InputUnderTypes.Text:
                    var textField = _mapper.Map<InputTextField>(request.TextField);
                    textField.ApplicationGroupId = request.GroupId;
                    textField.Id = request.Id;
                    textField.InputField = inputField;
                    textField.InputField.InputUnderTypeId = InputUnderTypes.Text;
                    await Save(_context.InputTextFields, textField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputTextFieldDto>(textField)
                    );

                case InputUnderTypes.Number:
                    var numberField = _mapper.Map<InputNumberField>(request.NumberField);
                    numberField.ApplicationGroupId = request.GroupId;
                    numberField.Id = request.Id;
                    numberField.InputField = inputField;
                    numberField.InputField.InputUnderTypeId = InputUnderTypes.Number;
                    await Save(_context.InputNumberFields, numberField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputNumberFieldDto>(numberField)
                    );

                case InputUnderTypes.NumberPhone:
                    var numberPhoneField = _mapper.Map<InputNumberPhoneField>(request.NumberPhoneField);
                    numberPhoneField.ApplicationGroupId = request.GroupId;
                    numberPhoneField.Id = request.Id;
                    numberPhoneField.InputField = inputField;
                    numberPhoneField.InputField.InputUnderTypeId = InputUnderTypes.NumberPhone;
                    await Save(_context.InputNumberPhoneFields, numberPhoneField, cancellationToken);

                    return ServiceResult.Success<InputFieldDto>(
                        _mapper.Map<InputNumberPhoneFieldDto>(numberPhoneField)
                    );

                default:
                    return ServiceResult.Failed<InputFieldDto>(ServiceError.NotFound);
            }
        }

        public async Task Save<T>(DbSet<T> dbSet, T savedInputField, CancellationToken cancellationToken) where T : BaseEntity
        {
            if (savedInputField.Id != 0)
            {
                dbSet.Update(savedInputField);
            }
            else
            {
                await dbSet.AddAsync(savedInputField, cancellationToken);
            }

            await _context.SaveChangesAsync();
        }
    }
}