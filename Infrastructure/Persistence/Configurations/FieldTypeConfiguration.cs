using Domain.Entities.Base;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class FieldTypeConfiguration : IEntityTypeConfiguration<FieldType>
    {
        public void Configure(EntityTypeBuilder<FieldType> builder)
        {
            builder.HasData(new List<FieldType>()
            {
                new FieldType()
                {
                    Id = (int)FieldTypesEnum.Input,
                    Name="Input"
                },

                new FieldType()
                {
                    Id =  (int)FieldTypesEnum.Select,
                    Name = "Select"
                },

                new FieldType()
                {
                    Id =  (int)FieldTypesEnum.FieldType,
                    Name = "FieldType"
                }
            });
        }
    }
}
