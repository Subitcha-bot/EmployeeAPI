﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEmployeeApplication.Data;

namespace MyEmployeeApplication.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221202053855_AppDb")]
    partial class AppDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyEmployeeApplication.Model.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "HR"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Sales"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Production"
                        });
                });

            modelBuilder.Entity("MyEmployeeApplication.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeAge")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Department_Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 101,
                            DateOfBirth = new DateTime(1995, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department_Id = 1,
                            Email = "NickJones@gmail.com",
                            EmployeeAge = 27,
                            FirstName = "Nick",
                            Gender = 0,
                            LastName = "Jones"
                        },
                        new
                        {
                            EmployeeId = 102,
                            DateOfBirth = new DateTime(1986, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department_Id = 3,
                            Email = "DanielThompson@gmail.com",
                            EmployeeAge = 36,
                            FirstName = "Daniel",
                            Gender = 0,
                            LastName = "Thomphson"
                        },
                        new
                        {
                            EmployeeId = 103,
                            DateOfBirth = new DateTime(1991, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department_Id = 3,
                            Email = "SusanBradford@gmail.com",
                            EmployeeAge = 31,
                            FirstName = "Susan",
                            Gender = 1,
                            LastName = "Bradford"
                        },
                        new
                        {
                            EmployeeId = 104,
                            DateOfBirth = new DateTime(1994, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Department_Id = 2,
                            Email = "RoselineEsther@gmail.com",
                            EmployeeAge = 28,
                            FirstName = "Roseline ",
                            Gender = 1,
                            LastName = "Esther"
                        });
                });

            modelBuilder.Entity("MyEmployeeApplication.Model.Employee", b =>
                {
                    b.HasOne("MyEmployeeApplication.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("Department_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
