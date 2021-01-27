using Microsoft.EntityFrameworkCore;
using GarageMVC.DataAccess.BusinessModel;
using System;

namespace GarageMVC
{
    public class GarageDbContext : DbContext
    {
        static String ConnectionString;

        //public GarageDbContext(DbContextOptions<GarageDbContext> options) : base(options)
        //{

        //}
        //public GarageDbContext()
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (ConnectionString == null)
                {
                    ConnectionString = @"Data source = DESKTOP-2615O02\SQLEXPRESS; initial catalog=Garagee2b; integrated security = true";
                    

                }
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        public virtual DbSet<Vehicule> Vehicules { get; set; }
        public virtual DbSet<VehiculeMoteur> VehiculeMoteurs { get; set; }
        public virtual DbSet<Velo> Velos { get; set; }
        public virtual DbSet<Camion> Camions { get; set; }
        public virtual DbSet<Voiture> Voitures { get; set; }
        public virtual DbSet<VAE> VAEs { get; set; }
        public virtual DbSet<Intervention> Interventions { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }

    }
    
    
}
