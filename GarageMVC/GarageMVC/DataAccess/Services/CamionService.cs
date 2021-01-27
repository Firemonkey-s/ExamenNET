using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAcess.Services;
using GarageMVC.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class CamionService: BaseService<Camion>
    {
        public CamionService() : base(new Repository())
        {

        }

        public Camion GetById(int id)
        {
            return Get<Camion>(id);
        }
    }
}
