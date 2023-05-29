﻿// <auto-generated />
using System;
using IS2.Database.ProjectData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IS2.Database.ProjectData.Migrations
{
    [DbContext(typeof(ProjectDataContext))]
    [Migration("20230529113250_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ActionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionFormalizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionStatusId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("LocalNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("Actions", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ActionFormalization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ActionFormalizationId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ActionFormalizations", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ActionLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionId1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionId2")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActionId3")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionLinkId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LinkTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ActionLinks", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ActionLinkType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ActionLinkTypeId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ActionLinkTypes", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ActionStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ActionStatusId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ActionStatuses", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ActionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ActionTypeId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ActionTypes", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ConceptElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConceptElementClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConceptElementGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConceptElementId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAutoRange")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ConceptElements", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ConceptElementClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ConceptElementClassId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ConceptElementClasses", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ConceptElementGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<short>("ConceptElementGroupId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ConceptElementGroups", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ModelEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelStatusId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ModelTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ModelStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ModelStatusId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ModelStatuses", (string)null);
                });

            modelBuilder.Entity("IS2.Database.ProjectData.Model.ModelType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateInsert")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ModelTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VersionId", "DateInsert", "IsDeleted");

                    b.ToTable("ModelTypes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
