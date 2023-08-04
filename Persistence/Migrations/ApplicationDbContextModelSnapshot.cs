﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.DatabaseConfig;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.DepartmentModule.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique()
                        .HasFilter("[ManagerId] IS NOT NULL");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManagerId = 1,
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("Domain.TaskModule.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedById")
                        .HasColumnType("int");

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssignedById");

                    b.HasIndex("AssignedToId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.UserModule.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Domain.UserModule.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Domain.UserModule.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manager"
                        });
                });

            modelBuilder.Entity("Domain.UserModule.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2023, 8, 3, 19, 51, 59, 469, DateTimeKind.Utc).AddTicks(1784),
                            Email = "Admin",
                            Name = "Admin",
                            PasswordHash = "$2a$11$dbHhYauUfQyVPuC/UJYbrOAxbZqwRETlK2fi/K9U2EGE6V8bEExN6",
                            PhoneNumber = "012312321123984566",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2023, 8, 3, 19, 51, 59, 469, DateTimeKind.Utc).AddTicks(1850),
                            Email = "Employee",
                            Name = "Employee",
                            PasswordHash = "$2a$11$dbHhYauUfQyVPuC/UJYbrOAxbZqwRETlK2fi/K9U2EGE6V8bEExN6",
                            PhoneNumber = "12301123984290566",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            CreatedAt = new DateTime(2023, 8, 3, 19, 51, 59, 469, DateTimeKind.Utc).AddTicks(1853),
                            Email = "Manager",
                            Name = "Manager",
                            PasswordHash = "$2a$11$dbHhYauUfQyVPuC/UJYbrOAxbZqwRETlK2fi/K9U2EGE6V8bEExN6",
                            PhoneNumber = "1101123984290566",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Domain.DepartmentModule.Department", b =>
                {
                    b.HasOne("Domain.UserModule.Manager", "Manager")
                        .WithOne("Department")
                        .HasForeignKey("Domain.DepartmentModule.Department", "ManagerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Domain.TaskModule.Task", b =>
                {
                    b.HasOne("Domain.UserModule.Manager", "AssignedBy")
                        .WithMany("Tasks")
                        .HasForeignKey("AssignedById");

                    b.HasOne("Domain.UserModule.Employee", "AssignedTo")
                        .WithMany("Tasks")
                        .HasForeignKey("AssignedToId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("AssignedBy");

                    b.Navigation("AssignedTo");
                });

            modelBuilder.Entity("Domain.UserModule.Employee", b =>
                {
                    b.HasOne("Domain.DepartmentModule.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Domain.UserModule.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("Domain.UserModule.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.UserModule.Manager", b =>
                {
                    b.HasOne("Domain.UserModule.User", "User")
                        .WithOne("Manager")
                        .HasForeignKey("Domain.UserModule.Manager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.UserModule.User", b =>
                {
                    b.HasOne("Domain.UserModule.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.DepartmentModule.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.UserModule.Employee", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.UserModule.Manager", b =>
                {
                    b.Navigation("Department");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Domain.UserModule.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.UserModule.User", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("Manager")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}