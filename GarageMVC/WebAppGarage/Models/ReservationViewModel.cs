using System;
using GarageMVC.DataAccess.BusinessModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebAppGarage.Models
{
    public enum PossibleVehicule { VOITURE, CAMION, VELO, VAE }
    public class ReservationViewModel
    {
     

        public Reservation model { get; set; }

        public ReservationViewModel(Reservation reservation)
        {
            model = reservation;
        }

        public ReservationViewModel()
        {
            model = new Reservation();

            model.Vehicule = new Vehicule();
            model.Vehicule.Immatriculation = "None";
            model.Vehicule.Proprietaire = "None";
            model.Vehicule.Marque = "None";
            model.Vehicule.Modele = "None";
        }


        public int Id
        {
            get { return model.Id; }
            set { model.Id = value; }
        }

        [Required(ErrorMessage = "Vous saisir le véhicule")]
        [DisplayName("N° du véhicule")]
        public int VehiculeId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Vous devez saisir la date de réservation")]
        [DisplayName("Catégorie véhicule")]
        public PossibleVehicule typeVehicule { get; set; }

        [Required(ErrorMessage = "Vous devez saisir la date de réservation")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date de réservation")]
        public DateTime DateReservation { 
            get { return model.DateReservation; }
            set { model.DateReservation = value; }
        }

        [Required(ErrorMessage = "Vous devez sélectionner Entretien ou Réparation")]
        [DisplayName("Opération")]
        public PossibleOperation Operation
        {
            get { return model.Operation; }
            set { model.Operation = value; }
        }

        public IEnumerable<ImmatrAndId> DropDownList{ get; set; }



        [DisplayName("Type de travaux")]
        public String OpLibelle
        { 
            get
            {
                String libelle = "";
                switch (Operation)
                {
                    case PossibleOperation.ENTRETRIEN:
                        libelle = "Entretien";
                        break;
                    case PossibleOperation.REPARATION:
                        libelle = "Réparation";
                        break;
                    default:
                        libelle = "";
                        break;
                }
                return libelle;

            }
        }

        [Required(ErrorMessage = "Vous devez saisir le propriétaire")]
        [DisplayName("Propriétaire")]
        public String Proprietaire
        {
            get { return model.Vehicule.Proprietaire; }
            set { model.Vehicule.Proprietaire = value; }
        }

        [Required(ErrorMessage = "Vous devez saisir le numéro d'immatriculation")]
        [DisplayName("Numéro d'immatriculation")]
        public string Immatriculation
        {
            get { return model.Vehicule.Immatriculation; }
            set { model.Vehicule.Immatriculation = value; }
        }

        [Required(ErrorMessage = "Vous devez saisir la marque")]
        public string Marque
        {
            get { return model.Vehicule.Marque; }
            set { model.Vehicule.Marque = value; }
        }
        [Required(ErrorMessage = "Vous devez saisir le modèle")]
        [DisplayName("Modèle")]
        public String modele
        {
            get { return model.Vehicule.Modele; }
            set { model.Vehicule.Modele = value; }
        }

    }
}
