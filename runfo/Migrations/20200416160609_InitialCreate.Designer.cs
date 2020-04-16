﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace runfo.Migrations
{
    [DbContext(typeof(RuntimeInfoDbContext))]
    [Migration("20200416160609_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Model.TriageBuild", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("BuildNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Organization")
                        .HasColumnType("TEXT");

                    b.Property<string>("Project")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TriageBuilds");
                });

            modelBuilder.Entity("Model.TriageReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IssueUri")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TriageBuildId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TriageBuildId");

                    b.ToTable("TriageReasons");
                });

            modelBuilder.Entity("Model.TriageReason", b =>
                {
                    b.HasOne("Model.TriageBuild", "TriageBuild")
                        .WithMany("TriageReasons")
                        .HasForeignKey("TriageBuildId");
                });
#pragma warning restore 612, 618
        }
    }
}
