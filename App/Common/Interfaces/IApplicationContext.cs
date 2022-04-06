using Domain.Entities.Base;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Common.Interfaces
{
    public interface IApplicationContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationState> ApplicationStates { get; set; }
        public DbSet<ApplicationSubmission> ApplicationSubmissions { get; set; }

        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<InputField> InputFields { get; set; }
        public DbSet<SelectField> SelectFields { get; set; }
        public DbSet<FieldSet> EntityFields { get; set; }

        public DbSet<SelectOption> SelectOptions { get; set; }

        public DbSet<InputNumberField> InputNumberRestrictions { get; set; }
        public DbSet<InputDateField> InputDateRestrictions { get; set; }
        public DbSet<InputTextField> InputInputTextRestrictions { get; set; }
        public DbSet<InputNumberPhoneField> InputNumberPhoneRestrictions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        
    }
}
