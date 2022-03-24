using Domain.Entities.Base.UnderTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

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
                    Id = (int)InputUnderTypes.Text,
                    Name="Text"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.Date,
                    Name = "Date"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.Time,
                    Name = "Time"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.DateTime,
                    Name = "DateTime"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.NumberPhone,
                    Name = "NumberPhone"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.Email,
                    Name = "Email"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.Number,
                    Name = "Number"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.FloatNumber,
                    Name = "Float number"
                },

                new InputUnderType()
                {
                    Id = (int)InputUnderTypes.File,
                    Name = "File"
                },

            });
        }
    }
}
