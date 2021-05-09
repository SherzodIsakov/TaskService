﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskService.Repositories.Contexts;

namespace TaskService.Repositories.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskService.Repositories.Entities.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LastSavedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastSavedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TaskEndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskInterval")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskStartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaskEntities");
                });

            modelBuilder.Entity("TaskService.Repositories.Entities.TaskSearchWordsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FindWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TaskEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TaskEntityId");

                    b.ToTable("TaskSearchWordsEntities");
                });

            modelBuilder.Entity("TaskService.Repositories.Entities.TextTaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FindindWordsCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LastSavedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastSavedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TextId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TextTaskEntities");
                });

            modelBuilder.Entity("TaskService.Repositories.Entities.TaskSearchWordsEntity", b =>
                {
                    b.HasOne("TaskService.Repositories.Entities.TaskEntity", "TaskEntity")
                        .WithMany("TaskSearchWordsEntities")
                        .HasForeignKey("TaskEntityId");

                    b.Navigation("TaskEntity");
                });

            modelBuilder.Entity("TaskService.Repositories.Entities.TaskEntity", b =>
                {
                    b.Navigation("TaskSearchWordsEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
