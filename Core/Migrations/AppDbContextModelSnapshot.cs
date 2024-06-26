﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Core.Data.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("employee_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT")
                        .HasColumnName("patronymic");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("position");

                    b.Property<DateTime?>("QuitDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("quit_date");

                    b.Property<DateTime>("RecruitDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("recruit_date");

                    b.Property<decimal>("Salary")
                        .HasColumnType("TEXT")
                        .HasColumnName("salary");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fcd881e5-61e0-4237-b21a-37fac3195e53"),
                            Address = "вул. Гагаріна, буд. 10",
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Snow",
                            PhoneNumber = "123-456-7890",
                            Position = "Менеджер",
                            RecruitDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 50000m,
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("776ac3a7-267b-48fd-b29f-f188a3c61746"),
                            Address = "просп. Перемоги, буд. 5",
                            BirthDate = new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Maria",
                            LastName = "Sidrenko",
                            Patronymic = "Petrovna",
                            PhoneNumber = "987-654-3210",
                            Position = "Розробник",
                            QuitDate = new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RecruitDate = new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 60000m,
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("0c1e0bce-3fb4-4e56-8528-e929c1fbcf37"),
                            Address = "123 Main St",
                            BirthDate = new DateTime(1987, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Smith",
                            Patronymic = "Michael",
                            PhoneNumber = "111-222-3333",
                            Position = "Manager",
                            RecruitDate = new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 55000m,
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("f786689b-4484-425a-9dff-39a0851a2a3c"),
                            Address = "456 Elm St",
                            BirthDate = new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jane",
                            LastName = "Doe",
                            Patronymic = "Marie",
                            PhoneNumber = "555-666-7777",
                            Position = "Developer",
                            RecruitDate = new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 65000m,
                            Status = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
