using App.Common.Interfaces;
using App.Common.Models;
using App.Fields.DTOs;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldTypes;
using Infrastructure.Persistence;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Fields.Commands
{
    public class CreateUpdateFiledsCommand : IRequestWrapper<IEnumerable<Field>>
    {
        public int GroupId { get; set; }
        public List<FieldDto> Fields { get; set; }
    }

    class CreateUpdateFiledsCommandHandler : IRequestHandlerWrapper<CreateUpdateFiledsCommand, IEnumerable<Field>>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;

        public CreateUpdateFiledsCommandHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
        }

        public async Task<ServiceResult<IEnumerable<Field>>> Handle(CreateUpdateFiledsCommand request, CancellationToken cancellationToken)
        {
            List<Field> fields = new List<Field>();

            foreach(var it in request.Fields)
            {
                switch(it.FieldTypeId)
                {
                    case 1:
                        var inputField = new InputField()
                        {
                            Id = it.Id,
                            ApplicationGroupId = request.GroupId,
                            FieldTypeId = it.FieldTypeId,
                            Description = it.Description,
                            IsRequired = it.IsRequired,
                            Label = it.Label,
                        };

                        if (it.Id != 0) // update
                        {
                            applicationContext.InputFields.Update(inputField);
                        }
                        else // create
                        {
                            await applicationContext.InputFields.AddAsync(inputField, cancellationToken);
                        }

                        fields.Add(inputField);

                        break;
                    case 2:
                        var selectField = new SelectField()
                        {
                            Id = it.Id,
                            ApplicationGroupId = request.GroupId,
                            FieldTypeId = it.FieldTypeId,
                            Description = it.Description,
                            IsRequired = it.IsRequired,
                            Label = it.Label,
                        };

                        if (it.Id != 0) // update
                        {
                            applicationContext.SelectFields.Update(selectField);
                        }
                        else // create
                        {
                            await applicationContext.SelectFields.AddAsync(selectField, cancellationToken);
                        }

                        fields.Add(selectField);

                        break;
                }
                
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(fields.AsEnumerable<Field>());
        }
    }
}
