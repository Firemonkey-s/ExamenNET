using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAcess.Services;
using GarageMVC.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class VoitureService: BaseService<Voiture>
    {
        public VoitureService() : base(new Repository())
        {

        }
        public Voiture GetById(int id)
        {
            return Get<Voiture>(id);
        }
    }
}
