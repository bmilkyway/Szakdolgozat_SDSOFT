﻿// <auto-generated />
using System;
using CRM.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.EntityFramework.Migrations
{
    [DbContext(typeof(CRM_DbContext))]
    partial class CRM_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CRM.Domain.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FromUserId")
                        .HasColumnType("int");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ToUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isRead")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FromUserId = 1,
                            MessageText = "Ez az első elküldött levél",
                            SendDate = new DateTime(2022, 8, 29, 18, 11, 10, 48, DateTimeKind.Local).AddTicks(603),
                            Subject = "Első levél",
                            ToUserId = 1,
                            isRead = false
                        });
                });

            modelBuilder.Entity("CRM.Domain.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            PermissionName = "Tulajdonos"
                        },
                        new
                        {
                            Id = 3,
                            PermissionName = "Irodai munkatárs"
                        },
                        new
                        {
                            Id = 4,
                            PermissionName = "Külsős"
                        });
                });

            modelBuilder.Entity("CRM.Domain.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Tervezés alatt"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "Szabad"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Elvállalt"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "Lezárt"
                        });
                });

            modelBuilder.Entity("CRM.Domain.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime");

                    b.Property<int>("ResponsibleUserId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Prgramozás",
                            CloseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreateDate = new DateTime(2022, 8, 29, 18, 11, 10, 48, DateTimeKind.Local).AddTicks(4889),
                            CreatedUserId = 1,
                            DeadLine = new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ResponsibleUserId = 1,
                            TaskDescription = "Ez az első feladat leírása",
                            TaskName = "Első feladat",
                            TaskStatusId = 1
                        });
                });

            modelBuilder.Entity("CRM.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Bajarmilan2001@gmail.com",
                            IsActive = true,
                            LoginDate = new DateTime(2022, 8, 29, 18, 11, 10, 46, DateTimeKind.Local).AddTicks(6765),
                            Name = "Bajár Milán",
                            Password = "Admin",
                            PermissionId = 1,
                            RegistrationDate = new DateTime(2022, 8, 29, 18, 11, 10, 43, DateTimeKind.Local).AddTicks(7261),
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("CRM.Domain.Models.Message", b =>
                {
                    b.HasOne("CRM.Domain.Models.User", null)
                        .WithMany("Messages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CRM.Domain.Models.Task", b =>
                {
                    b.HasOne("CRM.Domain.Models.User", null)
                        .WithMany("Tasks")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
