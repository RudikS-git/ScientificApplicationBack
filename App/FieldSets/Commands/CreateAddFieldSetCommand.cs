using App.Common.Interfaces;
using App.Common.Models;
using App.FieldSets.DTOs;
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

namespace App.FieldSets.Commands
{
    public class CreateAddEntityFieldCommandCommand : IRequestWrapper<FieldSetDto>
    {
        public int GroupId { get; set; }
        public FieldSetDto EntityFieldDto { get; set; }
    }

    class CreateAddEntityFieldCommandCommandCommandHandler : Handler<FieldSet, FieldSetDto>, IRequestHandlerWrapper<CreateAddEntityFieldCommandCommand, FieldSetDto>
    {

        public CreateAddEntityFieldCommandCommandCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
            : base (applicationContext, localizer, mapper)
        {
        }

        public async Task<ServiceResult<FieldSetDto>> Handle(CreateAddEntityFieldCommandCommand request, CancellationToken cancellationToken)
        {
            var entityField = _mapper.Map<FieldSet>(request.EntityFieldDto);
            entityField.ApplicationGroupId = request.GroupId;
            entityField.InputNumberPhoneFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);
            entityField.InputTextFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);
            entityField.InputDateFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);
            entityField.InputNumberFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);

            if (entityField.Id != 0)
            {
                _context.EntityFields.Update(entityField);
            }
            else
            {
                await _context.EntityFields.AddAsync(entityField, cancellationToken);
            }

            await _context.SaveChangesAsync();

            return GetSuccessResult(entityField);
        }
    }
}