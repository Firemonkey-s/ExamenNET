using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAcess.Services;
using GarageMVC.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class VeloService: BaseService<Velo>
    {
        public VeloService() : base(new Repository())
        {

        }
    }
}
