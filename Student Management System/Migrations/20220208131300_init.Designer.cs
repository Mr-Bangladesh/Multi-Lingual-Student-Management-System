﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Management_System.Data;

namespace Student_Management_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220208131300_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseModelStudentModel", b =>
                {
                    b.Property<int>("EnrolledCoursesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("EnrolledCoursesId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseModelStudentModel");
                });

            modelBuilder.Entity("Student_Management_System.Models.CourseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseTeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseTeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Student_Management_System.Models.LanguageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Student_Management_System.Models.LocalizedPropertyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LanguageIdId")
                        .HasColumnType("int");

                    b.Property<string>("LocalValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageIdId");

                    b.ToTable("LocalizedProperty");
                });

            modelBuilder.Entity("Student_Management_System.Models.StudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roll")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Student_Management_System.Models.TeacherModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CourseModelStudentModel", b =>
                {
                    b.HasOne("Student_Management_System.Models.CourseModel", null)
                        .WithMany()
                        .HasForeignKey("EnrolledCoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_Management_System.Models.StudentModel", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Student_Management_System.Models.CourseModel", b =>
                {
                    b.HasOne("Student_Management_System.Models.TeacherModel", "CourseTeacher")
                        .WithMany("TakenCourses")
                        .HasForeignKey("CourseTeacherId");

                    b.Navigation("CourseTeacher");
                });

            modelBuilder.Entity("Student_Management_System.Models.LocalizedPropertyModel", b =>
                {
                    b.HasOne("Student_Management_System.Models.LanguageModel", "LanguageId")
                        .WithMany()
                        .HasForeignKey("LanguageIdId");

                    b.Navigation("LanguageId");
                });

            modelBuilder.Entity("Student_Management_System.Models.TeacherModel", b =>
                {
                    b.Navigation("TakenCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
