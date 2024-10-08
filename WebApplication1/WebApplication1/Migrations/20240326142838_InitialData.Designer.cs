﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240326142838_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("CategorySize")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("4c9a5ea0-4158-41d8-871e-32e4737343ad"),
                            CategoryName = "Work activities",
                            CategorySize = 1
                        },
                        new
                        {
                            CategoryId = new Guid("4c9a5ea0-4158-41d8-871e-32e473734302"),
                            CategoryName = "Personal activities",
                            CategorySize = 1
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("4c9a5ea0-4158-41d8-871e-32e473734310"),
                            CategoryId = new Guid("4c9a5ea0-4158-41d8-871e-32e4737343ad"),
                            Created = new DateTime(2024, 3, 26, 8, 28, 37, 805, DateTimeKind.Local).AddTicks(6427),
                            PriorityTask = 1,
                            Title = "Do the screen 1"
                        },
                        new
                        {
                            TaskId = new Guid("4c9a5ea0-4158-41d8-871e-32e473734311"),
                            CategoryId = new Guid("4c9a5ea0-4158-41d8-871e-32e473734302"),
                            Created = new DateTime(2024, 3, 26, 8, 28, 37, 805, DateTimeKind.Local).AddTicks(6459),
                            PriorityTask = 0,
                            Title = "Watch Netflix"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Task", b =>
                {
                    b.HasOne("WebApplication1.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
