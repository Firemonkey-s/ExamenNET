using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.BusinessModel
{
    public class Intervention
    {
        
        public int Id { get; set; }
        public String Operation { get; set; }
        public int Duree { get; set; }
        public String Mecanicien { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public DateTime DateDebutTravaux { get; set; }
    }
}
