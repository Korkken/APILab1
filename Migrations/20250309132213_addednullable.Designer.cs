﻿// <auto-generated />
using System;
using APILab1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APILab1.Migrations
{
    [DbContext(typeof(CvDBContext))]
    [Migration("20250309132213_addednullable")]
    partial class addednullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APILab1.Models.CV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId_FK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId_FK");

                    b.ToTable("cVs");
                });

            modelBuilder.Entity("APILab1.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CVId")
                        .HasColumnType("int");

                    b.Property<string>("Examen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId_FK")
                        .HasColumnType("int");

                    b.Property<string>("Skola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("SlutDatum")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDatum")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.HasIndex("PersonId_FK");

                    b.ToTable("educations");
                });

            modelBuilder.Entity("APILab1.Models.PersonInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kontaktuppgifter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("personInfos");
                });

            modelBuilder.Entity("APILab1.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beskrivning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CVId")
                        .HasColumnType("int");

                    b.Property<string>("Företag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jobbtitel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId_FK")
                        .HasColumnType("int");

                    b.Property<int>("SlutÅr")
                        .HasColumnType("int");

                    b.Property<int>("StartÅr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CVId");

                    b.HasIndex("PersonId_FK");

                    b.ToTable("workExperience");
                });

            modelBuilder.Entity("APILab1.Models.CV", b =>
                {
                    b.HasOne("APILab1.Models.PersonInfo", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("APILab1.Models.Education", b =>
                {
                    b.HasOne("APILab1.Models.CV", null)
                        .WithMany("Utbildningar")
                        .HasForeignKey("CVId");

                    b.HasOne("APILab1.Models.PersonInfo", "Person")
                        .WithMany("Utbildningar")
                        .HasForeignKey("PersonId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("APILab1.Models.WorkExperience", b =>
                {
                    b.HasOne("APILab1.Models.CV", null)
                        .WithMany("Erfarenheter")
                        .HasForeignKey("CVId");

                    b.HasOne("APILab1.Models.PersonInfo", "Person")
                        .WithMany("Erfarenheter")
                        .HasForeignKey("PersonId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("APILab1.Models.CV", b =>
                {
                    b.Navigation("Erfarenheter");

                    b.Navigation("Utbildningar");
                });

            modelBuilder.Entity("APILab1.Models.PersonInfo", b =>
                {
                    b.Navigation("Erfarenheter");

                    b.Navigation("Utbildningar");
                });
#pragma warning restore 612, 618
        }
    }
}
