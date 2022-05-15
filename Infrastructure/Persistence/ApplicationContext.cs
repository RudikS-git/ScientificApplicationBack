using App.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldRestrictions;
using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationContext : IdentityDbContext<User, Role, int>, IApplicationContext
    {
       // public DbSet<User> Users { get; set; }
       // public DbSet<Role> Roles { get; set; }
       //public DbSet<IdentityUserRole<int>> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroup { get; set; }
        public DbSet<ApplicationState> ApplicationStates { get; set; }
        public DbSet<ApplicationSubmission> ApplicationSubmissions { get; set; }

        public DbSet<FieldType> FieldTypes { get; set; }

        public DbSet<InputField> InputFields { get; set; }
        public DbSet<SelectField> SelectFields { get; set; }
        public DbSet<FieldSet> EntityFields { get; set; }

        public DbSet<SelectOption> SelectOptions { get; set; }

        public DbSet<InputNumberField> InputNumberFields { get; set; }
        public DbSet<InputDateField> InputDateFields { get; set; }
        public DbSet<InputTextField> InputTextFields { get; set; }
        public DbSet<InputNumberPhoneField> InputNumberPhoneFields { get; set; }

        public DbSet<HistoryApplicationState> HistoryApplicationStates { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
            : base(options)
        {
        //    Database.EnsureDeleted();
        //     Database.EnsureCreated();
        }

        async private Task InitializeDatabase<T>(ModelBuilder modelBuilder, string config) where T : class
        {
            using (StreamReader file = File.OpenText(Directory.GetCurrentDirectory() + $@"/../App/InitialData/{config}"))
            {
                T[] array = JsonConvert.DeserializeObject<T[]>(await file.ReadToEndAsync());

                foreach (T item in array)
                {
                    modelBuilder.Entity<T>().HasData(item);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(AppContext).Assembly);

            modelBuilder.HasDefaultSchema("Identity");
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.ToTable(name: "UserRole");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            /*  Task initDBTask = Task.WhenAll(new List<Task>
              {
                  InitializeDatabase<ApplicationState>(modelBuilder, "ApplicationState.json"),
                  InitializeDatabase<Permission>(modelBuilder, "Permissions.json")
              });*/

            /*
                            entity
                                .HasCheckConstraint("CC_StartEndWork",
                                                "\"StartWork\" <= \"EndWork\"")

                                .HasCheckConstraint("CC_Email",
                                               "\"Email\" ~* '^[A-Z0-9._%-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$)'")

                                .HasCheckConstraint("CC_Phone",
                                               "\"Phone\" ~* '^[0 - 9\\.] +$)'");*/

            /*            modelBuilder.Entity<User>()
                            .HasCheckConstraint("CC_FirstActivityLastActivity",
                                                "\"FirstActivity\" <= \"LastActivity\"");*/

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entities = ChangeTracker.Entries<AuditableBaseEntity>();

            foreach (EntityEntry<AuditableBaseEntity> entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(it => it.Updated).IsModified = false;
                        entry.Entity.Created = DateTime.UtcNow.ToUniversalTime();
                        break;
                    case EntityState.Modified:
                        entry.Property(it => it.Created).IsModified = false;
                        entry.Entity.Updated = DateTime.UtcNow.ToUniversalTime();
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public override EntityEntry<T> Entry<T>(T entity) where T: class
        {
            return base.Entry(entity);
        }
    }
}
