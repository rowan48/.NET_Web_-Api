﻿// <auto-generated />
using System;
using ManageEmployeesVacations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManageEmployeesVacations.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221013082725_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ManageEmployeesVacations.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("GenderId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.EmployeeVacation", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("VacationID")
                        .HasColumnType("int");

                    b.Property<double>("EmployeeBalance")
                        .HasColumnType("double");

                    b.Property<double>("EmployeeusedVacation")
                        .HasColumnType("double");

                    b.HasKey("EmployeeID", "VacationID");

                    b.HasIndex("VacationID");

                    b.ToTable("EmployeeVacation");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GenderType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("GenderId");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.Vacation", b =>
                {
                    b.Property<int>("VacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("double");

                    b.Property<string>("VacationName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VacationId");

                    b.ToTable("Vacation");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.VacationRequest", b =>
                {
                    b.Property<int>("VacationRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndVacationDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("StartVacationDate")
                        .HasColumnType("Date");

                    b.Property<double>("VacationDuration")
                        .HasColumnType("double");

                    b.Property<int>("VacationID")
                        .HasColumnType("int");

                    b.HasKey("VacationRequestId");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("VacationID");

                    b.ToTable("VacationRequest");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.Employee", b =>
                {
                    b.HasOne("ManageEmployeesVacations.Models.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.EmployeeVacation", b =>
                {
                    b.HasOne("ManageEmployeesVacations.Models.Employee", "Employee")
                        .WithMany("EmployeeVacations")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageEmployeesVacations.Models.Vacation", "Vacation")
                        .WithMany("EmployeeVacations")
                        .HasForeignKey("VacationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Vacation");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.VacationRequest", b =>
                {
                    b.HasOne("ManageEmployeesVacations.Models.Employee", "Employee")
                        .WithMany("VacationRequests")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManageEmployeesVacations.Models.Vacation", "Vacation")
                        .WithMany()
                        .HasForeignKey("VacationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Vacation");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.Employee", b =>
                {
                    b.Navigation("EmployeeVacations");

                    b.Navigation("VacationRequests");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.Gender", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ManageEmployeesVacations.Models.Vacation", b =>
                {
                    b.Navigation("EmployeeVacations");
                });
#pragma warning restore 612, 618
        }
    }
}
