using System;
using System.Collections.Generic;
using System.Text;
using GarageMVC.DataAccess.BusinessModel;

namespace WpfGarage.ViewModel
{
    public class InterventionViewModel: BaseViewModel
    {
        public Intervention Model { get; set; }
        public InterventionViewModel(Intervention intervention)
        {
            Model = intervention;
        }

        public int Id {
            get { return Model.Id; }
            set { Model.Id = value; NotifyPropertyChanged(); }
        }
        public String Operation {
            get { return Model.Operation; }
            set { Model.Operation = value; NotifyPropertyChanged(); } 
        
        }
        public int Duree {
            get { return Model.Duree; }
            set { Model.Duree = value; NotifyPropertyChanged(); }
        }
        public String Mecanicien {
            get { return Model.Mecanicien; }
            set { Model.Mecanicien = value; NotifyPropertyChanged(); }
        }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public DateTime DateDebutTravaux {
            get { return Model.DateDebutTravaux; }
            set { Model.DateDebutTravaux = value; NotifyPropertyChanged(); }
        }
    }
}
