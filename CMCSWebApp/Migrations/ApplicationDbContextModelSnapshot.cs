﻿// <auto-generated />
using System;
using CMCSWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMCSWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMCSWebApp.Models.ClaimForm", b =>
                {
                    b.Property<int>("ClaimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimID"));

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<string>("LecturerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LecturerSurname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Programme")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("SubmissionDate")
                        .HasColumnType("date");

                    b.HasKey("ClaimID");

                    b.ToTable("ClaimForms");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Claims", b =>
                {
                    b.Property<int>("ClaimsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimsID"));

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("SubmissionDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ClaimsID");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("CMCSWebApp.Models.ItemsFeature", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<int>("ClaimID")
                        .HasColumnType("int");

                    b.Property<string>("DocumentPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemID");

                    b.HasIndex("ClaimID");

                    b.ToTable("ItemsFeatures");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Module", b =>
                {
                    b.Property<int>("ModuleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuleID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgrammeID")
                        .HasColumnType("int");

                    b.HasKey("ModuleID");

                    b.HasIndex("ProgrammeID");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Programme", b =>
                {
                    b.Property<int>("ProgrammeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgrammeID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgrammeID");

                    b.ToTable("Programmes");
                });

            modelBuilder.Entity("CMCSWebApp.Models.ReviewClaims", b =>
                {
                    b.Property<int>("ClaimID")
                        .HasColumnType("int");

                    b.Property<string>("ContactDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<string>("LecturerEmployeeNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("SubmissionDate")
                        .HasColumnType("date");

                    b.Property<string>("SupportingDocs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClaimID");

                    b.ToTable("ReviewClaims");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Roles", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CMCSWebApp.Models.SubmittedClaims", b =>
                {
                    b.Property<int>("ClaimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClaimID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Module")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ClaimID");

                    b.ToTable("SubmittedClaims");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CMCSWebApp.Models.ItemsFeature", b =>
                {
                    b.HasOne("CMCSWebApp.Models.ClaimForm", "ClaimForm")
                        .WithMany("SupportingDocs")
                        .HasForeignKey("ClaimID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClaimForm");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Module", b =>
                {
                    b.HasOne("CMCSWebApp.Models.Programme", "Programme")
                        .WithMany("Modules")
                        .HasForeignKey("ProgrammeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programme");
                });

            modelBuilder.Entity("CMCSWebApp.Models.ReviewClaims", b =>
                {
                    b.HasOne("CMCSWebApp.Models.ClaimForm", null)
                        .WithMany()
                        .HasForeignKey("ClaimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CMCSWebApp.Models.Users", b =>
                {
                    b.HasOne("CMCSWebApp.Models.Roles", null)
                        .WithMany("Users")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CMCSWebApp.Models.ClaimForm", b =>
                {
                    b.Navigation("SupportingDocs");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Programme", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("CMCSWebApp.Models.Roles", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
