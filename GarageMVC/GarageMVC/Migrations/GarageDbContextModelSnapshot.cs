﻿// <auto-generated />
using System;
using GarageMVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GarageMVC.Migrations
{
    [DbContext(typeof(GarageDbContext))]
    partial class GarageDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Intervention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateDebutTravaux")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<string>("Mecanicien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("Interventions");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime2");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.Property<int>("VehiculeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehiculeId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Vehicule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Immatriculation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proprietaire")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicules");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehicule");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.VehiculeMoteur", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.Vehicule");

                    b.Property<int>("Carburant")
                        .HasColumnType("int");

                    b.ToTable("Vehicules");

                    b.HasDiscriminator().HasValue("VehiculeMoteur");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Velo", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.Vehicule");

                    b.ToTable("Vehicules");

                    b.HasDiscriminator().HasValue("Velo");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Camion", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.VehiculeMoteur");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.ToTable("Vehicules");

                    b.HasDiscriminator().HasValue("Camion");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Voiture", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.VehiculeMoteur");

                    b.ToTable("Vehicules");

                    b.HasDiscriminator().HasValue("Voiture");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.VAE", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.Velo");

                    b.Property<int>("Automie")
                        .HasColumnType("int");

                    b.ToTable("Vehicules");

                    b.HasDiscriminator().HasValue("VAE");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Intervention", b =>
                {
                    b.HasOne("GarageMVC.DataAccess.BusinessModel.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Reservation", b =>
                {
                    b.HasOne("GarageMVC.DataAccess.BusinessModel.Vehicule", "Vehicule")
                        .WithMany()
                        .HasForeignKey("VehiculeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicule");
                });
#pragma warning restore 612, 618
        }
    }
}
