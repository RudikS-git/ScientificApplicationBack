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
using System.Linq;

namespace App.FieldSets.Commands
{
    public class CreateAddEntityFieldCommandCommand : IRequestWrapper<FieldSetDto>
    {
        public int GroupId { get; set; }
        public FieldSetDto EntityFieldDto { get; set; }
    }

    class CreateAddEntityFieldCommandCommandCommandHandler : IRequestHandlerWrapper<CreateAddEntityFieldCommandCommand, FieldSetDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public CreateAddEntityFieldCommandCommandCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<FieldSetDto>> Handle(CreateAddEntityFieldCommandCommand request, CancellationToken cancellationToken)
        {
            var entityField = mapper.Map<FieldSet>(request.EntityFieldDto);
            entityField.ApplicationGroupId = request.GroupId;
            entityField.InputNumberPhoneFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);
            entityField.InputTextFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);
            entityField.InputDateFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);
            entityField.InputNumberFields.ForEach(field => field.InputField.ApplicationGroupId = request.GroupId);

            if (entityField.Id != 0)
            {
                applicationContext.EntityFields.Update(entityField);
            }
            else
            {
                await applicationContext.EntityFields.AddAsync(entityField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<FieldSetDto>(entityField));
        }
    }
}