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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasIndex(it => it.Name).IsUnique();
            builder.Property(it => it.Name).IsRequired()
                .HasMaxLength(150);
            builder.Property(it => it.ManageApplicationState).HasDefaultValue(ManageApplicationStates.Draft);
        }
    }
}
