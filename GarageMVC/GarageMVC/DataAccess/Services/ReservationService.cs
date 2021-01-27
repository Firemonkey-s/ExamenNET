using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAcess.Services;
using GarageMVC.DataAccess.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Services
{
    public class ReservationService: BaseService<Reservation>
    {
        public ReservationService() : base(new Repository())
        {

        }
        public Reservation GetById(int id)
        {
            return Get<Reservation>(id);
        }
    }
}
