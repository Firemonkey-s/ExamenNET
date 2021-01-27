using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAccess.Services;
using WebAppGarage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace WebAppGarage.Controllers
{
    public class CamionController : Controller
    {
        private CamionService serv;
        private List<CamionViewModel> listVM;

        public CamionController(CamionService service)
        {
            serv = service;
        }

        // GET: CamionController
        public ActionResult Index()
        {
            listVM = new List<CamionViewModel>();
            var list= serv.GetAll<Camion>();

            foreach(var item in list)
            {
                listVM.Add(new CamionViewModel(item));
            }

            return View(listVM);
        }

        // GET: CamionController/Details/5
        // GET: LivreController/Create
        public ActionResult Create()
        {

            var CamionVM = new CamionViewModel();

            return View(CamionVM);
        }

        // POST: LivreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CamionViewModel v)
        {
            try
            {
                serv.Insert(v.Model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: VoutureController/Details/5
        public ActionResult Details(int id)
        {
            var v = serv.GetById(id);
            var CamionVM = new CamionViewModel(v);

            return View(CamionVM);
        }

        // GET: LivreController/Edit/5
        public ActionResult Edit(int id)
        {
            var camion = serv.GetById(id);
            CamionViewModel camionVM = new CamionViewModel(camion);
            return View(camionVM);

        }

        // POST: LivreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CamionViewModel camionVm)
        {
            try
            {
                serv.Edit(camionVm.Model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LivreController/Delete/5
        public ActionResult Delete(int id)
        {
            var camion  = serv.GetById(id);
            CamionViewModel camionVM = new CamionViewModel(camion);
            return View(camionVM);
        }

        // POST: LivreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CamionViewModel camionVm)
        {
            try
            {
                var camion = serv.GetById(id);
                serv.Delete(camion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(camionVm);
            }
        }
    }
}
