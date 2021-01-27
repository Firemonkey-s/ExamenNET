using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAcess.Services;
using GarageMVC.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class VAEService: BaseService<VAE>
    {
        public VAEService() : base(new Repository())
        {

        }
    }
}
