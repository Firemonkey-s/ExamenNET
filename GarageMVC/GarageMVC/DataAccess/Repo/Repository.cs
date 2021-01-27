using GarageMVC.DataAcess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GarageMVC.DataAccess.Repo{
    public class Repository: IRepository
    {
        public static object lockobj = new object();

        // renvoie une liste d'objets
        public List<T> GetAll<T>() where T:class
        {
            lock (lockobj)
            {
                using (var ctx = new GarageDbContext())
                {
                    return ctx.Set<T>().ToList();
                }
             
            }

        }

        public T Get<T>(int id) where T : class
        {
            lock (lockobj)
            {
                using (var ctx = new GarageDbContext())
                {
                    return ctx.Find<T>(id);
                }

            }

        }

        public void Edit<T>(T obj) where T:class
        {
            lock (lockobj)
            {
                using (var ctx = new GarageDbContext())
                {
                    ctx.Update<T>(obj);
                    ctx.SaveChanges();
                }

            }

        }

        public void Insert<T>(T obj) where T:class        
        {
            lock (lockobj)
            {
                using (var ctx = new GarageDbContext())
                {
                    try
                    {
                        ctx.Add<T>(obj);
                        ctx.SaveChanges();
                    }
                    catch( Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }

            }
        }

        public void Delete<T>(T obj) where T:class
        {

            lock (lockobj)
            {
                using (var ctx = new GarageDbContext())
                {
                    ctx.Remove<T>(obj);
                    ctx.SaveChanges();

                }
            }

         }
    }
}
