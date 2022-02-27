using App.Applications.DTOs;
using App.Common.Interfaces;
using App.Common.Models;
using App.SelectFields.DTOs;
using Domain.Entities.Base.FieldTypes;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.SelectFields.Commands
{
    public class CreateUpdateSelectFieldCommand : IRequestWrapper<SelectFieldDto>
    {
        public int GroupId { get; set; }
        public SelectFieldDto SelectField { get; set; }
    }

    class CreateUpdateSelectFieldCommandHandler : IRequestHandlerWrapper<CreateUpdateSelectFieldCommand, SelectFieldDto>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public CreateUpdateSelectFieldCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<SelectFieldDto>> Handle(CreateUpdateSelectFieldCommand request, CancellationToken cancellationToken)
        {
            var selectField = new SelectField()
            {
                Id = request.SelectField.Id,
                ApplicationGroupId = request.GroupId,
             //   FieldTypeId = request.SelectField.FieldTypeId,
                Description = request.SelectField.Description,
                IsRequired = request.SelectField.IsRequired,
                Label = request.SelectField.Label,
                SelectRestriction = new Domain.Entities.Base.FieldRestrictions.SelectRestriction()
                {
                    MaxCount = request.SelectField.SelectRestriction.MaxCount,
                    MinCount = request.SelectField.SelectRestriction.MinCount
                }
            };

            if (selectField.Id != 0) // update
            {
                applicationContext.SelectFields.Update(selectField);
            }
            else // create
            {
                await applicationContext.SelectFields.AddAsync(selectField, cancellationToken);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(mapper.Map<SelectFieldDto>(selectField));
        }
    }
}
