using System;
using GarageMVC.DataAccess.BusinessModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppGarage.Models
{
    public class VoitureViewModel
    {
        public Voiture Model { get; set; }
        public VoitureViewModel(Voiture Voiture)
        {
            Model = Voiture;
        }

        public VoitureViewModel()
        {
            Model = new Voiture();
        }

        [DisplayName("N°")]
        public int Id
        {
            get { return Model.Id; }
            set { Model.Id = value; }
        }

        [Required(ErrorMessage = "Vous devez saisir le propriétaire")]
        [DisplayName("Propriétaire")]
        public String Proprietaire
        {
            get { return Model.Proprietaire; }
            set { Model.Proprietaire = value; }
        }

        [Required(ErrorMessage = "Vous devez saisir le numéro d'immatriculation")]
        [DisplayName("Numéro d'immatriculation")]
        public string Immatriculation
        {
            get { return Model.Immatriculation; }
            set { Model.Immatriculation = value; }
        }

        [Required(ErrorMessage = "Vous devez saisir la marque")]
        public string Marque
        {
            get { return Model.Marque; }
            set { Model.Marque = value; }
        }
        [Required(ErrorMessage = "Vous devez saisir le modèle")]
        [DisplayName("Modèle")]
        public String Modele
        {
            get { return Model.Modele; }
            set { Model.Modele = value; }
        }

        [Required(ErrorMessage = "Vous devez saisir le type de carburant")]
        [DisplayName("Carburant")]
        public TypeCarburant Carburant
        {
            get { return Model.Carburant; }
            set { Model.Carburant = value; }
        }
    }
}
