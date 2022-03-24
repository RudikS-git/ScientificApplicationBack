using Domain.Entities.Base;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
    {
        public void Configure(EntityTypeBuilder<ApplicationState> builder)
        {
            builder.HasData(new List<ApplicationState>()
            {
                new ApplicationState()
                {
                    Id = (int)ApplicationStates.Draft,
                    Name="Черновик"
                },

                new ApplicationState()
                {
                    Id = (int)ApplicationStates.Checked,
                    Name = "На проверке"
                },

                new ApplicationState()
                {
                    Id = (int)ApplicationStates.Rejected,
                    Name = "Отклонено"
                },

                new ApplicationState()
                {
                    Id = (int)ApplicationStates.Modification,
                    Name = "Отправлено на доработку"
                },

                 new ApplicationState()
                {
                    Id = (int)ApplicationStates.Accepted,
                    Name = "Согласовано"
                }
            });

            builder.HasIndex(it => it.Name).IsUnique();
            builder.Property(it => it.Name).IsRequired().HasMaxLength(150);
        }
    }
}
