using Domain.Entities.Base.UnderTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class InputUnderTypeConfiguration : IEntityTypeConfiguration<InputUnderType>
    {
        public void Configure(EntityTypeBuilder<InputUnderType> builder)
        {
            builder.HasData(new List<InputUnderType>()
            {
                new InputUnderType()
                {
                    Id = 1,
                    Name="Text"
                },

                new InputUnderType()
                {
                    Id = 2,
                    Name = "Date"
                },

                new InputUnderType()
                {
                    Id = 3,
                    Name = "Time"
                },

                new InputUnderType()
                {
                    Id = 4,
                    Name = "DateTime"
                },

                new InputUnderType()
                {
                    Id = 5,
                    Name = "NumberPhone"
                },

                new InputUnderType()
                {
                    Id = 6,
                    Name = "Email"
                },

                new InputUnderType()
                {
                    Id = 7,
                    Name = "Number"
                },

                new InputUnderType()
                {
                    Id = 8,
                    Name = "Float number"
                },
            });
        }
    }
}
