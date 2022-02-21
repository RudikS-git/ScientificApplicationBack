using Domain.Entities;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldTypes;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<InputField> InputFields { get; set; }
        public DbSet<SelectField> SelectFields { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
            : base(options)
        {
          //  Database.EnsureCreated();

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
            modelBuilder.ApplyConfiguration(new FieldTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationStateConfiguration());
            /*  Task initDBTask = Task.WhenAll(new List<Task>
              {
                  InitializeDatabase<ApplicationState>(modelBuilder, "ApplicationState.json"),
                  InitializeDatabase<Permission>(modelBuilder, "Permissions.json")
              });*/

            /* modelBuilder.Entity<ApplicationState>(entity =>
             {
                 entity.HasIndex(it => it.Name).IsUnique();
                 entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

             });*/

            /*
                            entity
                                .HasCheckConstraint("CC_StartEndWork",
                                                "\"StartWork\" <= \"EndWork\"")

                                .HasCheckConstraint("CC_Email",
                                               "\"Email\" ~* '^[A-Z0-9._%-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$)'")

                                .HasCheckConstraint("CC_Phone",
                                               "\"Phone\" ~* '^[0 - 9\\.] +$)'");*/

            modelBuilder.Entity<User>()
                .HasCheckConstraint("CC_FirstActivityLastActivity",
                                    "\"FirstActivity\" <= \"LastActivity\"");

           // await initDBTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
