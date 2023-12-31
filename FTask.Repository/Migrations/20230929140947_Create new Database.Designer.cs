﻿// <auto-generated />
using System;
using FTask.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FTask.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230929140947_Create new Database")]
    partial class CreatenewDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FTask.Repository.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemesterId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemesterId");

                    b.ToTable("Semester", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TaskCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TaskCategoryId");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskActivity", b =>
                {
                    b.Property<int>("TaskActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskActivityId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskUserId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskActivityId");

                    b.HasIndex("TaskUserId");

                    b.ToTable("TaskActivity", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskCategory", b =>
                {
                    b.Property<int>("TaskCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskCategoryId");

                    b.ToTable("TaskCategory", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskReport", b =>
                {
                    b.Property<int>("TaskReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskReportId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskACtivityId")
                        .HasColumnType("int");

                    b.HasKey("TaskReportId");

                    b.HasIndex("TaskACtivityId")
                        .IsUnique()
                        .HasFilter("[TaskACtivityId] IS NOT NULL");

                    b.ToTable("TaskReport", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskUser", b =>
                {
                    b.Property<int>("TaskUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskUserId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TaskUserId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskUser", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Lecturer_Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubjectId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Lecturer_Subjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("FTask.Repository.Entity.Department", b =>
                {
                    b.HasOne("FTask.Repository.Identity.User", "Manager")
                        .WithOne("ManagedDepartment")
                        .HasForeignKey("FTask.Repository.Entity.Department", "ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("FTask.Repository.Entity.Subject", b =>
                {
                    b.HasOne("FTask.Repository.Entity.Department", "Department")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("FTask.Repository.Entity.Task", b =>
                {
                    b.HasOne("FTask.Repository.Entity.Department", "Department")
                        .WithMany("Tasks")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FTask.Repository.Entity.Semester", "Semester")
                        .WithMany("Tasks")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FTask.Repository.Entity.Subject", "Subject")
                        .WithMany("Tasks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FTask.Repository.Entity.TaskCategory", "TaskCategory")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Semester");

                    b.Navigation("Subject");

                    b.Navigation("TaskCategory");
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskActivity", b =>
                {
                    b.HasOne("FTask.Repository.Entity.TaskUser", "TaskUser")
                        .WithMany("TaskActivities")
                        .HasForeignKey("TaskUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskUser");
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskReport", b =>
                {
                    b.HasOne("FTask.Repository.Entity.TaskActivity", "TaskACtivity")
                        .WithOne("TaskReport")
                        .HasForeignKey("FTask.Repository.Entity.TaskReport", "TaskACtivityId");

                    b.Navigation("TaskACtivity");
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskUser", b =>
                {
                    b.HasOne("FTask.Repository.Entity.Task", "Task")
                        .WithMany("TaskUsers")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FTask.Repository.Identity.User", "User")
                        .WithMany("TaskUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FTask.Repository.Identity.User", b =>
                {
                    b.HasOne("FTask.Repository.Entity.Department", "Department")
                        .WithMany("Lecturers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Lecturer_Subjects", b =>
                {
                    b.HasOne("FTask.Repository.Entity.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FTask.Repository.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("FTask.Repository.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FTask.Repository.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FTask.Repository.Entity.Department", b =>
                {
                    b.Navigation("Lecturers");

                    b.Navigation("Subjects");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("FTask.Repository.Entity.Semester", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("FTask.Repository.Entity.Subject", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("FTask.Repository.Entity.Task", b =>
                {
                    b.Navigation("TaskUsers");
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskActivity", b =>
                {
                    b.Navigation("TaskReport");
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskCategory", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("FTask.Repository.Entity.TaskUser", b =>
                {
                    b.Navigation("TaskActivities");
                });

            modelBuilder.Entity("FTask.Repository.Identity.User", b =>
                {
                    b.Navigation("ManagedDepartment");

                    b.Navigation("TaskUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
