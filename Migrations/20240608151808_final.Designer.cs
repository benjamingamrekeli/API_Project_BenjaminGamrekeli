﻿// <auto-generated />
using System;
using API_Project_BenjaminGamrekeli.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Project_BenjaminGamrekeli.Migrations
{
    [DbContext(typeof(DierContext))]
    [Migration("20240608151808_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.DierHabitat", b =>
                {
                    b.Property<int>("DierId")
                        .HasColumnType("int");

                    b.Property<int>("HabitatId")
                        .HasColumnType("int");

                    b.HasKey("DierId", "HabitatId");

                    b.HasIndex("HabitatId");

                    b.ToTable("DierHabitats");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Dier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dieet")
                        .HasColumnType("int");

                    b.Property<int?>("HabitatId")
                        .HasColumnType("int");

                    b.Property<int>("KlasseId")
                        .HasColumnType("int");

                    b.Property<int>("LevensVerwachting")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HabitatId");

                    b.HasIndex("KlasseId");

                    b.ToTable("Dieren");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Habitat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HabitatNaam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Habitats");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Klasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("KlasseNaam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Klassen");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.DierHabitat", b =>
                {
                    b.HasOne("API_Project_BenjaminGamrekeli.Entities.Dier", "Dier")
                        .WithMany("DierHabitats")
                        .HasForeignKey("DierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Project_BenjaminGamrekeli.Entities.Habitat", "Habitat")
                        .WithMany("DierHabitats")
                        .HasForeignKey("HabitatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dier");

                    b.Navigation("Habitat");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Dier", b =>
                {
                    b.HasOne("API_Project_BenjaminGamrekeli.Entities.Habitat", null)
                        .WithMany("Dieren")
                        .HasForeignKey("HabitatId");

                    b.HasOne("API_Project_BenjaminGamrekeli.Entities.Klasse", "Klasse")
                        .WithMany("Dieren")
                        .HasForeignKey("KlasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klasse");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Dier", b =>
                {
                    b.Navigation("DierHabitats");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Habitat", b =>
                {
                    b.Navigation("DierHabitats");

                    b.Navigation("Dieren");
                });

            modelBuilder.Entity("API_Project_BenjaminGamrekeli.Entities.Klasse", b =>
                {
                    b.Navigation("Dieren");
                });
#pragma warning restore 612, 618
        }
    }
}
