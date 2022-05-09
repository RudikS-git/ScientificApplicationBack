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
                    Id = ApplicationStatesEnum.Draft,
                    Name="Черновик"
                },

                new ApplicationState()
                {
                    Id = ApplicationStatesEnum.Checked,
                    Name = "На проверке"
                },

                new ApplicationState()
                {
                    Id = ApplicationStatesEnum.Rejected,
                    Name = "Отклонено"
                },

                new ApplicationState()
                {
                    Id = ApplicationStatesEnum.Modification,
                    Name = "Доработка"
                },

                 new ApplicationState()
                {
                    Id = ApplicationStatesEnum.Accepted,
                    Name = "Согласовано"
                }
            });

            builder.HasIndex(it => it.Name).IsUnique();
            builder.Property(it => it.Name).IsRequired()
                .HasMaxLength(150);

            builder.Property(it => it.Id).HasDefaultValue(ApplicationStatesEnum.Draft);
        }
    }
}
