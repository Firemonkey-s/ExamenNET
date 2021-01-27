using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GarageMVC.DataAccess.BusinessModel
{
    public class ImmatrAndId
    {
        public int EnumId { get; set; }
        public string EnumImmatr { get; set; }
    }
    public enum TypeCarburant
    {
        Essence, Diesel, GPl
    }
    [Table("Vehicules")]
    public  class Vehicule
    {
        [Key]
        public int Id { get; set; }
        public String Proprietaire { get; set; }

        public String Immatriculation { get; set; }

        public String Marque { get; set; }
        public String Modele { get; set; }

    }
}
