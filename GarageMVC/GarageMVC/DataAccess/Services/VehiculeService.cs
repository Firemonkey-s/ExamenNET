using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAcess.Services;
using GarageMVC.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class VehiculeService: BaseService<Vehicule>
    {
        public VehiculeService(): base(new Repository())
        {

        }
        public Vehicule GetById(int id)
        {
            return Get<Vehicule>(id);
        }
    }
}
