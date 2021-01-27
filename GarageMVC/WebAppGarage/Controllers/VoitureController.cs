using GarageMVC.DataAccess.BusinessModel;
using GarageMVC.DataAccess.Services;
using WebAppGarage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGarage.Controllers
{
    public class VoitureController : Controller
    {
        private VoitureService serv;
        private List<VoitureViewModel> listVM;

        public VoitureController(VoitureService service)
        {
            serv = service;
        }
        // GET: VoitureController
        public ActionResult Index()
        {
            listVM = new List<VoitureViewModel>();
            var list = serv.GetAll<Voiture>();

            foreach (var item in list)
            {
                listVM.Add(new VoitureViewModel(item));
            }

            return View(listVM);
        }

        // GET: VoitureController/Details/5
        public ActionResult Details(int id)
        {
            var vm = serv.GetById(id);
            var VoitureVM = new VoitureViewModel(vm);
            return View();
        }

        // GET: VoitureController/Create
        public ActionResult Create()
        {
            var VoitureVM = new VoitureViewModel();

            return View(VoitureVM);
        }

        // POST: VoitureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoitureViewModel vm)
        {
            try
            {
                serv.Insert(vm.Model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoitureController/Edit/5
        public ActionResult Edit(int id)
        {
            var voiture = serv.GetById(id);
            VoitureViewModel VoitureVM = new VoitureViewModel(voiture);
            return View(VoitureVM);
        }

        // POST: VoitureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VoitureViewModel VoitureVm)
        {
            try
            {
                serv.Edit(VoitureVm.Model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoitureController/Delete/5
        public ActionResult Delete(int id)
        {
            var voiture = serv.GetById(id);
            VoitureViewModel voitureVM = new VoitureViewModel(voiture);
            return View(voitureVM);
        }

        // POST: VoitureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VoitureViewModel VoitureVm)
        {
            try
            {
                var voiture = serv.GetById(id);
                serv.Delete(voiture);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(VoitureVm);
            }
        }
    }
}
