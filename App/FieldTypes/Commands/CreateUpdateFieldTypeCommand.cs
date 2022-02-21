using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.FieldTypes.Commands
{
    /*public class CreateUpdateFieldTypeCommand : IRequestWrapper<IEnumerable<Field>>
    {
        public int GroupId { get; set; }
        public List<FieldDto> Fields { get; set; }
    }

    class CreateUpdateFieldTypeCommandHandler : IRequestHandlerWrapper<CreateUpdateFiledsCommand, IEnumerable<Field>>
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

            foreach (var it in request.Fields)
            {
                var field = new Field()
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
                    applicationContext.Fields.Update(field);
                }
                else // create
                {
                    await applicationContext.Fields.AddAsync(field, cancellationToken);
                }

                fields.Add(field);
            }

            await applicationContext.SaveChangesAsync();

            return ServiceResult.Success(fields.AsEnumerable<Field>());
        }
    }*/
 }

