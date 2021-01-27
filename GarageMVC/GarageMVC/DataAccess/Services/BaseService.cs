using System;
using System.Collections.Generic;
using GarageMVC.DataAccess.Repo;
using System.Text;

namespace GarageMVC.DataAcess.Services
{
    public abstract class BaseService<T>  where T : class
    {
        private IRepository Repo { get; set; }
        private DateTime NextUpdate { get; set; }
        private IEnumerable<T> entities { get; set; }
        public IEnumerable<T> Entities
        {
            get
            {
                if (entities == null || NextUpdate < DateTime.Now)
                    RefreshData();
                return entities;
            }
        }

        // Mise à jour du Cache de l'ensemble de données
        private void RefreshData()
        {
            entities = Repo.GetAll<T>();
            NextUpdate = DateTime.Now.AddHours(1);
        }

        public BaseService(IRepository repositery)
        {
            Repo = repositery;
        }

        public void Delete<T>(T obj) where T : class
        {
            Repo.Delete<T>(obj);
        }

        public void Edit<T>(T obj) where T : class
        {
            Repo.Edit<T>(obj);
        }

        public T Get<T>(int id) where T : class
        {
            return Repo.Get<T>(id);
        }

        public List<T> GetAll<T>() where T : class
        {
            return Repo.GetAll<T>();
        }

        public void Insert<T>(T obj) where T : class
        {
            Repo.Insert<T>(obj);
        }
    }
}
