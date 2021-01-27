﻿// <auto-generated />
using System;
using GarageMVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GarageMVC.Migrations
{
    [DbContext(typeof(GarageDbContext))]
    [Migration("20210126075959_AddOperationToReservation")]
    partial class AddOperationToReservation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

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

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.VAE", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.Vehicule");

                    b.Property<int>("Automie")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("VAE");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.VehiculeMoteur", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.Vehicule");

                    b.Property<int>("Carburant")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("VehiculeMoteur");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Velo", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.Vehicule");

                    b.HasDiscriminator().HasValue("Velo");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Camion", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.VehiculeMoteur");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Camion");
                });

            modelBuilder.Entity("GarageMVC.DataAccess.BusinessModel.Voiture", b =>
                {
                    b.HasBaseType("GarageMVC.DataAccess.BusinessModel.VehiculeMoteur");

                    b.HasDiscriminator().HasValue("Voiture");
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