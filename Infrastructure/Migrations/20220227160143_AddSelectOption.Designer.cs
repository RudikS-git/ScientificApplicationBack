﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220227160143_AddSelectOption")]
    partial class AddSelectOption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Base.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<string>("SystemName")
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("ApplicationGroup");
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ApplicationState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Черновик"
                        },
                        new
                        {
                            Id = 2,
                            Name = "На проверке"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Отклонено"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Отправлено на доработку"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Согласовано"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<int?>("ApplicationStateId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ApplicationStateId");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.SelectRestriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxCount")
                        .HasColumnType("integer");

                    b.Property<int>("MinCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SelectRestriction");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldSubmissions.InputSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("InputFieldId")
                        .HasColumnType("integer");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InputFieldId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("InputSubmission");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldSubmissions.SelectSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SelectFieldId")
                        .HasColumnType("integer");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SelectFieldId");

                    b.HasIndex("SubmissionId");

                    b.ToTable("SelectSubmission");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FieldTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Input"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Select"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Entity"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.FieldSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<int?>("SelectSubmissionId")
                        .HasColumnType("integer");

                    b.Property<string>("SystemName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationGroupId");

                    b.HasIndex("SelectSubmissionId");

                    b.ToTable("FieldSet");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.InputField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<string>("SystemName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InputFields");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.SelectField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("FieldSetId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAsync")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMultiple")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean");

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<int>("SelectRestrictionId")
                        .HasColumnType("integer");

                    b.Property<string>("SystemName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationGroupId");

                    b.HasIndex("FieldSetId");

                    b.HasIndex("SelectRestrictionId");

                    b.ToTable("SelectField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.SelectOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("SelectFieldId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SelectFieldId");

                    b.ToTable("SelectOption");
                });

            modelBuilder.Entity("Domain.Entities.Base.HistoryApplicationState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationSubmissionId")
                        .HasColumnType("integer");

                    b.Property<int?>("ChangedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastApplicationStateId")
                        .HasColumnType("integer");

                    b.Property<int?>("NewApplicationStateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationSubmissionId");

                    b.HasIndex("ChangedUserId");

                    b.HasIndex("LastApplicationStateId");

                    b.HasIndex("NewApplicationStateId");

                    b.ToTable("HistoryApplicationState");
                });

            modelBuilder.Entity("Domain.Entities.Base.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SystemName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Domain.Entities.Base.UnderTypes.InputUnderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InputUnderType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Text"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Date"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Time"
                        },
                        new
                        {
                            Id = 4,
                            Name = "DateTime"
                        },
                        new
                        {
                            Id = 5,
                            Name = "NumberPhone"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Email"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Number"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Float number"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Base.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FirstActivity")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastActivity")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasCheckConstraint("CC_FirstActivityLastActivity", "\"FirstActivity\" <= \"LastActivity\"");
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("PermissionsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("PermissionUser");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputDateField", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.FieldTypes.InputField");

                    b.Property<int?>("FieldSetId")
                        .HasColumnType("integer");

                    b.Property<int>("InputFieldId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MaxDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("MinDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasIndex("ApplicationGroupId");

                    b.HasIndex("FieldSetId");

                    b.HasIndex("InputFieldId");

                    b.ToTable("InputDateField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputNumberField", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.FieldTypes.InputField");

                    b.Property<int?>("FieldSetId")
                        .HasColumnType("integer");

                    b.Property<int>("InputFieldId")
                        .HasColumnType("integer");

                    b.Property<int>("Max")
                        .HasColumnType("integer");

                    b.Property<int>("Min")
                        .HasColumnType("integer");

                    b.HasIndex("ApplicationGroupId");

                    b.HasIndex("FieldSetId");

                    b.HasIndex("InputFieldId");

                    b.ToTable("InputNumberField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputNumberPhoneField", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.FieldTypes.InputField");

                    b.Property<int?>("FieldSetId")
                        .HasColumnType("integer");

                    b.Property<int>("InputFieldId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasIndex("ApplicationGroupId");

                    b.HasIndex("FieldSetId");

                    b.HasIndex("InputFieldId");

                    b.ToTable("InputNumberPhoneField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputTextField", b =>
                {
                    b.HasBaseType("Domain.Entities.Base.FieldTypes.InputField");

                    b.Property<int?>("FieldSetId")
                        .HasColumnType("integer");

                    b.Property<int>("InputFieldId")
                        .HasColumnType("integer");

                    b.Property<int>("MaxLength")
                        .HasColumnType("integer");

                    b.Property<int>("MinLength")
                        .HasColumnType("integer");

                    b.HasIndex("ApplicationGroupId");

                    b.HasIndex("FieldSetId");

                    b.HasIndex("InputFieldId");

                    b.ToTable("InputTextField");
                });

            modelBuilder.Entity("Domain.Entities.Base.Application", b =>
                {
                    b.HasOne("Domain.Entities.Base.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId");

                    b.HasOne("Domain.Entities.Base.User", null)
                        .WithMany("Applications")
                        .HasForeignKey("UserId");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationGroup", b =>
                {
                    b.HasOne("Domain.Entities.Base.Application", null)
                        .WithMany("FieldGroups")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationSubmission", b =>
                {
                    b.HasOne("Domain.Entities.Base.Application", "Application")
                        .WithMany("ApplicationSubmissions")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.ApplicationState", "ApplicationState")
                        .WithMany()
                        .HasForeignKey("ApplicationStateId");

                    b.HasOne("Domain.Entities.Base.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("ApplicationState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldSubmissions.InputSubmission", b =>
                {
                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", "InputField")
                        .WithMany()
                        .HasForeignKey("InputFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.ApplicationSubmission", "Submission")
                        .WithMany("InputSubmissions")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InputField");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldSubmissions.SelectSubmission", b =>
                {
                    b.HasOne("Domain.Entities.Base.FieldTypes.SelectField", "SelectField")
                        .WithMany()
                        .HasForeignKey("SelectFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.ApplicationSubmission", "Submission")
                        .WithMany("SelectSubmissions")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelectField");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.FieldSet", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationGroup", "ApplicationGroup")
                        .WithMany("FieldSets")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldSubmissions.SelectSubmission", null)
                        .WithMany("Values")
                        .HasForeignKey("SelectSubmissionId");

                    b.Navigation("ApplicationGroup");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.SelectField", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationGroup", "ApplicationGroup")
                        .WithMany("SelectFields")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.FieldSet", null)
                        .WithMany("SelectFields")
                        .HasForeignKey("FieldSetId");

                    b.HasOne("Domain.Entities.Base.FieldRestrictions.SelectRestriction", "SelectRestriction")
                        .WithMany()
                        .HasForeignKey("SelectRestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationGroup");

                    b.Navigation("SelectRestriction");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.SelectOption", b =>
                {
                    b.HasOne("Domain.Entities.Base.FieldTypes.SelectField", null)
                        .WithMany("Options")
                        .HasForeignKey("SelectFieldId");
                });

            modelBuilder.Entity("Domain.Entities.Base.HistoryApplicationState", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationSubmission", null)
                        .WithMany("HistoryApplicationStates")
                        .HasForeignKey("ApplicationSubmissionId");

                    b.HasOne("Domain.Entities.Base.User", "ChangedUser")
                        .WithMany()
                        .HasForeignKey("ChangedUserId");

                    b.HasOne("Domain.Entities.Base.ApplicationState", "LastApplicationState")
                        .WithMany()
                        .HasForeignKey("LastApplicationStateId");

                    b.HasOne("Domain.Entities.Base.ApplicationState", "NewApplicationState")
                        .WithMany()
                        .HasForeignKey("NewApplicationStateId");

                    b.Navigation("ChangedUser");

                    b.Navigation("LastApplicationState");

                    b.Navigation("NewApplicationState");
                });

            modelBuilder.Entity("PermissionUser", b =>
                {
                    b.HasOne("Domain.Entities.Base.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputDateField", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationGroup", "ApplicationGroup")
                        .WithMany("InputDataFields")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.FieldSet", null)
                        .WithMany("InputDateFields")
                        .HasForeignKey("FieldSetId");

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Base.FieldRestrictions.InputDateField", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", "InputField")
                        .WithMany()
                        .HasForeignKey("InputFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationGroup");

                    b.Navigation("InputField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputNumberField", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationGroup", "ApplicationGroup")
                        .WithMany("InputNumberFields")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.FieldSet", null)
                        .WithMany("InputNumberFields")
                        .HasForeignKey("FieldSetId");

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Base.FieldRestrictions.InputNumberField", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", "InputField")
                        .WithMany()
                        .HasForeignKey("InputFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationGroup");

                    b.Navigation("InputField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputNumberPhoneField", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationGroup", "ApplicationGroup")
                        .WithMany("InputNumberPhoneFields")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.FieldSet", null)
                        .WithMany("InputNumberPhoneFields")
                        .HasForeignKey("FieldSetId");

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Base.FieldRestrictions.InputNumberPhoneField", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", "InputField")
                        .WithMany()
                        .HasForeignKey("InputFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationGroup");

                    b.Navigation("InputField");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldRestrictions.InputTextField", b =>
                {
                    b.HasOne("Domain.Entities.Base.ApplicationGroup", "ApplicationGroup")
                        .WithMany("InputTextFields")
                        .HasForeignKey("ApplicationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.FieldSet", null)
                        .WithMany("InputTextFields")
                        .HasForeignKey("FieldSetId");

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", null)
                        .WithOne()
                        .HasForeignKey("Domain.Entities.Base.FieldRestrictions.InputTextField", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Base.FieldTypes.InputField", "InputField")
                        .WithMany()
                        .HasForeignKey("InputFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationGroup");

                    b.Navigation("InputField");
                });

            modelBuilder.Entity("Domain.Entities.Base.Application", b =>
                {
                    b.Navigation("ApplicationSubmissions");

                    b.Navigation("FieldGroups");
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationGroup", b =>
                {
                    b.Navigation("FieldSets");

                    b.Navigation("InputDataFields");

                    b.Navigation("InputNumberFields");

                    b.Navigation("InputNumberPhoneFields");

                    b.Navigation("InputTextFields");

                    b.Navigation("SelectFields");
                });

            modelBuilder.Entity("Domain.Entities.Base.ApplicationSubmission", b =>
                {
                    b.Navigation("HistoryApplicationStates");

                    b.Navigation("InputSubmissions");

                    b.Navigation("SelectSubmissions");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldSubmissions.SelectSubmission", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.FieldSet", b =>
                {
                    b.Navigation("InputDateFields");

                    b.Navigation("InputNumberFields");

                    b.Navigation("InputNumberPhoneFields");

                    b.Navigation("InputTextFields");

                    b.Navigation("SelectFields");
                });

            modelBuilder.Entity("Domain.Entities.Base.FieldTypes.SelectField", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Domain.Entities.Base.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Submissions");
                });
#pragma warning restore 612, 618
        }
    }
}
