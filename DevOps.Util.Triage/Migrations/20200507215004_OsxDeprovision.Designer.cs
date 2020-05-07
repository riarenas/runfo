﻿// <auto-generated />
using System;
using DevOps.Util.Triage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevOps.Util.Triage.Migrations
{
    [DbContext(typeof(TriageContext))]
    [Migration("20200507215004_OsxDeprovision")]
    partial class OsxDeprovision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevOps.Util.Triage.ModelBuild", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BuildNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("GitHubOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubRepository")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<int?>("PullRequestNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.ToTable("ModelBuilds");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelBuildDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AzureOrganization")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AzureProject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("DefinitionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AzureOrganization", "AzureProject", "DefinitionId")
                        .IsUnique()
                        .HasFilter("[AzureOrganization] IS NOT NULL AND [AzureProject] IS NOT NULL");

                    b.ToTable("ModelBuildDefinitions");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelOsxDeprovisionRetry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OsxJobFailedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.ToTable("ModelOsxDeprovisionRetry");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageGitHubIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuildQuery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IncludeDefinitions")
                        .HasColumnType("bit");

                    b.Property<int>("IssueNumber")
                        .HasColumnType("int");

                    b.Property<int>("ModelTriageIssueId")
                        .HasColumnType("int");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Repository")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ModelTriageIssueId");

                    b.HasIndex("Organization", "Repository", "IssueNumber")
                        .IsUnique();

                    b.ToTable("ModelTriageGitHubIssues");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SearchKind")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SearchText")
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("TriageIssueKind")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("SearchKind", "SearchText")
                        .IsUnique()
                        .HasFilter("[SearchText] IS NOT NULL");

                    b.ToTable("ModelTriageIssues");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageIssueResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildNumber")
                        .HasColumnType("int");

                    b.Property<string>("HelixJobId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixWorkItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModelTriageIssueId")
                        .HasColumnType("int");

                    b.Property<string>("TimelineRecordName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("ModelTriageIssueId");

                    b.ToTable("ModelTriageIssueResults");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageIssueResultComplete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModelTriageIssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("ModelTriageIssueId", "ModelBuildId")
                        .IsUnique()
                        .HasFilter("[ModelBuildId] IS NOT NULL");

                    b.ToTable("ModelTriageIssueResultCompletes");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelBuild", b =>
                {
                    b.HasOne("DevOps.Util.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelOsxDeprovisionRetry", b =>
                {
                    b.HasOne("DevOps.Util.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId");
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageGitHubIssue", b =>
                {
                    b.HasOne("DevOps.Util.Triage.ModelTriageIssue", "ModelTriageIssue")
                        .WithMany("ModelTriageGitHubIssues")
                        .HasForeignKey("ModelTriageIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageIssueResult", b =>
                {
                    b.HasOne("DevOps.Util.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId");

                    b.HasOne("DevOps.Util.Triage.ModelTriageIssue", "ModelTriageIssue")
                        .WithMany("ModelTriageIssueResults")
                        .HasForeignKey("ModelTriageIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.Triage.ModelTriageIssueResultComplete", b =>
                {
                    b.HasOne("DevOps.Util.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId");

                    b.HasOne("DevOps.Util.Triage.ModelTriageIssue", "ModelTriageIssue")
                        .WithMany()
                        .HasForeignKey("ModelTriageIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
