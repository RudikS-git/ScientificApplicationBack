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
    public class ApplicationStateConfiguration : IEntityTypeConfiguration<ApplicationState>
    {
        public void Configure(EntityTypeBuilder<ApplicationState> builder)
        {
            builder.HasData(new List<ApplicationState>()
            {
                new ApplicationState()
                {
                    Id = 1,
                    Name="Черновик"
                },

                new ApplicationState()
                {
                    Id = 2,
                    Name = "На проверке"
                },

                new ApplicationState()
                {
                    Id = 3,
                    Name = "Отклонено"
                },

                new ApplicationState()
                {
                    Id = 4,
                    Name = "Отправлено на доработку"
                },

                 new ApplicationState()
                {
                    Id = 5,
                    Name = "Согласовано"
                }
            });
        }
    }
}
