using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageMVC;
using GarageMVC.DataAccess.BusinessModel;

namespace WebAppGarage.Controllers
{
    public class VAEController : Controller
    {
        private readonly GarageDbContext _context;

        public VAEController(GarageDbContext context)
        {
            _context = context;
        }

        // GET: VAE
        public async Task<IActionResult> Index()
        {
            return View(await _context.VAEs.ToListAsync());
        }

        // GET: VAE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vAE = await _context.VAEs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vAE == null)
            {
                return NotFound();
            }

            return View(vAE);
        }

        // GET: VAE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VAE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Automie,Id,Proprietaire,Marque,Modele")] VAE vAE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vAE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vAE);
        }

        // GET: VAE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vAE = await _context.VAEs.FindAsync(id);
            if (vAE == null)
            {
                return NotFound();
            }
            return View(vAE);
        }

        // POST: VAE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Automie,Id,Proprietaire,Marque,Modele")] VAE vAE)
        {
            if (id != vAE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vAE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VAEExists(vAE.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vAE);
        }

        // GET: VAE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vAE = await _context.VAEs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vAE == null)
            {
                return NotFound();
            }

            return View(vAE);
        }

        // POST: VAE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vAE = await _context.VAEs.FindAsync(id);
            _context.VAEs.Remove(vAE);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VAEExists(int id)
        {
            return _context.VAEs.Any(e => e.Id == id);
        }
    }
}
