using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace Application
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<InnovativeDevelopment> InnovativeDevelopments { get; set; }

        public DbSet<ScientificSchool> ScientificSchools { get; set; }

        public DbSet<InfrastructureProject> InfrastructureProjects { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationState>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<BranchScience>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<CriticalTechnology>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<Efficiency>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

            });

            modelBuilder.Entity<FullScaleSample>(entity =>
            {
                entity.HasIndex(it => it.Location).IsUnique();
                entity.Property(it => it.Location).IsRequired().HasMaxLength(500);

            });

            modelBuilder.Entity<Grant>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.SourceOfFinancing).HasMaxLength(5000);
                entity.Property(it => it.FundingVolume).HasMaxLength(13);
            });

            modelBuilder.Entity<GRNTI>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.Code).HasMaxLength(10);
            });

            modelBuilder.Entity<InfrastructureCustomer>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.Contract).HasMaxLength(3000);
                entity.Property(it => it.Subject).HasMaxLength(150);
                entity.Property(it => it.Deadline).HasMaxLength(13);
            });

            modelBuilder.Entity<InfrastructurePhoto>(entity =>
            {
                entity.HasIndex(it => it.Location).IsUnique();
                entity.Property(it => it.Location).IsRequired().HasMaxLength(500);
            });

            modelBuilder.Entity<InfrastructureProject>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.Location).HasMaxLength(500);
                entity.Property(it => it.Location).HasMaxLength(500);
            });

            modelBuilder.Entity<InfrastructureProjectRealization>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.HasIndex(it => it.Subject).IsUnique();
                entity.Property(it => it.Subject).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<InfrastructureResearch>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.Subject).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Contract).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Subject).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<InfrastructureServiceProvided>(entity =>
            {
                entity.Property(it => it.PriorityDirectionNTRRF).HasMaxLength(150);
                entity.Property(it => it.ShortDescription).HasMaxLength(1000);
            });

            modelBuilder.Entity<InfrastructureSpecialist>(entity =>
            {
                entity.Property(it => it.FullName).IsRequired().HasMaxLength(150);
                entity.Property(it => it.WorkingConditions).HasMaxLength(150);
                entity.Property(it => it.PrimaryFunctions).HasMaxLength(150);
                entity.Property(it => it.EducationDescription).HasMaxLength(150);
            });

            modelBuilder.Entity<InfrastructureTechnicalEquipment>(entity =>
            {
                entity.Property(it => it.ApplicationArea).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Manufacturer).HasMaxLength(150);
                entity.Property(it => it.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<InfrastructureTypeEquipment>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<InnovativeDevelopment>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.StartWork);

                entity.Property(it => it.Appointment).HasMaxLength(5000);
                entity.Property(it => it.ApplicationArea).HasMaxLength(5000);
                entity.Property(it => it.Specifications).HasMaxLength(5000);
                entity.Property(it => it.SignsOfTechnicalSolution).HasMaxLength(5000);
                entity.Property(it => it.PositiveResult).HasMaxLength(5000);
                entity.Property(it => it.MethodOfApplication).HasMaxLength(5000);
                entity.Property(it => it.Competitiveness).HasMaxLength(5000);
                entity.Property(it => it.EconomicEffect).HasMaxLength(5000);
                entity.Property(it => it.ImplementationExperience).HasMaxLength(5000);
                entity.Property(it => it.SourcesOfFinancing).HasMaxLength(5000);

                entity
                    .HasCheckConstraint("CC_StartEndWork",
                                    "\"StartWork\" <= \"EndWork\"")

                    .HasCheckConstraint("CC_Email",
                                   "\"Email\" ~* '^[A-Z0-9._%-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$)'")

                    .HasCheckConstraint("CC_Phone",
                                   "\"Phone\" ~* '^[0 - 9\\.] +$)'");

            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(it => it.Surname).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Patronymic).HasMaxLength(150);
                entity.Property(it => it.AcademicDegree).HasMaxLength(150);
                entity.Property(it => it.AcademicRank).HasMaxLength(150);

            });

            modelBuilder.Entity<Patent>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Number).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<PresentationMaterial>(entity =>
            {
                entity.HasIndex(it => it.Location).IsUnique();
                entity.Property(it => it.Location).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<PriorityDirection>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.Property(it => it.Type).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
                entity.Property(it => it.Authors).IsRequired().HasMaxLength(500);
                entity.Property(it => it.DOI).IsRequired().HasMaxLength(500);
                entity.Property(it => it.Link).IsRequired().HasMaxLength(500);
                entity.Property(it => it.Quartile).IsRequired().HasMaxLength(500);
            });

            modelBuilder.Entity<ReadinessDegree>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<ResearchDirection>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<ScientificSchool>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);

                entity.Property(it => it.AnnotatedDescription).IsRequired().HasMaxLength(5000);
                entity.Property(it => it.Story).IsRequired().HasMaxLength(5000);
            });

            modelBuilder.Entity<TypeResearch>(entity =>
            {
                entity.HasIndex(it => it.Name).IsUnique();
                entity.Property(it => it.Name).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<User>()
                .HasCheckConstraint("CC_FirstActivityLastActivity",
                                    "\"FirstActivity\" <= \"LastActivity\"");
        }
    }
}
