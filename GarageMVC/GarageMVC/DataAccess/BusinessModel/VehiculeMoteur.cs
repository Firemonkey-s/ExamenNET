﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GarageMVC.DataAccess.BusinessModel
{
    [Table("Vehicules")]
    public class VehiculeMoteur: Vehicule
    {
        public TypeCarburant Carburant { get; set; }
    }
}
