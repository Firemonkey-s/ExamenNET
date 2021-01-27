using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAccess.Repo;
using GarageMVC.DataAcess.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class InterventionService: BaseService<Intervention>
    {
        public InterventionService():base(new Repository())
        {

        }

        public Intervention GetById(int id)
        {
            return Get<Intervention>(id);
        }
    }
}
