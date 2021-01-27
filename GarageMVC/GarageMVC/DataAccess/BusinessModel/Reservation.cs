using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GarageMVC.DataAccess.BusinessModel
{
    public enum PossibleOperation { ENTRETRIEN,REPARATION,NONE}
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public int VehiculeId { get; set; }

        [ForeignKey(nameof(VehiculeId))]
        public Vehicule Vehicule { get; set; }


        public DateTime DateReservation { get; set; }

        public PossibleOperation Operation { get; set; }


    }
}
