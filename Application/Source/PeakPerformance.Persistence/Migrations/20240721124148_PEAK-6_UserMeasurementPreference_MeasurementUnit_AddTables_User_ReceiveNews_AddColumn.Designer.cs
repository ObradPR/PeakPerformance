﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeakPerformance.Persistence.Contexts;

#nullable disable

namespace PeakPerformance.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721124148_PEAK-6_UserMeasurementPreference_MeasurementUnit_AddTables_User_ReceiveNews_AddColumn")]
    partial class PEAK6_UserMeasurementPreference_MeasurementUnit_AddTables_User_ReceiveNews_AddColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.ErrorLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("InnerException")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("ReceiveAppNews")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("FirstName", "MiddleName", "LastName");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("FirstName", "MiddleName", "LastName"), new[] { "DateOfBirth" });

                    b.ToTable("Users", t =>
                        {
                            t.HasTrigger("trg_Users_aud");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.UserActivityLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserActivityLogs");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.UserMeasurementPreference", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MeasurementUnitId")
                        .HasColumnType("int");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("WeightUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementUnitId");

                    b.HasIndex("WeightUnitId");

                    b.HasIndex("UserId", "WeightUnitId", "MeasurementUnitId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UserMeasurementPreferences", t =>
                        {
                            t.HasTrigger("trg_UserMeasurementPreferences_aud");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UserRoles", t =>
                        {
                            t.HasTrigger("trg_UserRoles_aud");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application_lu.ActionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ActionTypes_lu", (string)null);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application_lu.MeasurementUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MeasurementUnits_lu", (string)null);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application_lu.SystemRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SystemRoles_lu", (string)null);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Audits.UserMeasurementPreference_aud", b =>
                {
                    b.Property<long>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AuditId"));

                    b.Property<int?>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetailsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("AuditId");

                    b.HasIndex("ActionTypeId");

                    b.ToTable("UserMeasurementPreferences_aud", (string)null);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Audits.UserRole_aud", b =>
                {
                    b.Property<long>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AuditId"));

                    b.Property<int?>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetailsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("AuditId");

                    b.HasIndex("ActionTypeId");

                    b.ToTable("UserRoles_aud", (string)null);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Audits.User_aud", b =>
                {
                    b.Property<long>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AuditId"));

                    b.Property<int?>("ActionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetailsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("ModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("AuditId");

                    b.HasIndex("ActionTypeId");

                    b.ToTable("Users_aud", (string)null);
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.UserActivityLog", b =>
                {
                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.ActionType", "ActionType")
                        .WithMany("UserActivityLogs")
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PeakPerformance.Domain.Entities.Application.User", "User")
                        .WithMany("UserActivityLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.UserMeasurementPreference", b =>
                {
                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.MeasurementUnit", "MeasurementUnit")
                        .WithMany("MeasurementUnitPreferences")
                        .HasForeignKey("MeasurementUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PeakPerformance.Domain.Entities.Application.User", "User")
                        .WithMany("UserMeasurementPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.MeasurementUnit", "WeightUnit")
                        .WithMany("WeightUnitPreferences")
                        .HasForeignKey("WeightUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MeasurementUnit");

                    b.Navigation("User");

                    b.Navigation("WeightUnit");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.UserRole", b =>
                {
                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.SystemRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PeakPerformance.Domain.Entities.Application.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Audits.UserMeasurementPreference_aud", b =>
                {
                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.ActionType", "ActionType")
                        .WithMany()
                        .HasForeignKey("ActionTypeId");

                    b.Navigation("ActionType");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Audits.UserRole_aud", b =>
                {
                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.ActionType", "ActionType")
                        .WithMany("UserRoles_aud")
                        .HasForeignKey("ActionTypeId");

                    b.Navigation("ActionType");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Audits.User_aud", b =>
                {
                    b.HasOne("PeakPerformance.Domain.Entities.Application_lu.ActionType", "ActionType")
                        .WithMany("Users_aud")
                        .HasForeignKey("ActionTypeId");

                    b.Navigation("ActionType");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application.User", b =>
                {
                    b.Navigation("UserActivityLogs");

                    b.Navigation("UserMeasurementPreferences");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application_lu.ActionType", b =>
                {
                    b.Navigation("UserActivityLogs");

                    b.Navigation("UserRoles_aud");

                    b.Navigation("Users_aud");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application_lu.MeasurementUnit", b =>
                {
                    b.Navigation("MeasurementUnitPreferences");

                    b.Navigation("WeightUnitPreferences");
                });

            modelBuilder.Entity("PeakPerformance.Domain.Entities.Application_lu.SystemRole", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
