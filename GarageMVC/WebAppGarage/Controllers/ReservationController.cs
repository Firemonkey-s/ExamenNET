using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAccess.Services;
using WebAppGarage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GarageMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppGarage.Controllers
{

    public class ReservationController : Controller
    {
        private ReservationService serv;
        private VehiculeService servVehicule;
        private List<ReservationViewModel> listVM;
        private IEnumerable<ImmatrAndId> listImmatrAndId;

        [NonAction]
        public SelectList ToSelectList(IEnumerable<ImmatrAndId> Enumlist)
        { 
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in Enumlist)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.EnumImmatr,
                    Value = item.EnumId.ToString()
                    
                }); 
            }

            return new SelectList(list, "Value", "Text");
        }

        [NonAction]
        private void QueryIDImmatr()
        {
            using (var context = new GarageDbContext())
            {
                 var Datas = context.Vehicules
                                    .Where(p => p.Immatriculation != "")
                                   .Select(p => new ImmatrAndId()
                                   {
                                       EnumId = p.Id,
                                       EnumImmatr = p.Immatriculation
                                   })
                                   .OrderBy(x => x.EnumImmatr);
                listImmatrAndId = Datas.ToList<ImmatrAndId>();
            }
        }

        public ReservationController(ReservationService reservationservice,VehiculeService vehiculeservice)
        {
            serv = reservationservice;
            servVehicule = vehiculeservice;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            listVM = new List<ReservationViewModel>();
            List<Reservation> list = serv.GetAll<Reservation>();

            foreach (var item in list)
            {
                Vehicule vehicule = servVehicule.Get<Vehicule>(item.VehiculeId);
                item.Vehicule = vehicule;
                listVM.Add(new ReservationViewModel(item));
            }

            return View(listVM);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {

            var ReservationVM = new ReservationViewModel();
            ReservationVM.DateReservation = DateTime.Today;
            QueryIDImmatr();
            ViewBag.ImmatrList = ToSelectList(listImmatrAndId);
            return View(ReservationVM);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel v)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var vehicule = servVehicule.Get<Vehicule>(v.VehiculeId);
                    v.model.Vehicule = null;
                    //vehicule.Immatriculation = "RR-400-EE";
                    v.model.VehiculeId = v.VehiculeId;

                    //v.model.Vehicule = vehicule;
                    serv.Insert(v.model);

                }
                else
                {
                    {
                        var message = string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        Exception exception = new Exception(message.ToString());
                        ;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {   
            var reservation =  serv.GetById(id);
            ReservationViewModel camionVM = new ReservationViewModel(reservation);
            return View(camionVM);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationViewModel reservationVM)
        {
            try
            {
                //reservationVM.model.Vehicule = null;
                //reservationVM.model.VehiculeId = reservationVM.VehiculeId;
                serv.Edit(reservationVM.model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var reservation = serv.GetById(id);
            Vehicule vehicule = servVehicule.Get<Vehicule>(reservation.VehiculeId);
            reservation.Vehicule = vehicule;
            ReservationViewModel camionVM = new ReservationViewModel(reservation);
            return View(camionVM);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var reservation = serv.GetById(id);
                serv.Delete(reservation);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
