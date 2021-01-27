using System;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Repo{
    public interface IRepository
    {
        // renvoie une liste d'objets
        public List<T> GetAll<T>() where T:class;
        public T Get<T>(int id) where T : class;

        public void Edit<T>(T obj) where T : class;

        public void Insert<T>(T obj) where T : class;

        public void Delete<T>(T obj) where T : class;
    }
}
