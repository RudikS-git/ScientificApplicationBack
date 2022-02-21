using Domain.Entities.Base;
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
                    Id = 1,
                    Name="Input"
                },

                new FieldType()
                {
                    Id = 2,
                    Name = "Select"
                },

                new FieldType()
                {
                    Id = 3,
                    Name = "Entity"
                }
            });
        }
    }
}
